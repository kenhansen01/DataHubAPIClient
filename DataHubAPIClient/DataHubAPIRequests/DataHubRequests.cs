using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DataHubAPIClient.DataHubAPIResponse;

namespace DataHubAPIClient.DataHubAPIRequests
{
    /// <summary>
    /// Sends requests to datahub and returns responses.
    /// </summary>
    public class DataHubRequests
    {
        private HttpClient client = new HttpClient();
        /// <summary>
        /// Gets or sets BaseUrl
        /// </summary>
        public string BaseUrl;
        /// <summary>
        /// Gets or sets the Request Uri
        /// </summary>
        public string ReqUri;
        private string Creds;
        /// <summary>
        /// Gets or sets HttpClient Instance
        /// </summary>
        public HttpClient Client { get => client; set => client = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataHubRequests"/> class.
        /// </summary>
        /// <param name="baseUrl">The base portion of the url.</param>
        /// <param name="reqUri">Request endpoint</param>
        /// <param name="userName">User with access to DataHub</param>
        /// <param name="userPassword">User's Password</param>
        /// <param name="client">HttpClient to use in application. If not provided, defaults to a new HttpClient.</param>
        /// <example>
        /// This shows how to construct the Object
        /// <code>
        /// DataHubRequests dhRequest = new DataHubRequests("https://test.data.com:8888/", "data/v1/employee", "UserName", "Pa$$w0rd");
        /// </code>
        /// </example>
        public DataHubRequests(string baseUrl, string reqUri, string userName, string userPassword, HttpClient client = null)
        {
            if(client != null) { Client = client; }
            //Client = client;
            BaseUrl = baseUrl;
            ReqUri = reqUri;

            Creds = Base64Credentials(userName, userPassword);

            SetHttpClientDefaults();
        }

        /// <summary>
        /// Sets the default values for the HttpClient:
        ///   - BaseAddress set to BaseUrl
        ///   - Clears Accept Header and sets to application\json
        ///   - Sets Authorization header to Basic with Creds
        /// </summary>
        public void SetHttpClientDefaults()
        {
            Client.BaseAddress = new Uri(BaseUrl);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Creds);
        }

        /// <summary>
        /// Creates Base64 Credential string for REST auth.
        /// </summary>
        /// <param name="uName">The user name.</param>
        /// <param name="uPassword">The user password.</param>
        /// <returns>Base 64 encoded string.</returns>
        private string Base64Credentials(string uName, string uPassword) => Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(uName + ":" + uPassword));

        /// <summary>
        /// Creates a url with query params.
        /// </summary>
        /// <param name="path">The request endpoint.</param>
        /// <param name="queryParams">A collection of strings for each of the params to add.</param>
        /// <returns>String with full REST query.</returns>
        /// <example>
        /// <code>
        /// string restUri = CreateAPIUrl("data/v1/endpoint", new StringCollection(){"param1=wow","param2=startsWith::neat"});
        /// </code>
        /// ---------------------------
        /// data/v1/endpoint?param1=wow&amp;param2=startsWith::neat
        /// </example>
        public string CreateAPIUrl(string path, StringCollection queryParams = null)
        {
            if (queryParams != null)
            {
                string queryParamString = null;
                foreach (string param in queryParams) { queryParamString += param + "&"; };
                queryParamString = queryParamString.Remove(queryParamString.Length - 1);
                path = path + "?" + queryParamString;
            }
            return path;
        }

        /// <summary>
        /// Gets an async response from the DataHub.
        /// </summary>
        /// <param name="queryParams">Collection of query strings to append to the endpoint. Default is null.</param>
        /// <returns>Async response with DataHubResponse Object</returns>
        public async Task<DataHubResponse> GetEmployeesAsync(StringCollection queryParams = null)
        {
            DataHubResponse dhResponse = null;

            string path = CreateAPIUrl(ReqUri, queryParams);
            
            HttpResponseMessage response = await Client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                JObject jsonResponse = await response.Content.ReadAsAsync<JObject>();
                dhResponse = jsonResponse.ToObject<DataHubResponse>();
            }
            return dhResponse;
        }

        /// <summary>
        /// Sends the request. If more than 500 employees are returned, uses RunBatchesAsync() to get the full result.
        /// </summary>
        /// <param name="reqParams">Collection of query strings to append to the endpoint. Default is null.</param>
        /// <returns>Async response with DataHubResponse Object</returns>
        public async Task<DataHubResponse> RunQueryAsync(StringCollection reqParams = null)
        {

            DataHubResponse HubResponse = await GetEmployeesAsync(reqParams);
            // If response is greater than 500 break into groups of 100 and combine results
            if (HubResponse.TotalRecordCount > 500)
            {
                var employeesResponse = await RunBatchesAsync(reqParams);
                HubResponse.RecordCount = employeesResponse.Length;
                HubResponse.Employees = employeesResponse;
            }
            return HubResponse;

        }

        /// <summary>
        /// Used for more than 500 results. Runs GetEmployeesIdsOnlyAsync, groups the results by 100, then GetBatchEmployeesAsync queries each group of IDs, combines the results into an array of employees.
        /// </summary>
        /// <param name="reqParams">Collection of query strings to append to the endpoint. Default is null.</param>
        /// <returns>Array of Employee Objects.</returns>
        public async Task<Employee[]> RunBatchesAsync(StringCollection reqParams = null)
        {
            Employee[] employeeArray = new Employee[0];
            int groupSize = 100;

            DataHubResponse allIds = await GetEmployeesIdsOnlyAsync(reqParams);
            IEnumerable<IGrouping<int, string>> idGroups = allIds.Employees
                .Select((e, i) => new { employee = e, Index = i })
                .GroupBy(e => e.Index / groupSize, e => e.employee.EmployeeId);

            // Get results from each group as batches
            Task<Employee[][]> results = Task.WhenAll(idGroups.Select(async group => await GetBatchEmployeesAsync(group)).ToArray());
            
            // Combine arrays into single array.
            return (await results).SelectMany(result => result).ToArray();
        }

        /// <summary>
        /// Runs a query with the idsOnly param appended.
        /// </summary>
        /// <param name="reqParams">Collection of query strings to append to the endpoint. Default is null.</param>
        /// <returns>Async DataHub Object, containing only Employee Ids. No limit on result length.</returns>
        public async Task<DataHubResponse> GetEmployeesIdsOnlyAsync(StringCollection reqParams = null)
        {
            reqParams.Add("idsOnly");
            return await GetEmployeesAsync(reqParams);
        }

        /// <summary>
        /// Accepts an IGrouping of employeeIds then sends query for group results.
        /// </summary>
        /// <param name="employeeIds">Group of Employee Ids.</param>
        /// <returns>Array of Employees.</returns>
        public async Task<Employee[]> GetBatchEmployeesAsync(IGrouping<int, string> employeeIds)
        {
            StringCollection batchParams = new StringCollection() { "employeeId=inList::" + String.Join(",", employeeIds) };
            DataHubResponse batchResponse = await GetEmployeesAsync(batchParams);
            return batchResponse.Employees;
        }

    }
}
