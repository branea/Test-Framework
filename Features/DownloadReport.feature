Feature: DownloadReport


@mytag
Scenario: Download the reports with data
	Given I am on Crewmeister time-tracking overview page
		And I go to the time tracking reports page
		And I search for the team "QA Team" in the Team dropdown
	When I select the checkbox for the user with name "Jose Barron TESTING"
		And I click on the "Download" button
	Then I should see a popup with the message: '<modalMessage>'
Examples:
| modalMessage                                                                                                                                                    |
| Your report has been successfully requested. It can take a few minutes until the file is available. The file will be available in the news and download center. |