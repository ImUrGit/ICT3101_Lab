using ICT3101_Calculator;
using NUnit.Framework;

namespace SpecFlowCalculatorTests.Steps
{
    [Binding]
    [Scope(Tag = "Addition")] // Scope the steps only to addition operations
    public class AdditionSteps
    {
        private readonly Calculator _calculator;
        private double _result;

        public AdditionSteps(Calculator calc) // Context Injection for Calculator
        {
            _calculator = calc;
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press add")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressAdd(int value1, int value2)
        {
            _result = _calculator.Add(value1, value2);
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int expectedResult)
        {
            Assert.AreEqual(expectedResult, _result);
        }
    }
}