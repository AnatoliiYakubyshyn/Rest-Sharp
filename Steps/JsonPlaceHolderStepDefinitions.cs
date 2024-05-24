using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace Specflow_restSharp.Steps
{
    [Binding]
    public sealed class JsonPlaceHolderStepDefinitions
    {

        private RestClient restClient;

        private RestResponse response;

        private JObject payload;

        private RestRequest restRequest;

        public JsonPlaceHolderStepDefinitions()
        {
        }

        [Given("url is \"(.*)\"")]
        public void GivenUrlIs(string url)
        {
            restClient = new RestClient(url);
            payload = new JObject();
        }

        [Given("the body is \"(.*)\"")]
        public void GivenBodyIs(string body)
        {
            payload.Add("body", body);
        }

        [Given("the title is \"(.*)\"")]
        public void AndTheTitleIs(string title) {
            payload.Add("title",title);
        }

        [When("Post request send")]
        public void WhenPostRequestSend() {
            restRequest = new RestRequest();
            restRequest.AddStringBody(payload.ToString(),DataFormat.Json);
            response = restClient.PostAsync(restRequest).Result;
        }

        [Then("status code is (.*)")]
        public void ThenStatusCodeIs(int statusCode) {
            Assert.AreEqual(statusCode,((int)response.StatusCode));
        } 



    }
}
