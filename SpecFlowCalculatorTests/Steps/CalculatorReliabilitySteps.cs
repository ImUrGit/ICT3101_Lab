using ICT3101_Calculator;
using NUnit.Framework;

namespace SpecFlowCalculatorTests.Steps
{
    [Binding]
    public class CalculatorReliabilitySteps
    {
        private Calculator _calculator;
        private double _result;

        // Inject the calculator for context sharing
        public CalculatorReliabilitySteps(Calculator calc)
        {
            _calculator = calc;
        }

        [Given(@"I have a calculator")]
        public void GivenIHaveACalculator()
        {
            // Calculator is injected
        }

        [When(@"I have entered (.*) failures and (.*) operational hours into the calculator and press CalculateFailureIntensity")]
        public void WhenIHaveEnteredFailuresAndOperationalHoursIntoTheCalculatorAndPressCalculateFailureIntensity(double failures, double operationalHours)
        {
            _result = _calculator.CalculateFailureIntensity(failures, operationalHours);
        }

        [When(@"I have entered (.*) failures, (.*) operational hours, and (.*) expected hours into the calculator and press CalculateExpectedFailures")]
        public void WhenIHaveEnteredFailuresOperationalHoursAndExpectedHoursIntoTheCalculatorAndPressCalculateExpectedFailures(double failures, double operationalHours, double expectedHours)
        {
            _result = _calculator.CalculateExpectedFailures(failures, operationalHours, expectedHours);
        }

        [Then(@"the result should be (.*)")]
        [Scope(Tag = "Reliability")]
        public void ThenTheResultShouldBe(double expectedResult)
        {
            Assert.AreEqual(expectedResult, _result, 0.0001, "The result should be approximately " + expectedResult);
        }
    }
}