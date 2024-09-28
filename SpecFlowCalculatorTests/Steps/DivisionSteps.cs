using ICT3101_Calculator;
using NUnit.Framework;

namespace SpecFlowCalculatorTests.Steps
{
    [Binding]
    [Scope(Tag = "Divisions")] // Scope the steps only to division operations
    public class DivisionSteps
    {
        private readonly Calculator _calculator;
        private double _result;

        public DivisionSteps(Calculator calc) // Context Injection for Calculator
        {
            _calculator = calc;
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press divide")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressDivide(double num1, double num2)
        {
            _result = _calculator.Divide(num1, num2);
        }

        [Then(@"the division result should be (.*)")]
        public void ThenTheDivisionResultShouldBe(double expectedResult)
        {
            Assert.AreEqual(expectedResult, _result);
        }

        [Then(@"the division result equals positive_infinity")]
        public void ThenTheDivisionResultEqualsPositiveInfinity()
        {
            Assert.IsTrue(double.IsPositiveInfinity(_result));
        }
    }
}