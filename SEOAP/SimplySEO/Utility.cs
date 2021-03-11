using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SimplySEO
{
	public class Utility
	{
		//Generic logic to find a word in a text
		public static int ExtractParagraph(string text, string word)
			{
				Console.WriteLine("Matches for: {0}", word);
				string expression = @"((^.{0,30}|\w*.{30})\b" + word + @"\b(.{30}\w*|.{0,30}$))";
				Regex wordMatch = new Regex(expression, RegexOptions.IgnoreCase | RegexOptions.Singleline);
				int counter = 0;
				foreach (Match m in wordMatch.Matches(text))
				{
					counter++;
				}
				return counter;
			}

		}
}
