Feature: UserApiTest

A short summary of the feature

@tag1
Scenario: Get customer by an identifier
	Given that the endpoint URL is https://localhost:7268/api/User/id
	And the method is 'GET'
	When to call the service
	Then then statuscode of the response should be 'OK'
