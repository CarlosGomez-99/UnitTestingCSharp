using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;

namespace StringManipulation.Tests
{
    public class StringOperationTest
    {
        [Fact(Skip = "Prueba para el atributo skip para test XUnit")]
        public void ConcatenateStrings()
        {
            // Arrange
            var strOperation = new StringOperations();

            // Act
            var result = strOperation.ConcatenateStrings("Hello", "World");

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("Hello World", result);
        }

        [Fact]
        public void IsPalindrome_True()
        {
            // Arrange
            var strOperation = new StringOperations();

            // Act
            var result = strOperation.IsPalindrome("ama");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsPalindrome_False()
        {
            // Arrange
            var strOperation = new StringOperations();

            // Act
            var result = strOperation.IsPalindrome("Hello");

            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("Hello World", "HelloWorld")]
        public void RemoveWhitespace(string phrase, string expected)
        {
            // Arrange
            var strOperation = new StringOperations();

            // Act
            var result = strOperation.RemoveWhitespace(phrase);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void QuantintyInWords()
        {
            // Arrange
            var strOperation = new StringOperations();

            // Act
            var result = strOperation.QuantintyInWords("perro", 2);

            // Assert
            Assert.StartsWith("dos", result);
            Assert.Contains("perro", result);
        }

        [Fact]
        public void GetStringLength()
        {
            // Arrange
            var strOperation = new StringOperations();

            // Act
            var word = "Hello World";
            var result = strOperation.GetStringLength(word);

            // Assert
            Assert.Equal(word.Length, result);
        }

        [Fact]
        public void GetStringLength_Exception()
        {
            // Arrange
            var strOperation = new StringOperations();

            // Act
            Assert.Throws<ArgumentNullException>(() => strOperation.GetStringLength(null));
        }

        [Fact]
        public void TruncateString()
        {
            // Arrange
            var strOperation = new StringOperations();

            // Act
            var result = strOperation.TruncateString("Test Truncate", 4);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("Test", result);
        }

        [Fact]
        public void TruncateString_Exception()
        {
            // Arrange
            var strOperation = new StringOperations();

            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => strOperation.TruncateString("Test Exception", -1));
        }

        [Theory]
        [InlineData("I", 1)]
        [InlineData("II", 2)]
        [InlineData("III", 3)]
        [InlineData("IV", 4)]
        [InlineData("V", 5)]
        [InlineData("VI", 6)]
        [InlineData("VII", 7)]
        [InlineData("VIII", 8)]
        [InlineData("IX", 9)]
        [InlineData("X", 10)]
        public void FromRomanToNumber(string romanNumber, int expected)
        {
            // Arrange
            var strOperation = new StringOperations();

            // Act
            var result = strOperation.FromRomanToNumber(romanNumber);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CountOccurrences()
        {
            var mockLogger = new Mock<ILogger<StringOperations>>();

            // Arrange
            var strOperation = new StringOperations(mockLogger.Object);

            // Act
            var result = strOperation.CountOccurrences("Carlos Gomez", 'o');

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void ReadFile()
        {
            // Arrange
            var strOperation = new StringOperations();

            var mockFileReader = new Mock<IFileReaderConector>();
            mockFileReader.Setup(x => x.ReadString(It.IsAny<string>())).Returns("Reading file");

            // Act
            var result = strOperation.ReadFile(mockFileReader.Object, "file.txt");

            // Assert
            Assert.Equal("Reading file", result);
        }
    }
}
