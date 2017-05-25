Feature: Search
	Everything related to google search

Scenario: Make a google search
	Given I have opened a chrome web browser with "http://google.com" url
	 When I type "selenium" in the search field
	 Then I should see search results

Scenario: Click google images
	Given I have opened a chrome web browser with "http://google.com" url
	 When I type "selenium" in the search field
	 When I click Images
	  And I navigate back
	 Then I should see search results
	 