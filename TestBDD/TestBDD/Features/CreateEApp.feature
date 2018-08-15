Feature: Create EApp

Background:
    Given I login to URL 'URL'
	Given I input enter login 'login'
	Given I input enter password 'password'
	When I press 'login'
	Then redirects me to 'homepage'

Scenario: Create eApp
	Given I am on 'HomePage'
	When I click on 'eApp' button
	Then a popup appears with list of products
	When I choose 'Alabama' State in Issue State
	When I enter '01011967' Date of Birth (51 age)
	When I select Gender 'male'
	When I enter Firstname 'John'
	When I enter Lastname 'Tremblay'
	When I select 'HMS Plus 100' product
	When I click on Create button 'Create'
	Then Get redirects me to 'homepage'