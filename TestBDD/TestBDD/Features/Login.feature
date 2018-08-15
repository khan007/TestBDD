Feature: Login

Scenario: Login to homepage
	Given I login to URL 'URL'
	Given I input enter login 'login'
	Given I input enter password 'password'
	When I press 'login'
	Then redirects me to 'page'