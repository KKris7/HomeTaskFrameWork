Feature: HomePageTests

Test Cases related to the Home Page

Background:
	Given The user is on the home page

Scenario: Verify I am on Home Page
	Then the home page should load within '5' seconds

Scenario: Verify Navigation Menu Items
	Then the navigation menu items should be displayed 'About, Services, Customers, Nearsurance, Resources, Careers'

Scenario: Verify About Menu Items
	Then the items of About menu dropdown should be displayed 'Our brands,Our promises,Our leadership'

Scenario: Verify Presence of Footer Section
	Then the footer section should be present
	And it should contain the social media links

Scenario: Verify Search Functionality
	When The user enter a '<searchWord>' in the search input field
	And The user press Enter
	Then the search results page should display '<searchWord>' results
Examples:
	| searchWord    |
	| QA automation |
	| no resultt    |
	| Software test |