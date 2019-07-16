Feature: Hello name

    In order to be greeted
    As a normal user
    I want to be greeted by name

Scenario: Greets me by name
    Given I have provided my name
    When I send the request
    Then the result should be Hello Name

Scenario: Greets me when I'm anonymous
    Given I have not provided my name
    When I send the request
    Then the result should be Hello
