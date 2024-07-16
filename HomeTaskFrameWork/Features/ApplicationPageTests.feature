Feature: Application Page

Test Cases related to the Application Page

Background:
	Given The user is on the home page

Scenario: Verify required field validations on the job application
	When The user navigates to the 'Careers' page
	Then the Careers page should load correctly
	And The user should see job listings displayed
	When The user clicks on a 'Automation Quality Assurance Engineer' job listing
	Then the job details should be displayed
	When The user clicks on the apply button
	And The user switches to the last opened tab
	When The user clicks on the submit application button
	Then Validation messages are displayed
