using System;
using System.Collections.Generic;

namespace Meow 
{
    public class PostfixEvaluator 
    {
		private Dictionary<string, Func<double, double, double>> binaryOperators = new() 
		{
			{ "+", (a, b) => a + b }, {"-", (a, b) => a - b},
			{"*", (a, b) => a * b}, {"/", (a, b) => a / b}, 
			{"max", (a, b) => Math.Max(a, b)}, {"^", (a, b) => Math.Pow(a, b)}
		};
		
		private Dictionary<string, Func<double, double>> unaryOperators = new() 
		{
			{"sin", a => Math.Sin(a)},
			{"cos", a => Math.Cos(a)}
		};
        public double Evaluate(StringQueue postfixTokens) 
        {
            NumStack computationStack = new(); 

            while (postfixTokens.Count > 0) 
            {
                string token = postfixTokens.Dequeue();

                if (double.TryParse(token, out double number)) 
                {
                    computationStack.Push(number);
                }
                else if (unaryOperators.TryGetValue(token, out Func<double, double> function1))
                {
					double A = computationStack.Pop();
					computationStack.Push(function1(A));
                }
				else if (binaryOperators.TryGetValue(token, out Func<double, double, double> function2)) {
					if (computationStack.Count >= 2) {
					double B = computationStack.Pop();
					double A = computationStack.Pop();
					computationStack.Push(function2(A, B));
					}
					else {
						throw new Exception("Incorrect input");
					}
				}
            }
			if (computationStack.Count > 0) {
				return computationStack.Pop();
			}
			else {
				return 0;
			}
        }
    }
}
