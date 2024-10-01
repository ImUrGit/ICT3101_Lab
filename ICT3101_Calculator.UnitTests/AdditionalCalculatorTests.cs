using Moq;

namespace ICT3101_Calculator.UnitTests;

public class AdditionalCalculatorTests
{
    private Calculator _calculator;
    private Mock<IFileReader> _mockFileReader;
    
    [SetUp]
    public void Setup()
    {
        _mockFileReader = new Mock<IFileReader>();
        _mockFileReader.Setup(fr =>
            fr.Read("MagicNumbers.txt")).Returns(new string[2]{"42","42"});
        _calculator = new Calculator();
    }
    
    [Test]
    public void GenMagicNum_WithValidInput_ReturnsCorrectMagicNumber()
    {
        // Act
        double result = _calculator.GenMagicNum(1, _mockFileReader.Object);

        // Assert
        Assert.That(result, Is.EqualTo(84)); // Mock value 42 doubled is 84
    }

    [Test]
    public void GenMagicNum_WithOutOfBoundsInput_ReturnsZero()
    {
        // Act
        double result = _calculator.GenMagicNum(10, _mockFileReader.Object); // Out of bounds

        // Assert
        Assert.That(result, Is.EqualTo(0)); // Expect 0 since index is out of bounds
    }

    [Test]
    public void GenMagicNum_FileMissing_ThrowsFileNotFoundException()
    {
        // Arrange
        _mockFileReader.Setup(fr => fr.Read(It.IsAny<string>())).Throws<FileNotFoundException>();

        // Act & Assert
        Assert.Throws<FileNotFoundException>(() => _calculator.GenMagicNum(1, _mockFileReader.Object));
    }

    [Test]
    public void GenMagicNum_WithInvalidContent_ThrowsFormatException()
    {
        // Arrange
        _mockFileReader.Setup(fr => fr.Read("MagicNumbers.txt"))
            .Returns(new string[] { "42", "invalid" }); // Mock invalid content

        // Act & Assert
        Assert.Throws<FormatException>(() => _calculator.GenMagicNum(1, _mockFileReader.Object));
    }
}