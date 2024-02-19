Feature: TerminalMode


@mytag
Scenario: Switch to terminal mode
	Given I am on Crewmeister time-tracking overview page
		And I click on the "Switch this device into terminal mode" button
		And I select "3-Column-Terminal without password/PIN" option
		And I click on the "Switch this device into terminal mode" button on modal
		And I confirm by clicking on the "Yes, enter terminal mode now" button
	When I move "Jose Barron TESTING " user to "Clocked in" for "10" seconds
		And I move "Jose Barron TESTING " user to "Break" for "5" seconds
		And I move "Jose Barron TESTING " user to "Clocked out"
	Then I should see the "You're clocked out" message on the right corner popup
