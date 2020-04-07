using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Calculator.Math.Tests
{
	[TestFixture]
	public class ConvertToPolishNotationTests
	{
		[SetUp]
		protected void SetUp()
		{
			// Not Implemented
		}

		[Test]
		public void TwoInts_Added()
		{
			// Arrange
			string input = "101+101";
			List<string> actual = null;
			List<string> expected = new List<string>() { "101", "101", "+" };

			// Act
			actual = ConvertToPolishNotation.Convert(input);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void TwoInts_Subtracted()
		{
			// Arrange
			string input = "101-101";
			List<string> actual = null;
			List<string> expected = new List<string>() { "101", "101", "-" };

			// Act
			actual = ConvertToPolishNotation.Convert(input);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void TwoDoubles_Added()
		{
			// Arrange
			string input = "101.1+101.1";
			List<string> actual = null;
			List<string> expected = new List<string>() { "101.1", "101.1", "+" };

			// Act
			actual = ConvertToPolishNotation.Convert(input);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void TwoInts_Added_IgnoreWhiteSpace()
		{
			// Arrange
			string input = "101 + 101";
			List<string> actual = null;
			List<string> expected = new List<string>() { "101", "101", "+" };

			// Act
			actual = ConvertToPolishNotation.Convert(input);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void PositiveDoubleNegativeDouble_Added()
		{
			// Arrange
			string input = "101.1+-101.1";
			List<string> actual = null;
			List<string> expected = new List<string>() { "101.1", "-101.1", "+" };

			// Act
			actual = ConvertToPolishNotation.Convert(input);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void PositiveDoubleNegativeDouble_Subtracted()
		{
			// Arrange
			string input = "101.1+-101.1";
			List<string> actual = null;
			List<string> expected = new List<string>() { "101.1", "-101.1", "-" };

			// Act
			actual = ConvertToPolishNotation.Convert(input);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void FourIntsTwoDoubles_Added_Subtracted()
		{
			// Arrange
			string input = "101+-101+101-101.1--101.1+101";
			List<string> actual = null;
			List<string> expected = new List<string>() { "101", "-101", "+", "101", "+", "101.1", "-", "-101.1", "-", "101", "+" };

			// Act
			actual = ConvertToPolishNotation.Convert(input);

			// Assert
			Assert.AreEqual(expected, actual);
		}
	}
}
