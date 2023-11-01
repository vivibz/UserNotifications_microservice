Feature: SubscriptionApiAutoTest

A short summary of the feature

@tag3
Scenario: Submit subscription user purchased 
	Given that the user id is '1002'
	And that notification is 'SUBSCRIPTION_PURCHASED'
	And the calling method 'POST'
	When submit 
	Then the submission statuscode 'OK'

@tag4
Scenario: Submit subscription user restarted
	Given that the user id is '1002'
	And that notification is 'SUBSCRIPTION_RESTARTED'
	And the calling method 'POST'
	When submit 
	Then the submission statuscode 'OK'
@tag5
Scenario: Submit subscription user canceled
	Given that the user id is '1002'
	And that notification is 'SUBSCRIPTION_CANCELED'
	And the calling method 'POST'
	When submit 
	Then the submission statuscode 'OK'

@tag6
Scenario: Get users by status identifier
	Given that the status id is '1'
	And the calling method 'GET'
	When to call the service
	Then the submission statuscode 'OK'