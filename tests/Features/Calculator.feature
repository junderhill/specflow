Feature: Calculator

    Is able to perform various simple calculations.

    Scenario Outline: Addition
        Given Values <First> and <Second>
        When Users calls the Add endpoint
        Then I should received a response of <Sum>
        Examples:
        | First | Second | Sum  |
        | 1 | 1 | 2 |
        | 10 | 20 | 30 |