using ICT3101_Calculator;
using NUnit.Framework;

namespace SpecFlowCalculatorTests.Steps
{
    [Binding]
    public class CalculatorMTBFSteps
    {
        private Calculator _calculator;
        private double _result;

        // Context injection for SpecFlow
        public CalculatorMTBFSteps(Calculator calc)
        {
            _calculator = calc;
        }

        [Given(@"I have a calculator")]
        public void GivenIHaveACalculator()
        {
            // Ensure the calculator is available
        }

        [When(@"I have entered (.*) operational hours and (.*) failures into the calculator and press MTBF")]
        public void WhenIHaveEnteredOperationalHoursAndFailuresIntoTheCalculatorAndPressMTBF(double operationalHours, int failures)
        {
            _result = _calculator.CalculateMTBF(operationalHours, failures);
        }




        [When(@"I have entered (.*) MTBF and (.*) MTTR into the calculator and press Availability")]
        public void WhenIHaveEnteredMTBFAndMTTRIntoTheCalculatorAndPressAvailability(double mtbf, double mttr)
        {
            _result = _calculator.CalculateAvailability(mtbf, mttr);
        }



        [Then(@"the availability result should be (.*)")]
        public void ThenTheAvailabilityResultShouldBe(double expectedResult)
        {
            Assert.AreEqual(expectedResult, _result, 0.0001, "The availability result should be approximately " + expectedResult);
        }


        [Then(@"the availability result should be 'Infinity'")]
        public void ThenTheAvailabilityResultShouldBeInfinity()
        {
            Assert.IsTrue(double.IsPositiveInfinity(_result), "The result should be positive infinity.");
        }

    }
}