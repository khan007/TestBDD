Feature: Create EApp

Background:
    Given I login to URL 'URL'
	Given I input enter login 'kvongsav'
	Given I input enter password 'Americo2$'
	When I press 'login'
	Then redirects me to 'homepage'

@Eagle Premier
@male
Scenario: Create eApp current scenario product male
	Given I am on 'HomePage'
	When I click on 'eApp' button
	Then a popup appears with list of products
	When I choose 'Alabama' State in Issue State
	When I enter '01011967' Date of Birth (51 age)
	When I select Gender 'Male'
	When I enter Firstname 'Tim'
	When I enter Lastname 'Tremblay'
	When I select 'Eagle Premier Series' product
	When I click on Create button 'Create'
	Then Get redirected to 'page introduction' product 'Eagle Premier Series'

    


#@HMS Plus 100
#@female
#Scenario: Create eApp HMS Plus 100 female
#	Given I am on 'HomePage'
#	When I click on 'eApp' button
#	Then a popup appears with list of products
#	When I choose 'Alabama' State in Issue State
#	When I enter '01011967' Date of Birth (51 age)
#	When I select Gender 'Female'
#	When I enter Firstname 'Celine'
#	When I enter Lastname 'Tremblay'
#	When I select 'HMS Plus 100' product
#	When I click on Create button 'Create'
#	Then Get redirects me to 'homepage'