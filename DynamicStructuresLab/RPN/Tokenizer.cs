using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructuresLab.RPN
{
    public class Tokenizer
    {
        string expression;

        public Tokenizer(string expression)
        {
            this.expression = expression;
        }

        static string ClearExpression(string expression)
        {
            string[] separators = { "+", "-", "*", "/", "(", ")", "^", "|" };
            expression = expression.Replace(", ", "|");
            expression = expression.Replace(" ", "");
            foreach (string separator in separators)
            {
                expression = expression.Replace(separator, $" {separator} ");
            }
            expression = expression.Replace("  ", " ");
            return expression;
        }

        public List<Token> Tokenize()
        {
            List<Token> tokens = new List<Token>();
            string expression;
            //expression = ClearExpression(this.expression);
            List<string> strings = new List<string>(this.expression.Split(" "));
            string functionName = "";
            bool inFunction = false;
            bool inFirstExpression = true;
            string firstExpression = "";
            string secondExpression = "";
            int countOpeningParenthesis = 0;
            int countClosingParenthesis = 0;

            double value;

            foreach (string s in strings)
            {
                if ((s == "log" | s == "sqrt" | s == "rt" | s == "sin" | s == "cos" | s == "tg" | s == "ctg") & !inFunction)
                {
                    inFunction = true;
                    functionName = s;
                    continue;
                }
                if (inFunction)
                {
                    if (s == "(") countOpeningParenthesis++;
                    if (s == ")") countClosingParenthesis++;
                    if (countOpeningParenthesis == countClosingParenthesis)
                    {
                        if (inFirstExpression)
                        {
                            tokens.Add(new Function(functionName, firstExpression));
                        }
                        else
                        {
                            tokens.Add(new Function(functionName, firstExpression, secondExpression));
                        }
                        functionName = "";
                        inFunction = false;
                        inFirstExpression = true;
                        firstExpression = "";
                        secondExpression = "";
                        countOpeningParenthesis = 0;
                        countClosingParenthesis = 0;
                        continue;
                    }
                    if (s == "|" && countOpeningParenthesis - countClosingParenthesis == 1)
                    {
                        inFirstExpression = false;
                        continue;
                    }
                    if (inFirstExpression)
                    {
                        if (s == "(" & countOpeningParenthesis == 1) continue;
                        firstExpression += s;
                    }
                    else
                    {
                        secondExpression += s;
                    }
                    continue;
                }

                if (s == "x") tokens.Add(new Variable());
                if (s == "(") tokens.Add(new Parenthesis(isOpening: true));
                if (s == ")") tokens.Add(new Parenthesis(isOpening: false));
                if (s == "+") tokens.Add(new Operation("+"));
                if (s == "-") tokens.Add(new Operation("-"));
                if (s == "*") tokens.Add(new Operation("*"));
                if (s == "/") tokens.Add(new Operation("/"));
                if (s == "^") tokens.Add(new Operation("^"));
                if (double.TryParse(s, out value)) tokens.Add(new Number(value));

            }
            return tokens;
        }
    }
}
