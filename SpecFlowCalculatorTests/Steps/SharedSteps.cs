using ICT3101_Calculator;
using TechTalk.SpecFlow;

namespace SpecFlowCalculatorTests.Steps
{
    [Binding]
    public class SharedSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Calculator _calculator;

        public SharedSteps(ScenarioContext scenarioContext, Calculator calculator)
        {
            _scenarioContext = scenarioContext;
            _calculator = calculator;
        }

        // Use Scope to differentiate based on tags
        [Given(@"I have a calculator")]
        [Scope(Tag = "Addition")]  // Apply only when the @Addition tag is present
        public void GivenIHaveACalculatorForAddition()
        {
            // Calculator for addition tests
        }

        [Given(@"I have a calculator")]
        [Scope(Tag = "Divisions")]  // Apply only when the @Divisions tag is present
        public void GivenIHaveACalculatorForDivision()
        {
            // Calculator for division tests
        }

        [Given(@"I have a calculator")]
        [Scope(Tag = "Factorial")]  // Apply only when the @Factorial tag is present
        public void GivenIHaveACalculatorForFactorial()
        {
            // Calculator for factorial tests
        }

        [Given(@"I have a calculator")]
        [Scope(Tag = "Availability")]  // Apply only when the @Availability tag is present
        public void GivenIHaveACalculatorForAvailability()
        {
            // Calculator for MTBF and Availability tests
        }
        
        [Given(@"I have a calculator")]
        [Scope(Tag = "Reliability")]  // Apply only when the @Availability tag is present
        public void GivenIHaveACalculatorForReliability()
        {
            // --
        }
        
        [Given(@"I have a calculator")]
        [Scope(Tag = "DefectDensity")]  // Apply only when the @Availability tag is present
        public void GivenIHaveACalculatorForDefectDensity()
        {
            // --
        }
    }
}