using System;
using TechTalk.SpecFlow;

namespace UserNotificationApi.TestAuto.StepDefinitions
{
    [Binding]
    public class GivenStepDefinitions
    {
        [Given(@"that the endpoint URL is https://localhost:7268/api/User/id")]
        public void GivenThatTheEndpointURLIsHttpsLocalhostApiUserId(int p0)
        {
            throw new PendingStepException();
        }
    }
}
