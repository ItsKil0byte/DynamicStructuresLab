using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructuresLab.RPN
{
    public class RPNcalculator
    {
        string expression;

        public RPNcalculator(string expression)
        {
            this.expression = expression;
        }

        public double Calculate(double VariableX = 1, bool inRPN = false)
        {
            List<Token> tokens = new Tokenizer(this.expression).Tokenize();
            if (!inRPN) tokens = ConvertToRPN(tokens);
            return CalculateRPNExpression(tokens, VariableX);
        }

        

        static List<Token> ConvertToRPN(List<Token> expression)
        {
            List<Token> expressionInRPN = new List<Token>();
            CustomStack<Token> stack = new CustomStack<Token>();

            foreach (Token token in expression)
            {
                if (token.GetType() == typeof(Number) | token.GetType() == typeof(Function) | token.GetType() == typeof(Variable))
                {
                    expressionInRPN.Add(token);
                }
                if (token.GetType() == typeof(Parenthesis))
                {
                    Parenthesis parenthesis = (Parenthesis)token;
                    if (parenthesis.isOpening)
                    {
                        stack.Push(token);
                    }
                    else
                    {
                        while (stack.Count > 0 && stack.Peek().GetType() != typeof(Operation) && (((Parenthesis)stack.Peek()).isOpening))
                        {
                            expressionInRPN.Add(stack.Pop());
                        }
                        while (stack.Count > 0 && stack.Peek().GetType() == typeof(Operation) && (((Operation)stack.Peek()).priority >= 0))
                        {
                            expressionInRPN.Add(stack.Pop());
                        }
                        stack.Pop();
                    }
                }
                if (token.GetType() == typeof(Operation))
                {
                    int priority;
                    if (stack.Count > 0 && stack.Peek().GetType() == typeof(Operation))
                    {
                        priority = ((Operation)stack.Peek()).priority;
                    }
                    else
                    {
                        priority = 0;
                    }
                    while (stack.Count > 0 && (priority >= ((Operation)token).priority))
                    {
                        expressionInRPN.Add(stack.Pop());
                    }
                    stack.Push(token);
                }
            }
            foreach (Token token in stack)
            {
                expressionInRPN.Add(token);
            }

            return expressionInRPN;
        }

        private static Number CalculateOperation(Operation op, Number first, Number second)
        {
            Number result = new Number(0);
            switch (op.value)
            {
                case "+": result = first + second; break;
                case "-": result = first - second; break;
                case "*": result = first * second; break;
                case "/": result = first / second; break;
                case "^": result = first ^ second; break;
            }
            return result;
        }

        private static Number CalculateFunction(Function fn, double VariableX)
        {
            double result = 0;
            double first = new RPNcalculator(fn.firstExpression).Calculate(VariableX);
            double second = new RPNcalculator(fn.secondExpression).Calculate(VariableX);

            switch (fn.name)
            {
                case "log":

                    result = Math.Log(second, first);
                    break;
                case "rt":
                    result = Math.Pow(second, 1 / first);
                    break;
                case "sqrt":
                    result = Math.Sqrt(first);
                    break;
                case "sin":
                    result = Math.Sin(first);
                    break;
                case "cos":
                    result = Math.Cos(first);
                    break;
                case "tg":
                    result = Math.Tan(first);
                    break;
                case "ctg":
                    result = 1 / Math.Tan(first);
                    break;
            }
            return new Number(result);
        }

        private static double CalculateRPNExpression(List<Token> RPNexpression, double VariableX)
        {
            int counter = 0;
            Stack<Number> stack = new Stack<Number>();
            foreach (Token token in RPNexpression)
            {
                if (token.GetType() == typeof(Number) | token.GetType() == typeof(Function) | token.GetType() == typeof(Variable))
                {
                    if (token.GetType() == typeof(Number))
                    {
                        stack.Push((Number)token);
                    }
                    else if (token.GetType() == typeof(Variable))
                    {
                        stack.Push(new Number(VariableX));
                    }
                    else
                    {
                        stack.Push(CalculateFunction((Function)token, VariableX));
                    }
                }
                else if (token.GetType() == typeof(Operation))
                {
                    counter++;
                    Number second, first;
                    if (stack.Count > 0) second = stack.Pop(); else second = new Number(0);
                    if (stack.Count > 0) first = stack.Pop(); else first = new Number(0);
                    stack.Push(CalculateOperation((Operation)token, first, second));
                }
            }
            return stack.Count > 0 ? stack.Pop().value : 0;
        }
    }
}
