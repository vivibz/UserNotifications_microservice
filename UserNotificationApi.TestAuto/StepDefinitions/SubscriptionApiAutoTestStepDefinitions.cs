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
        public SubscriptionApiAutoTestStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"that the user id is '([^']*)'")]
        public void GivenThatTheUserIdIs(string id)
        {
            _scenarioContext["EndPoint"] = BASE_URL + "submitSubscription?userId=" + id;
        }

        [Given(@"that notification is '(.*)'")]
        public void GivenThatNotificationIs(string notification)
        {
            switch (notification.ToUpper())
            {
                case "SUBSCRIPTION_PURCHASED":
                    notification = "SUBSCRIPTION_PURCHASED";
                    break;
                case "SUBSCRIPTION_CANCELED":
                    notification = "SUBSCRIPTION_CANCELED";
                    break;
                case "SUBSCRIPTION_RESTARTED":
                    notification = "SUBSCRIPTION_RESTARTED";
                    break;
                default:
                    Assert.Null("Notification invalidated");
                    break;
            }
            Console.WriteLine(notification);
            _scenarioContext["EndPoint"] = _scenarioContext["EndPoint"] + "&notification=" + notification;
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
            SubmitRequest(endpoint);
        }
        #region Private
        private RestResponse SubmitRequest(string endpoint)
        {
            var url = endpoint;
            var request = new RestRequest();

            request.Method = (Method)_scenarioContext["HttpMethod"];

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
