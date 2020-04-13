using NUnit.Framework;

namespace Calculator.Math.Tests
{
	[TestFixture]
	public class PerformMathTests
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
			string actual = string.Empty;
			string expected = "202";

			// Act
			actual = PerformMath.DoMath(input);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void TwoInts_Subtracted()
		{
			// Arrange
			string input = "101-101";
			string actual = string.Empty;
			string expected = "0";

			// Act
			actual = PerformMath.DoMath(input);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void TwoDoubles_Added()
		{
			// Arrange
			string input = "101.1+101.1";
			string actual = string.Empty;
			string expected = "202.2";

			// Act
			actual = PerformMath.DoMath(input);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void TwoInts_Added_IgnoreWhiteSpace()
		{
			// Arrange
			string input = "101 + 101";
			string actual = string.Empty;
			string expected = "202";

			// Act
			actual = PerformMath.DoMath(input);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void PositiveDoubleNegativeDouble_Added()
		{
			// Arrange
			string input = "101.1+-101.1";
			string actual = string.Empty;
			string expected = "0";

			// Act
			actual = PerformMath.DoMath(input);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void PositiveDoubleNegativeDouble_Subtracted()
		{
			// Arrange
			string input = "101.1--101.1";
			string actual = string.Empty;
			string expected = "202.2";

			// Act
			actual = PerformMath.DoMath(input);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void FourIntsTwoDoubles_Added_Subtracted()
		{
			// Arrange
			string input = "101+-101+101-101.1--101.1+101";
			string actual = string.Empty;
			string expected = "202";

			// Act
			actual = PerformMath.DoMath(input);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void NegativeDoublePostiveDouble_Multiplied()
		{
			// Arrange
			string input = "-101.1 * 101.1";
			string actual = string.Empty;
			string expected = "-10221.21";

			// Act
			actual = PerformMath.DoMath(input);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void LargeDoubles_Subtracted()
		{
			// Arrange
			string input = "-10192387739898.1344-1383982690101.1389886";
			string actual = string.Empty;
			string expected = "-11576370429999.3";

			// Act
			actual = PerformMath.DoMath(input);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void PositiveIntNegativeDouble_Subtracted_Whitespace()
		{
			// Arrange
			string input = "101 - -101.101";
			string actual = string.Empty;
			string expected = "202.101";

			// Act
			actual = PerformMath.DoMath(input);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void PositiveIntPositiveInt_Divided()
		{
			// Arrange
			string input = "101 / 101";
			string actual = string.Empty;
			string expected = "1";

			// Act
			actual = PerformMath.DoMath(input);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void ThreeInts_Added_Divided()
		{
			// Arrange
			string input = "101 + 101 / 101";
			string actual = string.Empty;
			string expected = "102";

			// Act
			actual = PerformMath.DoMath(input);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void InvalidEntry_TripleSubtracted()
		{
			// Arrange
			string input = "101 - --101.101";
			string actual = string.Empty;
			string expected = "Err, improper format";

			// Act
			actual = PerformMath.DoMath(input);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void InvalidEntry_Null()
		{
			// Arrange
			string input = null;
			string actual = string.Empty;
			string expected = "Err, no equation";

			// Act
			actual = PerformMath.DoMath(input);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void InvalidEntry_EmptyString()
		{
			// Arrange
			string input = string.Empty;
			string actual = string.Empty;
			string expected = "Err, no equation";

			// Act
			actual = PerformMath.DoMath(input);

			// Assert
			Assert.AreEqual(expected, actual);
		}
	}
}