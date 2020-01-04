Feature: TimeParser
	As a developer
	I want to parse a valid time string and an exception to be thrown if the string is not a valid time.

Scenario: Parse a valid 6 digit time
	When I parse "12:13:14"
	Then the hour should be 12
	And the minutes should be 13
	And the seconds should be 14

Scenario: Parse an hour less than 10
	When I parse "9:13:14"
	Then the hour should be 9
	And the minutes should be 13
	And the seconds should be 14

Scenario: Parse an hour PM
	When I parse "14:13:14"
	Then the hour should be 14
	And the minutes should be 13
	And the seconds should be 14

Scenario: Throw exception when hours consist of 3 digits
	When I parse "009:13:14"
	Then exception should be thrown

Scenario: Throw exception when minutes consist of 3 digits
	When I parse "9:013:14"
	Then exception should be thrown

Scenario: Throw exception when seconds consist of 3 digits
	When I parse "9:13:014"
	Then exception should be thrown

Scenario: Throw exception when hours greater than 24
	When I parse "24:00:00"
	Then the hour should be 24
	And the minutes should be 0
	And the seconds should be 0

Scenario: Throw exception when hours greater than 23 and minutes greater than 0
	When I parse "24:00:01"
	Then exception should be thrown

Scenario: Throw exception when hours greater than 23 and hours greater than 0
	When I parse "24:01:00"
	Then exception should be thrown

Scenario: Throw exception when minutes greater than 59
	When I parse "11:60:00"
	Then exception should be thrown

	Scenario: Throw exception when seconds greater than 59
	When I parse "11:23:60"
	Then exception should be thrown