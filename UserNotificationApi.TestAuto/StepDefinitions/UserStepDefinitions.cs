using RestSharp;
using System;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using TechTalk.SpecFlow;

namespace UserNotificationApi.TestAuto.StepDefinitions
{
    [Binding]
    public class UserStepDefinitions
    {
        private const string BASE_URL = "https://localhost:7268/api/User/id?id=";

        private readonly ScenarioContext _scenarioContext;
        public UserStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"that user id is (.*)")]
        public void GivenThatTheEndpointUrlIsHttpsLocalhostApiUserId(string id)
        {
            _scenarioContext["EndPoint"] = BASE_URL + id;
        }
        [Given(@"the method is '(.*)'")]
        public void GivenTheMethodIs(string call)
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
    [When(@"to call the service")]
    public void WhenToCallTheService()
    {
        var endpoint = (String)_scenarioContext["EndPoint"];
        ExecuteRequest(endpoint);
    }

    #region Private
    private RestResponse ExecuteRequest(string endpoint)
    {
        var url = endpoint;

        var request = new RestRequest();

        request.Method = (Method)_scenarioContext["HttpMethod"];

        //request.Parameters.RemoveParameter();

            //if(request.Method == Method.Post)
            //{
            //    var json = (String)_scenarioContext["Data"];

            //    if (!String.IsNullOrWhiteSpace(json))
            //        request.AddParameter("application/json", json, ParameterType.RequestBody);
            //}
        var restClient = new RestClient(url);
        var response = restClient.Execute(request);

        _scenarioContext["Response"] = response;

        return response;
    }
    #endregion

        [Then(@"then statuscode of the response should be '(.*)'")]
    public void ThenThenStatuscodeOfTheResponseShouldBe(string ok)
    {
        var response = (RestResponse)_scenarioContext["Response"];

        //string errorMessage;

        //switch (response.StatusCode)
        //{
        //    case HttpStatusCode.InternalServerError:
        //        case HttpStatusCode.NotFound:
        //        errorMessage = "ResponseUri: " + response.ResponseUri;
        //        break;
        //   case HttpStatusCode.Forbidden:
        //        var auth = response.Request.Parameters.Where(x => x.Name == "Authorization").FirstOrDefault();
        //    errorMessage = "Authorization: " + (auth != null ? auth.Value : "none");
        //    break;
        //    default:
        //        errorMessage = response.Content;
        //        break;
        //}
        Assert.Equal(ok, response.StatusCode.ToString());
    }

        //user creation test

        [Given(@"the user creation url is '([^']*)'")]
        public void GivenTheUserCreationUrlIs(string url)
        {
            _scenarioContext["EndPoint"] = url;
        }

        [Given(@"fullName is '(.*)'")]
        public void GivenFullNameIs(string fullname)
        {
            _scenarioContext["Body"] = "{\"fullName\": \"" + fullname + "\"}";
        }

        [When(@"I send create user request")]
        public void WhenISendCreateUserRequest()
        {
            var endpoint = (String)_scenarioContext["EndPoint"];
            var body = (String)_scenarioContext["Body"];
            ExecuteRequestUser(endpoint, body);
        }

        #region Private
        private RestResponse ExecuteRequestUser(string endpoint, string? body = null)
        {
           
            var url = endpoint;

            var request = new RestRequest();

            request.Method = (Method)_scenarioContext["HttpMethod"];

           
            //request.Parameters.RemoveParameter();
            //_scenarioContext["Data"] = request.AddJsonBody(request);
            //VEr como adiciona parametro na boody, ver documentação
            if (request.Method == Method.Post)
            {
                request.AddStringBody(body, contentType: "application/json");
                //request.AddParameter("application/json", JsonSerializer.Serialize(body), ParameterType.RequestBody);
            }
            var restClient = new RestClient(url);
            var response = restClient.Execute(request); 

            _scenarioContext["Response"] = response;

            return response;
        }
        #endregion

        [Then(@"then the statuscode created user is (.*)")]
        public void ThenValidateUserIsCreated(string created)
        {
            var response = (RestResponse)_scenarioContext["Response"];
            Assert.Equal(created, response.StatusCode.ToString());
        }

    }

}

