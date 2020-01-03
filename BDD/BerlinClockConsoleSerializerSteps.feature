Feature: BerlinClockConsoleSerializerSteps
	In order to print the clock state in a console
	As a developer
	I want the clock state to be converted to a string

Scenario: All lights on
	Given I have all lights turned on
	When I serialize the state
	Then the output should look like
"""
Y
RRRR
RRRR
YYRYYRYYRYY
YYYY
"""

Scenario: All lights off
	Given I have all lights turned off
	When I serialize the state
	Then the output should look like
"""
O
OOOO
OOOO
OOOOOOOOOOO
OOOO
"""