using System;
namespace Meow 
{
	public class Program {
		static void Main(string[] args) {
			
			string expression = "3 + 4 * 2 / ( 1 - 5 ) ^ 2 ^ 3";
			var tokens = ExpressionTokenizer.Tokenize(expression);
			ShuntingYardParser parser = new ();
			PostfixEvaluator evaluator = new ();
			var outputTokens = parser.ConvertToPostfix(tokens);

			var result = evaluator.Evaluate(outputTokens);
			Console.WriteLine($"{result}");
		}
	}
}