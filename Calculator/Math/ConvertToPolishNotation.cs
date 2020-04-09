using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calculator.Math
{
	public static class ConvertToPolishNotation
	{
		private readonly static Regex _splitInput = new Regex(@"(?(?<=[^\-\+\*\\])(([\-\+\*\\]))|(\-?\d+\.?\d*))");
		private static readonly Dictionary<string, int> _allowedOperators = new Dictionary<string, int>() { { "+", 7 }, { "-", 7 }, { "*", 6 }, { "/", 6 } }; 
		public static List<string> Convert(string input)
		{
			if(string.IsNullOrWhiteSpace(input))
			{
				return null;
			}

			List<string> polishNotation = new List<string>();
			Queue<string> operators = new Queue<string>();
			List<string> splitString = Parse(input);

			if (splitString.Count <= 0)
			{
				return null;
			}

			while(splitString.Count > 0)
			{
				if(double.TryParse(splitString[0], out double _))
				{
					polishNotation.Add(splitString[0]);
				}
				
				else if(_allowedOperators.ContainsKey(splitString[0]))
				{
					while(operators.Count > 0 && _allowedOperators[operators.Peek()] >= _allowedOperators[splitString[0]])
					{
						polishNotation.Add(operators.Dequeue());
					}
					operators.Enqueue(splitString[0]);
				}
				splitString.RemoveAt(0);
			}

			while(operators.Count > 0)
			{
				polishNotation.Add(operators.Dequeue());
			}

			return polishNotation;
		}

		private static List<string> Parse(string input)
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
