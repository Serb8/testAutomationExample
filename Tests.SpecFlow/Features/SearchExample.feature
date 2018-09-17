Feature: SearchExample
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Browser:Debug
@Browser:DebugIpad
Scenario Outline: Validate title after search contains query
	Given I have opened /
	When I search <query>
	Then Browser title contains <query>
	Examples: 
	| query  |
	| unickq |
	| google |

@Browser:Debug
@Browser:DebugIpad
Scenario Outline: Validate search field is set after query
	Given I have opened /
	When I search <query>
	Then Search query should be equal to <query>
	Examples: 
	| query  |
	| unickq |