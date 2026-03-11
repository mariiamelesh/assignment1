using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Meow 
{
    public static class ExpressionTokenizer 
    {
        public static StringQueue Tokenize(string equation) 
        {
            StringQueue tokens = new();
			string currentToken = "";

            foreach (char character in equation) 
            {
                if (char.IsWhiteSpace(character)) continue;

                if (char.IsLetterOrDigit(character) || character == '.') 
                {
                    currentToken += character; 
                }
                else 
                {
                    if (currentToken.Length > 0) 
                    {
                        tokens.Enqueue(currentToken);
                        currentToken = "";
                    }
                    tokens.Enqueue(character.ToString());
                }
            }

            if (currentToken.Length > 0) 
            {
                tokens.Enqueue(currentToken);
            }

            return tokens;
        }
    }
}