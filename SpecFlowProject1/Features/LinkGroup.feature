Feature: Link Group 

Scenario: Smoke test

When I open the home page "https://www.linkgroup.com/"
Then the page is displayed
Given I have agreed to the cookie policy
When I select Contact
Then the Contact page is displayed
