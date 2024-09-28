Feature: UsingCalculatorAvailability
In order to calculate MTBF and Availability
As someone who struggles with math
I want to be able to use my calculator to do this

    @Availability
    Scenario: Calculating MTBF
        Given I have a calculator
        When I have entered 1200 operational hours and 3 failures into the calculator and press MTBF
        Then the availability result should be 400

    @Availability
    Scenario: Calculating Availability
        Given I have a calculator
        When I have entered 400 MTBF and 100 MTTR into the calculator and press Availability
        Then the availability result should be 0.8

    # Additional
#    @Availability
#    Scenario: Calculating MTBF for no failures
#        Given I have a calculator
#        When I have entered 1500 operational hours and 0 failures int2o the calculator and press MTBF
#        Then the availability result should be 'Infinity'

    @Availability
    Scenario: Calculating Availability with zero MTTR
        Given I have a calculator
        When I have entered 400 MTBF and 0 MTTR into the calculator and press Availability
        Then the availability result should be 1

