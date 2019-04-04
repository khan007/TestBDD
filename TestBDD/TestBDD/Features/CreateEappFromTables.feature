Feature: Create EApp From Tables

Background:
Scenario Outline: Login
    Given I login to URL <url>
	Given I input enter login <login>
	Given I input enter password <password>
	When I press <loginButton>
	Then redirects me to <homepage>
Examples:
    | url                     | login   | password    | loginButton | homepage | 
    | http://localhost:50553/ | kvongsav| April12019! | LoginButton | homepage |

@eApp
Scenario Outline: Create eApp current scenario product male
	Given I am on <homePageName>
	When I click on <buttonName> button
	Then a popup appears with list of products
	When I choose <state> in Issue State
	When I enter date of birth <dateOfBirth> (<age>)
	When I select gender <gender>
	When I enter firstname <firstname>
	When I enter lastname <lastname>
	When I select product <product>
	When I click on Create button <createButton>
	Then Get redirected to <product> product    

Examples:
    | homePageName | buttonName | state   | dateOfBirth | age | gender | firstname | lastname | product              | createButton | nextPage |
    |              |            | Alabama | 01/01/1967  | 53  | male   |    John   | Galt     | Eagle Premier Series | Create       |          |
