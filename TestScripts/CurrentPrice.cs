using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Newtonsoft.Json;
using System.Net;
using APIAutomation.ResponseClass;

namespace APIAutomation.TestScripts
{
    [TestClass]
    public class CurrentPrice
    {
        private readonly RestClient client;
        public TestContext TestContext { get; set; }

        public CurrentPrice()
        {
            // Initialize RestClient with the base URL of the API
            client = new RestClient("https://api.coindesk.com");
        }
        [TestMethod]
        public void API_CheckCurrentPrice()
        {
            // GET request to specific endpoint
            var request = new RestRequest(TestContext.Properties["RestEndPoint"].ToString(), Method.Get);            
            var response = client.Execute(request);     // Execute the request
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);    // Assert status code OK

            // Assert if BPI's are exists or not
            Assert.IsTrue(response.Content.Split("bpi")[1].Contains(TestContext.Properties["Bpi1Code"].ToString()));
            Assert.IsTrue(response.Content.Split("bpi")[1].Contains(TestContext.Properties["Bpi2Code"].ToString()));
            Assert.IsTrue(response.Content.Split("bpi")[1].Contains(TestContext.Properties["Bpi3Code"].ToString()));

            // Deserializing the response
            CurrentPriceResponse data = JsonConvert.DeserializeObject<CurrentPriceResponse>(response.Content);

            // Perform further assertions on the response data
            Assert.IsNotNull(data);
            Assert.AreEqual(TestContext.Properties["GbpDescription"].ToString(), data.Bpi.GBP.Description);
        }
    }
}