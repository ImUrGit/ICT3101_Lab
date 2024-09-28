using ICT3101_Calculator;
using NUnit.Framework;

namespace SpecFlowCalculatorTests.Steps
{
    [Binding]
    public class CalculatorDefectDensitySteps
    {
        private Calculator _calculator;
        private double _result;

        // Context injection for SpecFlow
        public CalculatorDefectDensitySteps(Calculator calc)
        {
            _calculator = calc;
        }

        [Given(@"I have a calculator")]
        public void GivenIHaveACalculator()
        {
            // Ensure the calculator is available
        }

        [When(@"I have entered (.*) total defects and (.*) SSI into the calculator and press CalculateDefectDensity")]
        public void WhenIHaveEnteredTotalDefectsAndSSIIntoTheCalculatorAndPressCalculateDefectDensity(int totalDefects, double ssi)
        {
            _result = _calculator.CalculateDefectDensity(totalDefects, ssi);
        }

        [Then(@"the result should be (.*)")]
        [Scope(Tag = "DefectDensity")]
        public void ThenTheResultShouldBe(double expectedResult)
        {
            Assert.AreEqual(expectedResult, _result, 0.0001, "The result should be approximately " + expectedResult);
        }
    }
}