Feature: ContactPageTests

Test Cases related to the Contact Page

Background:
	Given The user is on the home page

Scenario: Verify Contact Form Submission
	When The user navigates to the 'Contact' page
	And The user accepts the Alert
	Then the Contact page should load correctly
	When The user fills in the 'FirstName' field with 'FirstName'
	And The user fills in the 'LastName' field with 'LastName'
	And The user fills in the 'Email' field with 'email@gmail.com'
	And The user fills in the 'Company' field with 'Company'
	And The user checks the checkbox 'privacy'
	And The user checks the checkbox 'subscribe'
	And The user clicks on the send button
	Then The user should see a confirmation message

Scenario: Verify Contact Form Email Validations
	When The user navigates to the 'Contact' page
	And The user accepts the Alert
	Then the Contact page should load correctly
	When The user fills in the 'Email' field with 'user@[192.168.1.1]'
	Then Validation message is displayed:'Please enter a valid email address.' for the email field
	When The user fills in the 'Email' field with 'email@domain..com'
	Then Validation message is displayed:'Email must be formatted correctly.' for the email field
	When The user fills in the 'Email' field with 'a@b.c'
	Then Validation message is displayed:'Email must be formatted correctly.' for the email field
	When The user fills in the 'Email' field with ''
	Then Validation message is displayed:'Please complete this required field.' for the email field
