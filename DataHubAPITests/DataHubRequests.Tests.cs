using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Specialized;
using DataHubAPITests.Mocks;
using RichardSzalay.MockHttp;
using DataHubAPIClient.DataHubAPIRequests;
using DataHubAPIClient.DataHubAPIResponse;

namespace DataHubAPITests
{
    [TestClass]
    public class DataHubRequestsTest
    {
        static DataHubMocks dhMocks;
        static MockHttpMessageHandler dhHandler;
        static DataHubRequests dhRequests;
        static string path;
        static string uri;

        public static object Properties { get; private set; }

        [ClassInitialize]
        public static void CreateMocks(TestContext context)
        {
            dhMocks = new DataHubMocks();
            dhHandler = dhMocks.GetDataHubMock();
            path = "https://hawscorpp.ameren.com:8443/";
            uri = "hrdatahub/v1/employee";
            //creds = "Q09SUE9SQVRFXFVzZXJOYW1lOlBhJCR3MHJk";
            dhRequests = new DataHubRequests(path, uri, @"CORPORATE\UserName", "Pa$$w0rd");
        }

        [TestCleanup]
        public void ClearMockResponses() => dhHandler.Clear();

        [TestMethod]
        public void CreateURITestWithParams()
        {
            //string path = "http://test/v1/endpoint";
            StringCollection qParams = new StringCollection()
            {
                "testQueryParam=what",
                "testQueryParam2=startsWith::derp"
            };
            string result = dhRequests.CreateAPIUrl(path, qParams);

            Assert.AreEqual(path + "?testQueryParam=what&testQueryParam2=startsWith::derp", actual: result);
        }
        [TestMethod]
        public void CreateURITestWithoutParams()
        {
            //string path = "http://test/v1/endpoint";
            string result = dhRequests.CreateAPIUrl(path);

            Assert.AreEqual(path, actual: result);
        }

        [TestMethod]
        public void DataHubRequestTestGreaterThan500Results()
        {
            dhMocks.SetMockLargeResponse();
            dhRequests.Client = dhHandler.ToHttpClient();
            dhRequests.SetHttpClientDefaults();
            StringCollection rqParams = new StringCollection() { "functionCode=060" };

            DataHubResponse response = dhRequests.RunQueryAsync(rqParams).Result;

            Assert.IsTrue(condition: 741 == response.TotalRecordCount);
            Assert.IsTrue(condition: 741 == response.Employees.Length);

            DataHubMocks.MockHttp.VerifyNoOutstandingExpectation();
        }

        [TestMethod]
        public void DataHubRequestTestSingleResult()
        {
            dhMocks.SetMockSingleResponse();
            dhRequests.Client = dhHandler.ToHttpClient();
            dhRequests.SetHttpClientDefaults();
            StringCollection rqParams = new StringCollection() { "employeeId=140889" };

            DataHubResponse response = dhRequests.RunQueryAsync(rqParams).Result;

            Assert.AreEqual("Hansen", response.Employees[0].LastName);
        }
    }
}
