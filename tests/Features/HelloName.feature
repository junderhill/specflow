Feature: Hello name

    In order to be greeted
    As a normal user
    I want to be greeted by name

Scenario: Greets me when I'm anonymous
    Given I have not provided my name
    When I send the request
    Then the result should just be Hello

Scenario Outline: Greets me by name
    Given I have provided a name <Name>
    When I send the request
    Then the result should be <Greeting>
	Examples:
	| Name	|	Greeting	|
	| Jason	|	"Hello Jason"	|
	| Dave	|	"Hello Dave"	|
	| Allan |	"Hello Allan"	|
