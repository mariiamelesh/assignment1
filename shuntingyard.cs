using System;
using System.Collections.Generic;

namespace Meow 
{
    public class ShuntingYardParser 
    {
        private readonly Dictionary<string, int> _precedenceDict = new() 
        { 
            {"+", 1}, {"-", 1 }, {"*", 2}, { "/", 2}, 
            {"^", 3 }, {"sin", 4}, {"cos", 4}, {"max", 4 }
        };

        public StringQueue ConvertToPostfix(StringQueue infixTokens) 
        {
            StringQueue outputQueue = new();
            StringStack operatorStack = new();

            while (infixTokens.Count > 0) 
            {
                string token = infixTokens.Dequeue();

                if (double.TryParse(token, out _)) 
                {
                    outputQueue.Enqueue(token);
                }
                else if (token == "(") 
                {
                    operatorStack.Push(token);
                }
                else if (token == ")") 
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek() != "(") 
                    {
                        outputQueue.Enqueue(operatorStack.Pop());
                    }
                    operatorStack.Pop(); 
                }
                else if (_precedenceDict.ContainsKey(token)) 
					
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek() != "(" &&
                           _precedenceDict[operatorStack.Peek()] >= _precedenceDict[token]) 
					{
						if (token == "^" && operatorStack.Peek() == "^") {
							break;
						}
						else {
							outputQueue.Enqueue(operatorStack.Pop());
						}
                        
                    }  
                    operatorStack.Push(token);
                }
            }

            while (operatorStack.Count > 0) 
            {
                outputQueue.Enqueue(operatorStack.Pop());
            }

            return outputQueue;
        }
    }
}