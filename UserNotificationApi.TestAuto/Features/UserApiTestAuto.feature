Feature: User

A short summary of the feature

@tag1
Scenario: Get users by an identifier
	Given that user id is 1
	And the method is 'GET'
	When to call the service
	Then then statuscode of the response should be 'OK'

@tag2
Scenario: Create a user
	Given the user creation url is 'https://localhost:7268/api/User/create'
	And fullName is 'Ana Sousa'
	And the method is 'POST'
	When I send create user request
	Then then statuscode of the response should be 'OK'