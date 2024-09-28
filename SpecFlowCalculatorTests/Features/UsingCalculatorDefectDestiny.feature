Feature: UsingCalculatorDefectDensity
  In order to calculate defect density of the system
  As a system quality engineer
  I want to be able to input the total number of defects and SSI into the calculator

@DefectDensity
Scenario: Calculating defect density for a system
  Given I have a calculator
  When I have entered 300 total defects and 500000 SSI into the calculator and press CalculateDefectDensity
  Then the result should be 0.0006
