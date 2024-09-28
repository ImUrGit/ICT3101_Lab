/*
namespace ICT3101_Calculator.UnitTests
{
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            // Arrange
            _calculator = new Calculator();
        }

        // Addition Test
        [Test]
        public void Add_WhenAddingTwoNumbers_ResultEqualToSum()
        {
            // Act
            double result = _calculator.Add(10, 20);
            // Assert
            Assert.That(result, Is.EqualTo(30));
        }

        // Subtraction Test
        [Test]
        public void Subtract_WhenSubtractingTwoNumbers_ResultEqualToDifference()
        {
            // Act
            double result = _calculator.Subtract(20, 10);
            // Assert
            Assert.That(result, Is.EqualTo(10));
        }

        // Multiplication Test
        [Test]
        public void Multiply_WhenMultiplyingTwoNumbers_ResultEqualToProduct()
        {
            // Act
            double result = _calculator.Multiply(10, 20);
            // Assert
            Assert.That(result, Is.EqualTo(200));
        }

        // Division Test (Normal case)
        [Test]
        public void Divide_WhenDividingTwoNumbers_ResultEqualToQuotient()
        {
            // Act
            double result = _calculator.Divide(20, 10);
            // Assert
            Assert.That(result, Is.EqualTo(2));
        }

        // Division Test (Edge case: dividing by zero should return Infinity)
        [Test]
        public void Divide_WhenDividingByZero_ShouldReturnPositiveInfinity()
        {
            // Act
            double result = _calculator.Divide(20, 0);

            // Assert
            Assert.That(double.IsPositiveInfinity(result), Is.True);
        }

        // Division Test (Edge case: zero as numerator should return zero)
        [Test]
        public void Divide_WhenNumeratorIsZero_ShouldReturnZero()
        {
            // Act
            double result = _calculator.Divide(0, 10);
            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        // Division Test (Edge case: both numerator and denominator are zero should return NaN)
        [Test]
        public void Divide_WhenBothNumeratorAndDenominatorAreZero_ShouldThrowArgumentException()
        {
            // Assert that the ArgumentException is thrown
            Assert.That(() => _calculator.Divide(0, 0), Throws.ArgumentException);
        }

        [Test]
        [TestCase(0, 0)] // Expect ArgumentException
        [TestCase(0, 10)] // Expect a result of 0
        [TestCase(10, 0)] // Expect PositiveInfinity or NegativeInfinity
        public void Divide_WithZerosAsInputs_ResultThrowArgumentException(double a, double b)
        {
            if (a == 0 && b == 0)
            {
                // Assert that the ArgumentException is thrown when both inputs are zero
                Assert.That(() => _calculator.Divide(a, b), Throws.ArgumentException);
            }
            else if (b == 0)
            {
                // Assert for PositiveInfinity or NegativeInfinity when dividing by zero
                Assert.That(() => _calculator.Divide(a, b), Is.EqualTo(double.PositiveInfinity).Or.EqualTo(double.NegativeInfinity));
            }
            else
            {
                double result = _calculator.Divide(a, b);
                Assert.That(result, Is.EqualTo(0));
            }
        }

        // Test for Factorial of a Positive Number
        [Test]
        public void Factorial_WhenPositiveNumberGiven_ShouldReturnFactorial()
        {
            // Act
            int result = _calculator.Factorial(5);
            // Assert
            Assert.That(result, Is.EqualTo(120)); // 5! = 120
        }

        // Test for Factorial of Zero
        [Test]
        public void Factorial_WhenZeroGiven_ShouldReturnOne()
        {
            // Act
            int result = _calculator.Factorial(0);
            // Assert
            Assert.That(result, Is.EqualTo(1)); // 0! = 1
        }

        // Test for Negative Input (should throw ArgumentException)
        [Test]
        public void Factorial_WhenNegativeNumberGiven_ShouldThrowArgumentException()
        {
            // Assert
            Assert.That(() => _calculator.Factorial(-5), Throws.ArgumentException);
        }

        // Test for Area of Triangle with Positive Base and Height
        [Test]
        public void AreaOfTriangle_WithPositiveBaseAndHeight_ShouldReturnCorrectArea()
        {
            // Act
            double result = _calculator.AreaOfTriangle(10, 5);
            // Assert
            Assert.That(result, Is.EqualTo(25)); // (1/2) * 10 * 5 = 25
        }

        // Test for Area of Triangle with Zero Base or Height
        [Test]
        public void AreaOfTriangle_WithZeroBaseOrHeight_ShouldReturnZero()
        {
            // Act
            double result = _calculator.AreaOfTriangle(0, 5);
            // Assert
            Assert.That(result, Is.EqualTo(0));

            // Act
            result = _calculator.AreaOfTriangle(10, 0);
            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        // Test for Area of Triangle with Negative Base or Height
        [Test]
        public void AreaOfTriangle_WithNegativeBaseOrHeight_ShouldThrowArgumentException()
        {
            // Assert
            Assert.That(() => _calculator.AreaOfTriangle(-10, 5), Throws.ArgumentException);
            Assert.That(() => _calculator.AreaOfTriangle(10, -5), Throws.ArgumentException);
        }

        // Test for Area of Circle with Positive Radius
        [Test]
        public void AreaOfCircle_WithPositiveRadius_ShouldReturnCorrectArea()
        {
            // Act
            double result = _calculator.AreaOfCircle(10); // radius = 10
            // Assert
            Assert.That(result, Is.EqualTo(Math.PI * 100).Within(0.001)); // π * 10^2 = 314.159...
        }

        // Test for Area of Circle with Zero Radius
        [Test]
        public void AreaOfCircle_WithZeroRadius_ShouldReturnZero()
        {
            // Act
            double result = _calculator.AreaOfCircle(0); // radius = 0
            // Assert
            Assert.That(result, Is.EqualTo(0)); // The area should be 0
        }

        // Test for Area of Circle with Negative Radius
        [Test]
        public void AreaOfCircle_WithNegativeRadius_ShouldThrowArgumentException()
        {
            // Assert
            Assert.That(() => _calculator.AreaOfCircle(-5), Throws.ArgumentException); // radius = -5
        }

        [Test]
        public void UnknownFunctionA_WhenGivenTest0_Result()
        {
            // Act
            double result = _calculator.UnknownFunctionA(5, 5);
            // Assert
            Assert.That(result, Is.EqualTo(120));
        }
        [Test]
        public void UnknownFunctionA_WhenGivenTest1_Result()
        {
            // Act
            double result = _calculator.UnknownFunctionA(5, 4);
            // Assert
            Assert.That(result, Is.EqualTo(120));
        }
        [Test]
        public void UnknownFunctionA_WhenGivenTest2_Result()
        {
            // Act
            double result = _calculator.UnknownFunctionA(5, 3);
            // Assert
            Assert.That(result, Is.EqualTo(60));
        }

        [Test]
        public void UnknownFunctionA_WhenGivenTest3_ResultThrowArgumnetException()
        {
            // Act
            // Assert
            Assert.That(() => _calculator.UnknownFunctionA(-4, 5), Throws.ArgumentException);
        }
        [Test]
        public void UnknownFunctionA_WhenGivenTest4_ResultThrowArgumnetException()
        {
            // Act
            // Assert
            Assert.That(() => _calculator.UnknownFunctionA(4, 5), Throws.ArgumentException);
        }

        [Test]
        public void UnknownFunctionB_WhenGivenTest0_Result()
        {
            // Act
            double result = _calculator.UnknownFunctionB(5, 5);
            // Assert
            Assert.That(result, Is.EqualTo(1));
        }
        [Test]
        public void UnknownFunctionB_WhenGivenTest1_Result()
        {
            // Act
            double result = _calculator.UnknownFunctionB(5, 4);
            // Assert
            Assert.That(result, Is.EqualTo(5));
        }
        [Test]
        public void UnknownFunctionB_WhenGivenTest2_Result()
        {
            // Act
            double result = _calculator.UnknownFunctionB(5, 3);
            // Assert
            Assert.That(result, Is.EqualTo(10));
        }
        [Test]
        public void UnknownFunctionB_WhenGivenTest3_ResultThrowArgumnetException()
        {
            // Act
            // Assert
            Assert.That(() => _calculator.UnknownFunctionB(-4, 5), Throws.ArgumentException);
        }
        [Test]
        public void UnknownFunctionB_WhenGivenTest4_ResultThrowArgumnetException()
        {
            // Act
            // Assert
            Assert.That(() => _calculator.UnknownFunctionB(4, 5), Throws.ArgumentException);
        }

    }
}
*/
