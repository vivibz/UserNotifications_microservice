using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace UserNotificationApi.TestAuto.StepDefinitions
{
    [Binding]
    public class SubscriptionApiAutoTestStepDefinitions
    {
        private const string BASE_URL = "https://localhost:7268/api/Subscription/";
        private readonly ScenarioContext _scenarioContext;

        string userId = "";
        string notification = "";

        public SubscriptionApiAutoTestStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"the url is '([^']*)'")]
        public void GivenTheUrlIs(string url)
        {
            _scenarioContext["EndPoint"] = url;
        }

        [Given(@"that the user id is '([^']*)'")]
        public void GivenThatTheUserIdIs(string id)
        {
            _scenarioContext["userId"] = id;
        }


        [Given(@"that notification is '(.*)'")]
        public void GivenThatNotificationIs(string notification)
        {
            Console.WriteLine(notification);
            _scenarioContext["notification"] = notification;
        }
        [Given(@"the calling method '([^']*)'")]
        public void GivenTheCallingMethod(string call)
        {
            var metodo = Method.Post;

            switch (call.ToUpper())
            {
                case "POST":
                    metodo = Method.Post;
                    break;
                case "GET":
                    metodo = Method.Get;
                    break;
                default:
                    Assert.Null("http method not expected");
                    break;
            }
            Console.WriteLine(metodo);
            _scenarioContext["HttpMethod"] = metodo;
        }

        [When(@"submit")]
        public void WhenSubmit()
        {

            var endpoint = (String)_scenarioContext["EndPoint"];
            _scenarioContext["Body"] = "{\"userId\": \"" + _scenarioContext["userId"] + "\"" + "," + "\"notification\":" + "\"" + _scenarioContext["notification"] + "\"" + "}";
            var body = (String)_scenarioContext["Body"];
            SubmitRequest(endpoint, body);
        }
        #region Private
        private RestResponse SubmitRequest(string endpoint, string body)
        {
            var url = endpoint;
            var request = new RestRequest();

            request.Method = (Method)_scenarioContext["HttpMethod"];
            
            if (request.Method == Method.Post)
            {
                request.AddStringBody(body, contentType: "application/json");
            }

            var restClient = new RestClient(url);
            var response = restClient.Execute(request);

            _scenarioContext["Response"] = response;

            return response;
        }
        #endregion
        [Then(@"the submission statuscode '([^']*)'")]
        public void ThenTheSubmissionStatuscodeOK(string statuscode)
        {
            var response = (RestResponse)_scenarioContext["Response"];
            Assert.Equal(statuscode, response.StatusCode.ToString());
        }


        //Usuário por identificador de status
        [Given(@"that the status id is '([^']*)'")]
        public void GivenThatTheStatusIdIs(string id)
        {
            _scenarioContext["EndPoint"] = BASE_URL + "statusId?statusId=" + id;
        }

    }
}
