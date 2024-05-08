using Services;

namespace XunitTest_Sample
{
    public class CalculatorTests
    {
        [Fact]
        public void TestAddition()
        {
            // Arrange
            Calculator calculator = new Calculator();

            // Act
            int result = calculator.Add(3, 5);

            // Assert
            Assert.Equal(8, result);
        }

        [Fact]
        public void TestSubtraction()
        {
            // Arrange
            Calculator calculator = new Calculator();

            // Act
            int result = calculator.Subtract(8, 3);

            // Assert
            Assert.Equal(5, result);
        }
    }    
}
