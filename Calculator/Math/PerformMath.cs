using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calculator.Math
{
	public static class PerformMath
	{
		private readonly static Regex _splitInput = new Regex(@"(?(?<=[^\-\+\*\\])(([\-\+\*\\]))|(\-?\d+\.?\d*))");
		private static readonly Dictionary<string, int> _allowedOperators = new Dictionary<string, int>() { { "+", 7 }, { "-", 7 }, { "*", 6 }, { "/", 6 } };
		private const string ERROR_STRING = "Err";

		/// <summary>
		/// Takes in a string of numbers and operators and outputs the completed math equation.
		/// NOTE: It will also return error strings if the format is incorrect or an error is encountered.
		/// </summary>
		/// <param name="input">The equation to be computed, in traditional format</param>
		/// <returns>The result as a string</returns>
		public static string DoMath(string input)
		{
			if(string.IsNullOrWhiteSpace(input))
			{
				return $"{ERROR_STRING}, no equation";
			}

			List<string> polishNotation = ConvertToPolishNotation(input);

			while(polishNotation.Count > 1)
			{
				try
				{
					string leftHand = polishNotation[0];
					string rightHand = polishNotation[1];
					string operatree = polishNotation[2];

					string returnValue = ComputeTwoOperators(leftHand, rightHand, operatree);

					polishNotation.RemoveRange(0, 3);

					if(returnValue.Contains("Err"))
					{
						return returnValue;
					}

					if(double.TryParse(returnValue, out double _))
					{
						polishNotation.Insert(0, returnValue);
					}
					else
					{
						return $"{ERROR_STRING}, unexpected format";
					}
				}
				catch
				{
					return $"{ERROR_STRING}, unexpected problem";
				}
			}

			return polishNotation.First();
		}

		private static string ComputeTwoOperators(string leftHandOperator, string rightHandOperator, string operatoree)
		{
			if (!double.TryParse(leftHandOperator, out double leftHand))
			{
				return $"{ERROR_STRING}, improper format";
			}

			if (!double.TryParse(rightHandOperator, out double righthand))
			{
				return $"{ERROR_STRING}, improper format";
			}

			switch (operatoree)
			{
				case "+":
					return (leftHand + righthand).ToString();
				case "-":
					return (leftHand - righthand).ToString();
				case "*":
					return (leftHand * righthand).ToString();
				case "/":
					return (leftHand / righthand).ToString();
				default:
					return $"{ERROR_STRING}, Unexpected operator";
			}
		}

		private static List<string> ConvertToPolishNotation(string input)
		{
			if (string.IsNullOrWhiteSpace(input))
			{
				return null;
			}

			List<string> polishNotation = new List<string>();
			Queue<string> operators = new Queue<string>();
			List<string> splitString = SplitInput(input);

			if (splitString.Count <= 0)
			{
				return null;
			}

			while (splitString.Count > 0)
			{
				if (double.TryParse(splitString[0], out double _))
				{
					polishNotation.Add(splitString[0]);
				}

				else if (_allowedOperators.ContainsKey(splitString[0]))
				{
					while (operators.Count > 0 && _allowedOperators[operators.Peek()] >= _allowedOperators[splitString[0]])
					{
						polishNotation.Add(operators.Dequeue());
					}
					operators.Enqueue(splitString[0]);
				}
				splitString.RemoveAt(0);
			}

			while (operators.Count > 0)
			{
				polishNotation.Add(operators.Dequeue());
			}

			return polishNotation;
		}

		private static List<string> SplitInput(string input)
		{
			try
			{
				input = input.Replace(" ", "");
				List<string> splitEquation = _splitInput.Split(input).Where(listItem => !string.IsNullOrWhiteSpace(listItem)).ToList();

				return splitEquation;
			}
			catch
			{
				return new List<string>();
			}
		}
	}
}
