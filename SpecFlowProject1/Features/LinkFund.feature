Feature: Link Fund Solutions 

Scenario Outline: Investment managers

Given I have opened the Found Solutions page "https://www.linkfundsolutions.co.uk/"
When I view Funds
Then I can select the investment managers for "<Jurisdiction>" investors

Examples:
| Jurisdiction |
| UK           |
| Irish        |
| Swiss        |