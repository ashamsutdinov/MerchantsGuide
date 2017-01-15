using System;
using MerchantsGuide.Contract;

namespace MerchantsGuide
{
    public abstract class ExpressionProcessor :
        IExpressionProcessor
    {
        private const string ExpressionPartsSeparator = "is";

        private const int ExpressionPartsNumber = 2;

        public IExpression Parse(string input, IProblemContext context)
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
                return ParseInternal(new Expression { Left = left, Right = right }, context);
            }
            catch (Exception)
            {
                Console.WriteLine("I have no idea what you are talking about");
                return null;
            }
        }

        public abstract IExpression ParseInternal(IExpression prototype, IProblemContext context);
    }
}