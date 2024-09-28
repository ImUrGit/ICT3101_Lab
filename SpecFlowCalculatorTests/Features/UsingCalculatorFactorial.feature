Feature: UsingCalculatorFactorial
	In order to calculate factorials
	As a user
	I want to use a calculator to compute the factorial of a number

@Factorial
Scenario: Calculating the factorial of a positive number
  Given I have a calculator
  When I have entered 5 into the calculator and press factorial
  Then the result should be 120

@Factorial
Scenario: Calculating the factorial of zero
  Given I have a calculator
  When I have entered 0 into the calculator and press factorial
  Then the result should be 1