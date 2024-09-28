using ICT3101_Calculator;
using NUnit.Framework;

namespace SpecFlowCalculatorTests.Steps
{
    [Binding]
    [Scope(Tag = "Factorial")] // Scope the steps only to factorial operations
    public class FactorialSteps
    {
        private readonly Calculator _calculator;
        private double _result;

        public FactorialSteps(Calculator calc) // Context Injection for Calculator
        {
            _calculator = calc;
        }

        [When(@"I have entered (.*) into the calculator and press factorial")]
        public void WhenIHaveEnteredIntoTheCalculatorAndPressFactorial(int value)
        {
            _result = _calculator.Factorial(value);
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int expectedResult)
        {
            Assert.AreEqual(expectedResult, _result);
        }
    }
}