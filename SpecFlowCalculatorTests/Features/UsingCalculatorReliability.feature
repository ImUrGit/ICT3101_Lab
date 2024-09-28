Feature: UsingCalculatorReliability
  In order to calculate the Basic Musa model's failures/intensities
  As a Software Quality Metric enthusiast
  I want to use my calculator to do this

@Reliability
Scenario: Calculating current failure intensity (lambda)
  Given I have a calculator
  When I have entered 1000 failures and 500 operational hours into the calculator and press CalculateFailureIntensity
  Then the result should be 2.0

@Reliability
Scenario: Calculating average number of expected failures (mu)
  Given I have a calculator
  When I have entered 1000 failures, 500 operational hours, and 50 expected hours into the calculator and press CalculateExpectedFailures
  Then the result should be 100.0