using System;
using System.Collections.Generic;
using MerchantsGuide.App.Contract;

namespace MerchantsGuide.App
{
    public abstract class ExpressionProcessor :
        IExpressionProcessor
    {
        private const string ExpressionPartsSeparator = " is ";

        private const int ExpressionPartsNumber = 2;

        public void Process(string input, IProblemContext context)
        {
            try
            {
                var expressionParts = input.Split(new[] { ExpressionPartsSeparator }, StringSplitOptions.RemoveEmptyEntries);
                if (expressionParts.Length != ExpressionPartsNumber)
                {
                    throw new Exception("Invalid expression");
                }
                var left = expressionParts[0].Trim();
                var right = expressionParts[1].Trim();
                ProcessInternal(new Expression { Left = left, Right = right }, context);
            }
            catch (Exception)
            {
                Console.WriteLine("I have no idea what you are talking about");
            }
        }

        public abstract void ProcessInternal(IExpression prototype, IProblemContext context);

        protected static string ParseRomanNumber(IEnumerable<string> segments, IProblemContext context)
        {
            var romanNumber = "";
            foreach (var segment in segments)
            {
                string romanDigit;
                if (context.RomanDigitsMap.TryGetValue(segment, out romanDigit))
                {
                    romanNumber += romanDigit;
                }
                else
                {
                    throw new Exception("Invalid expression");
                }
            }
            return romanNumber;
        }
    }
}