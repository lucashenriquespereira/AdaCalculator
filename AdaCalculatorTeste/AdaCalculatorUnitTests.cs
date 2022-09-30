using AdaCalculator;
using Moq;
using FluentAssertions;

namespace AdaCalculatorTeste
{
    public class AdaCalculatorUnitTests
    {
        private readonly Mock<ICalculator> _mock;
        private readonly CalculatorMachine _sut;
        public AdaCalculatorUnitTests()
        {
            _mock = new Mock<ICalculator>();
            _sut = new CalculatorMachine(_mock.Object);
        }
        #region Sum Tests
        [Fact]
        public void CalculatorMachine_Sum_OnlyPositiveNumbers()
        {
            var sut = new CalculatorMachine();
            var result = sut.Calculate("sum", 58, 2);
            result.Should().Be(("sum", 60));
        }

        [Fact]
        public void CalculatorMachine_Sum_OnePositiveAndOneNegativeNumber()
        {
            var sut = new CalculatorMachine();
            var result = sut.Calculate("sum", 18, -8);
            result.Should().Be(("sum", 10));
        }

        [Fact]
        public void CalculatorMachine_Sum_OnlyNegativeNumber()
        {
            var sut = new CalculatorMachine();
            var result = sut.Calculate("sum", -18, -8);
            result.Should().Be(("sum", -26));
        }
        #endregion

        #region Subtract Tests
        [Fact]
        public void CalculatorMachine_Subtract_OnlyPositiveNumber()
        {
            var sut = new CalculatorMachine();
            var result = sut.Calculate("subtract", 48, 6);
            result.Should().Be(("subtract", 42));
        }

        [Fact]
        public void CalculatorMachine_Subtract_OnePositiveAndOneNegativeNumber()
        {
            var sut = new CalculatorMachine();
            var result = sut.Calculate("subtract", 48, -12);
            result.Should().Be(("subtract", 60));
        }

        [Fact]
        public void CalculatorMachine_Subtract_OnlyNegativeNumber()
        {
            var sut = new CalculatorMachine();
            var result = sut.Calculate("subtract", -38, -18);
            result.Should().Be(("subtract", -20));
        }
        #endregion

        #region Multiply Tests
        [Theory]
        [InlineData("multiply", 45, 3, 135)]
        [InlineData("multiply", 17, -2, -34)]
        [InlineData("multiply", -16, -10, 160)]
        [InlineData("multiply", 59, 0, 59)]
        public void CalculatorMachine_Multiply_ValidResults(string operation, double first, double second, double result)
        {
            _mock.Setup(x => x.Calculate(operation, first, second)).Returns((operation, result));
            _sut.Calculate(operation, first, second);
            Assert.Equal();
        }
        #endregion

        #region Divide Tests
        [Theory]
        [InlineData("divide", 45, 3, 15)]
        [InlineData("divide", 16, -2, -8)]
        [InlineData("divide", -180, -10, 18)]
        [InlineData("divide", 59, 0, double.PositiveInfinity)]
        public void CalculatorMachine_Divide_ValidResults(string operation, double first, double second, double result)
        {
            _mock.Setup(x => x.Calculate(operation, first, second)).Returns((operation, result));
            _sut.Calculate(operation, first, second);
            Assert.Equal();
        }
        #endregion

    }
}