using RichardSzalay.MockHttp;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace DataHubAPITests.Mocks
{
    public class DataHubMocks
    {
        private static MockHttpMessageHandler mockHttp;
        private static string folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string employeeId140889 = (File.ReadAllText(Path.Combine(folderPath, @"Mocks\Responses\EmployeeId140889.json")));
        string func60Response = (File.ReadAllText(Path.Combine(folderPath, @"Mocks\Responses\Function60.json")));
        string func60IdsResponse = (File.ReadAllText(Path.Combine(folderPath, @"Mocks\Responses\Function60Ids.json")));
        string func60Response100 = (File.ReadAllText(Path.Combine(folderPath, @"Mocks\Responses\Function60First100.json")));
        string func60Response200 = (File.ReadAllText(Path.Combine(folderPath, @"Mocks\Responses\Function60Second100.json")));
        string func60Response300 = (File.ReadAllText(Path.Combine(folderPath, @"Mocks\Responses\Function60Third100.json")));
        string func60Response400 = (File.ReadAllText(Path.Combine(folderPath, @"Mocks\Responses\Function60Fourth100.json")));
        string func60Response500 = (File.ReadAllText(Path.Combine(folderPath, @"Mocks\Responses\Function60Fifth100.json")));
        string func60Response600 = (File.ReadAllText(Path.Combine(folderPath, @"Mocks\Responses\Function60Sixth100.json")));
        string func60Response700 = (File.ReadAllText(Path.Combine(folderPath, @"Mocks\Responses\Function60Seventh100.json")));
        string func60Response741 = (File.ReadAllText(Path.Combine(folderPath, @"Mocks\Responses\Function60Final41.json")));

        public static MockHttpMessageHandler MockHttp { get => mockHttp; set => mockHttp = value; }

        public DataHubMocks()
        {
            MockHttp = new MockHttpMessageHandler();
            //setMockResponse();
        }

        public void SetMockSingleResponse ()
        {
            MockHttp.When("https://hawscorpp.ameren.com:8443/hrdatahub/v1/employee?employeeId=140889")
                .WithHeaders(new Dictionary<string, string>
                {
                    {"Authorization", "Basic Q09SUE9SQVRFXFVzZXJOYW1lOlBhJCR3MHJk" },
                    {"Accept", "application/json" }
                })
                .Respond(System.Net.HttpStatusCode.OK, "application/json", content: employeeId140889);
        }

        public void SetMockLargeResponse ()
        {
            // Greater than 500 results
            MockHttp.Expect("https://hawscorpp.ameren.com:8443/hrdatahub/v1/employee?functionCode=060")
                .WithHeaders(new Dictionary<string, string>
                {
                    {"Authorization", "Basic Q09SUE9SQVRFXFVzZXJOYW1lOlBhJCR3MHJk" },
                    {"Accept", "application/json" }
                })
                .Respond(System.Net.HttpStatusCode.OK, "application/json", func60Response);

            // All ids when greater than 500 results
            MockHttp.Expect("https://hawscorpp.ameren.com:8443/hrdatahub/v1/employee?functionCode=060&idsOnly")
                .WithHeaders(new Dictionary<string, string>
                {
                    {"Authorization", "Basic Q09SUE9SQVRFXFVzZXJOYW1lOlBhJCR3MHJk" },
                    {"Accept", "application/json" }
                })
                .Respond(System.Net.HttpStatusCode.OK, "application/json", func60IdsResponse);

            // First 100 batch
            MockHttp.Expect("https://hawscorpp.ameren.com:8443/hrdatahub/v1/employee?employeeId=inList::00090,02170,03266,03347,05013,05249,06294,06534,07581,07583,08298,09696,100289,100379,100484,100945,101842,102968,103531,104098,104277,104736,104772,105204,105311,105369,105545,105958,106849,107354,107810,108584,109565,109650,110645,110704,113467,113782,115363,115449,115602,115699,115896,115897,115898,115909,115965,116074,116079,116237,116298,116598,116625,11669,116711,116983,117174,117310,117575,117744,118076,118093,118162,118203,118256,118312,118391,11919,119285,119354,119365,119716,119827,119840,119877,119945,120081,120082,120083,120670,120755,120895,121333,121401,121484,121581,121760,121789,122001,122210,122702,122706,122708,122713,122714,122803,122988,123253,123334,123488")
                .WithHeaders(new Dictionary<string, string>
                {
                    {"Authorization", "Basic Q09SUE9SQVRFXFVzZXJOYW1lOlBhJCR3MHJk" },
                    {"Accept", "application/json" }
                })
                .Respond(System.Net.HttpStatusCode.OK, "application/json", func60Response100);

            // Second 100 batch
            MockHttp.Expect("https://hawscorpp.ameren.com:8443/hrdatahub/v1/employee?employeeId=inList::123980,124145,124160,124161,124162,124196,124256,124370,124398,124413,124909,124985,124986,125407,125929,126063,126238,126328,126344,126395,12648,126488,126685,127155,127195,127279,127444,127621,127623,127739,127743,127749,127859,128018,128049,128078,128236,128240,128278,128345,128346,128347,128406,128407,128411,128796,128902,128923,129026,129027,129070,129071,129099,129291,129435,129562,129804,129825,130141,130198,130200,130201,130202,130232,130254,130313,130372,130459,130663,130819,130887,130909,130947,130962,130968,130994,131035,131101,131151,131208,131239,131243,131259,131454,131465,131468,131675,131689,131702,132043,132084,132313,132548,132596,132655,132659,132911,132981,133189,133473")
                .WithHeaders(new Dictionary<string, string>
                {
                    {"Authorization", "Basic Q09SUE9SQVRFXFVzZXJOYW1lOlBhJCR3MHJk" },
                    {"Accept", "application/json" }
                })
                .Respond(System.Net.HttpStatusCode.OK, "application/json", func60Response200);

            // Third 100 batch
            MockHttp.Expect("https://hawscorpp.ameren.com:8443/hrdatahub/v1/employee?employeeId=inList::133631,133665,133706,133708,133711,133728,133786,133852,133914,133953,133956,133957,133988,134108,134200,134274,134280,134425,134498,134506,134692,134757,134798,134830,134847,135055,135347,135358,135402,135418,135519,135568,135973,136095,136115,136140,136214,136220,136377,136428,136693,136868,136918,136955,136976,136999,137033,137162,137166,137167,137371,137435,137436,137552,137631,137824,137829,138014,138037,138051,138052,138071,138170,138298,13830,138314,138343,138466,138534,138536,138537,138564,138649,138692,138713,138828,138829,138836,138837,138888,138889,138977,138979,139007,139008,139071,139085,139143,139152,139162,139166,139214,139239,139302,139334,139637,139803,139841,139843,139846")
                .WithHeaders(new Dictionary<string, string>
                {
                    {"Authorization", "Basic Q09SUE9SQVRFXFVzZXJOYW1lOlBhJCR3MHJk" },
                    {"Accept", "application/json" }
                })
                .Respond(System.Net.HttpStatusCode.OK, "application/json", func60Response300);

            // Fourth 100 batch
            MockHttp.Expect("https://hawscorpp.ameren.com:8443/hrdatahub/v1/employee?employeeId=inList::139847,139851,140139,140349,140388,140422,140477,140502,140514,140556,140625,140634,140642,140842,140889,141098,141205,141232,141261,141378,141379,141401,141447,141509,141543,141557,141609,141613,141616,141619,141751,141753,141756,141773,141782,141783,141837,141856,141896,141899,141908,141920,141923,141924,141926,141983,142007,142073,142074,142144,142146,142173,142256,142339,142342,142365,142392,142408,142409,142411,142412,142481,142485,142486,142488,142491,142494,142495,142496,142497,142498,142499,142500,142502,142503,142505,142575,142718,142719,142784,142813,142832,142854,142856,142857,142858,142893,143118,143119,143147,143220,143221,143229,143230,143249,143258,143276,143483,143485,143566")
                .WithHeaders(new Dictionary<string, string>
                {
                    {"Authorization", "Basic Q09SUE9SQVRFXFVzZXJOYW1lOlBhJCR3MHJk" },
                    {"Accept", "application/json" }
                })
                .Respond(System.Net.HttpStatusCode.OK, "application/json", func60Response400);

            // Fifth 100 batch
            MockHttp.Expect("https://hawscorpp.ameren.com:8443/hrdatahub/v1/employee?employeeId=inList::143567,143569,143570,143571,143572,143574,143575,143576,143766,143767,143771,143772,143808,143833,143835,143836,143837,143848,143899,143907,143919,144050,144051,144099,144134,144136,144140,144175,144176,144177,144178,144181,144244,144245,144257,144284,144285,144286,144466,144503,144536,144583,144602,144611,144667,144751,144813,144832,144833,144849,144871,144877,144878,144903,144948,144966,144967,145106,145113,145115,145150,145199,145213,145264,145290,145354,145721,145722,145840,145841,145843,145964,145965,145971,145972,146043,146044,146045,146046,146047,146423,146453,146528,146604,146605,146820,146889,146989,146997,147014,147046,147047,147048,147049,147050,147084,147223,147296,147337,147362")
                .WithHeaders(new Dictionary<string, string>
                {
                    {"Authorization", "Basic Q09SUE9SQVRFXFVzZXJOYW1lOlBhJCR3MHJk" },
                    {"Accept", "application/json" }
                })
                .Respond(System.Net.HttpStatusCode.OK, "application/json", func60Response500);

            // Sixth 100 batch
            MockHttp.Expect("https://hawscorpp.ameren.com:8443/hrdatahub/v1/employee?employeeId=inList::147444,147484,147575,147724,147784,147804,147822,147823,147897,147898,147899,147900,147901,147985,147990,16460,18247,18636,18843,19096,19190,19353,19462,19824,19911,19932,20229,20327,20492,20722,20815,20837,20851,20871,21140,21601,21747,21749,21750,21781,21905,23378,23459,23567,23630,23693,23728,23869,23955,24070,24276,24277,24580,24670,24758,24823,24880,25078,25243,25349,25359,25492,25507,25993,26073,26102,26161,26284,26288,26487,26511,26575,26610,26693,26836,27031,27040,27092,27226,27276,27302,27355,27406,27820,27950,28113,28191,28291,28406,28475,29261,33816,33819,33944,34007,34075,34316,34324,34549,34572")
                .WithHeaders(new Dictionary<string, string>
                {
                    {"Authorization", "Basic Q09SUE9SQVRFXFVzZXJOYW1lOlBhJCR3MHJk" },
                    {"Accept", "application/json" }
                })
                .Respond(System.Net.HttpStatusCode.OK, "application/json", func60Response600);

            // Seventh 100 batch
            MockHttp.Expect("https://hawscorpp.ameren.com:8443/hrdatahub/v1/employee?employeeId=inList::34601,34648,34685,34686,34720,34771,34776,34857,34893,34915,34956,34966,35164,35169,35241,35311,35313,35441,35576,35777,35898,36667,36858,36861,37717,38162,39317,39376,39388,39408,39476,41157,41293,41333,41341,41459,41531,41672,42090,42339,42362,42521,42625,42876,42897,43140,44228,44268,44337,44402,44420,44464,44489,44502,44517,44532,44596,44659,44669,44682,44786,45486,45899,45972,46000,47258,47357,47576,47618,47892,47942,47947,48023,48671,49029,49528,49692,50134,50458,50811,51140,54739,58432,58483,58562,59183,59185,59195,59228,59429,59447,59558,59579,60398,60994,61109,61138,61283,72431,72470")
                .WithHeaders(new Dictionary<string, string>
                {
                    {"Authorization", "Basic Q09SUE9SQVRFXFVzZXJOYW1lOlBhJCR3MHJk" },
                    {"Accept", "application/json" }
                })
                .Respond(System.Net.HttpStatusCode.OK, "application/json", func60Response700);

            // Last 41 batch
            MockHttp.Expect("https://hawscorpp.ameren.com:8443/hrdatahub/v1/employee?employeeId=inList::78119,78757,79088,79753,79894,80474,81335,81376,81707,82086,82089,82452,82636,83300,84090,84094,84097,84947,84975,86698,86740,86784,88680,89885,90862,91269,91489,91946,91947,91977,91989,92092,92336,92457,92575,92893,93001,93296,94290,95989,96269")
                .WithHeaders(new Dictionary<string, string>
                {
                    {"Authorization", "Basic Q09SUE9SQVRFXFVzZXJOYW1lOlBhJCR3MHJk" },
                    {"Accept", "application/json" }
                })
                .Respond(System.Net.HttpStatusCode.OK, "application/json", func60Response741);
        }

        public MockHttpMessageHandler GetDataHubMock()
        {
            return MockHttp;
        }

    }
}
