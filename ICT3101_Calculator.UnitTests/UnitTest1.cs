namespace ICT3101_Calculator.UnitTests
{
    public class CalculatorTests
    {
        private Calculator _calculator;
        private string originalPath = "/Users/alainpierre/Projects/ICT3101_Calculator/ICT3101_Calculator/MagicNumbers.txt";
        private string backupPath;

        [SetUp]
        public void Setup()
        {
            // Arrange
            _calculator = new Calculator();

            // Construct the relative path to the MagicNumbers.txt file
            string relativePath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "ICT3101_Calculator", "MagicNumbers.txt");

            // Resolve to the absolute path
            originalPath = Path.GetFullPath(relativePath);
            backupPath = originalPath + ".bak";

            // Check if the file exists, if not throw a meaningful exception
            if (!File.Exists(originalPath))
            {
                throw new FileNotFoundException("MagicNumbers.txt file is missing at " + originalPath);
            }

            // Backup the original file before each test
            if (!File.Exists(backupPath))
            {
                File.Copy(originalPath, backupPath); // Backup the file if not already backed up
            }
        }


        [TearDown]
        public void TearDown()
        {
            // Restore the original file after each test
            if (File.Exists(backupPath))
            {
                if (File.Exists(originalPath))
                {
                    File.Delete(originalPath); // Delete the modified file
                }
                File.Move(backupPath, originalPath); // Restore the backup
            }
        }

        // Previously Commented-Out Tests (re-commented)
        // -------------------------------

        /*
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
        */

        // Lab 4 Tests
        // -------------------------------

        // Positive Test Case: Valid Input
        [Test]
        public void GenMagicNum_WithValidInput_ReturnsCorrectMagicNumber()
        {
            IFileReader fileReader = new FileReader();
            
            double result = _calculator.GenMagicNum(1, fileReader);
            
            Assert.That(result, Is.EqualTo(96));
        }

        // Negative Test Case: Out of Bounds Input
        [Test]
        public void GenMagicNum_WithOutOfBoundsInput_ReturnsZero()
        {
            IFileReader fileReader = new FileReader();
            
            double result = _calculator.GenMagicNum(10, fileReader); 
            
            Assert.That(result, Is.EqualTo(0)); 
        }

        // Exceptional Test Case: File Missing
        [Test]
        public void GenMagicNum_FileMissing_ThrowsFileNotFoundException()
        {
            IFileReader fileReader = new FileReader();
            
            // If backup file exists, delete it
            if (File.Exists(backupPath))
            {
                File.Delete(backupPath);
            }

            // Temporarily move the file to simulate the missing file scenario
            File.Move(originalPath, backupPath);
            
            Assert.Throws<FileNotFoundException>(() => _calculator.GenMagicNum(1, fileReader));

            // Restore the file after the test (Handled by TearDown)
        }

        // Exceptional Case: Invalid Content in File
        [Test]
        public void GenMagicNum_WithInvalidContent_ThrowsFormatException()
        {
            IFileReader fileReader = new FileReader();
            
            // Write the invalid content to the file
            string invalidContent = "12\ninvalid\n3\n";
            File.WriteAllText(originalPath, invalidContent);

            // Act & Assert
            Assert.Throws<FormatException>(() => _calculator.GenMagicNum(1, fileReader));

            // File is restored after the test by TearDown
        }
    }
}
