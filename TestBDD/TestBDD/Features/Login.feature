Feature: Login
@ignore 
Scenario: Login to homepage
	Given I login to URL 'URL'
	Given I input enter login 'login'
	Given I input enter password 'password'
	When I press 'login'
	Then redirects me to 'homepage'

#Scenario Outline: Login
#    Given I login to URL <url>
#	Given I input enter login <login>
#	Given I input enter password <password>
#	When I press <loginButton>
#	Then redirects me to <homepage>
#Examples:
#    | url                     | login   | password    | loginButton | homepage | 
#    | http://localhost:50553/ | kvongsav| April12019! | LoginButton | homepage |
