using System;
using Xunit;
using Session09_Assignment; // لكي يرى الأكواد الموجودة في المشروع الأساسي

namespace Session09_Assignment.Tests
{
    // Q12: Test Class for FineCalculator
    public class FineCalculatorTests
    {
        // Arrange (Creating the instance in the constructor)
        private readonly FineCalculator _calculator;

        public FineCalculatorTests()
        {
            _calculator = new FineCalculator();
        }

        // 1. Add ShouldReturnCorrectSum
        [Fact]
        public void Add_ShouldReturnCorrectSum()
        {
            // Act
            int result = _calculator.Add(10, 5);
            // Assert
            Assert.Equal(15, result);
        }

        // 2. Add ShouldReturnNotEqual
        [Fact]
        public void Add_ShouldReturnNotEqual()
        {
            // Act
            int result = _calculator.Add(10, 5);
            // Assert
            Assert.NotEqual(20, result);
        }

        // 3. Subtract_ShouldReturnCorrectDifference
        [Fact]
        public void Subtract_ShouldReturnCorrectDifference()
        {
            // Act
            int result = _calculator.Subtract(10, 5);
            // Assert
            Assert.Equal(5, result);
        }

        // 4. Multiply_ShouldReturnCorrectResult (Theory)
        [Theory]
        [InlineData(5, 4, 20)]   // حالة عادية
        [InlineData(-5, 4, -20)] // حالة الرقم السالب (كما هو مطلوب في الـ Bonus/Table)
        [InlineData(0, 5, 0)]    // حالة الصفر
        public void Multiply_ShouldReturnCorrectResult(int a, int b, int expectedResult)
        {
            // Act
            int result = _calculator.Multiply(a, b);
            // Assert
            Assert.Equal(expectedResult, result);
        }

        // 5. Multiply_ShouldReturnNotEqual (Theory)
        [Theory]
        [InlineData(5, 4, 10)]
        [InlineData(2, 3, 5)]
        public void Multiply_ShouldReturnNotEqual(int a, int b, int wrongExpectedResult)
        {
            // Act
            int result = _calculator.Multiply(a, b);
            // Assert
            Assert.NotEqual(wrongExpectedResult, result);
        }

        // 6. Divide_ByZero_ShouldThrowException
        [Fact]
        public void Divide_ByZero_ShouldThrowException()
        {
            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
        }
    }
}