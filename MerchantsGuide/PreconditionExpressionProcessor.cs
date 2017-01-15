using System;
using System.Collections.Generic;
using System.Linq;
using MerchantsGuide.Contract;

namespace MerchantsGuide
{
    public class PreconditionExpressionProcessor :
        ExpressionProcessor
    {
        public override void ProcessInternal(IExpression prototype, IProblemContext context)
        {
            var resultExpression = new PreconditionExpression
            {
                Left = prototype.Left,
                Right = prototype.Right,
                PreconditionType =
                    prototype.Left.Contains(" ")
                        ? PreconditionExpressionType.Quote
                        : PreconditionExpressionType.RomanDigit
            };

            switch (resultExpression.PreconditionType)
            {
                case PreconditionExpressionType.RomanDigit:
                    ProcessRomanDigitPrecondition(prototype, context);
                    break;
                case PreconditionExpressionType.Quote:
                    ProcessQuotePrecondition(prototype, context);
                    break;
            }
        }

        private static void ProcessRomanDigitPrecondition(IExpression prototype, IProblemContext context)
        {
            context.RomanDigitsMap[prototype.Left] = prototype.Right;
        }

        private static void ProcessQuotePrecondition(IExpression prototype, IProblemContext context)
        {
            var romanNumber = "";
            var leftSegments = prototype.Left.Split(' ');
            var rightSegments = prototype.Right.Split(' ');
            var rightAmount = double.Parse(rightSegments[0]);
            var rightResourceCode = rightSegments[1];
            var leftResourceCode = leftSegments[leftSegments.Length - 1];
            foreach (var segment in leftSegments.Take(leftSegments.Length - 1))
            {
                string romanDigit;
                if (context.RomanDigitsMap.TryGetValue(segment, out romanDigit))
                {
                    //it is roman digit
                    romanNumber += romanDigit;
                }
                else
                {
                    throw new Exception("Invalid expression");
                }
            }

            var decimalNumber = context.RomanNumberParser.Parse(romanNumber);
            if (decimalNumber == -1)
            {
                throw new Exception("Invalid expression");
            }
            IDictionary<string, decimal> leftToRightQuotes;
            if (!context.Quotes.TryGetValue(leftResourceCode, out leftToRightQuotes))
            {
                leftToRightQuotes = new Dictionary<string, decimal>();
                context.Quotes[leftResourceCode] = leftToRightQuotes;
            }
            var leftAmount =  decimalNumber * 1.0;
            var leftToRightQuote = (decimal)rightAmount / (decimal)leftAmount;
            leftToRightQuotes[rightResourceCode] = leftToRightQuote;

            IDictionary<string, decimal> rightToLeftQuotes;
            if (!context.Quotes.TryGetValue(rightResourceCode, out rightToLeftQuotes))
            {
                rightToLeftQuotes = new Dictionary<string, decimal>();
                context.Quotes[rightResourceCode] = rightToLeftQuotes;
            }
            var rightToLeftQuote = (decimal)leftAmount / (decimal)rightAmount;
            rightToLeftQuotes[leftResourceCode] = rightToLeftQuote;
        }
    }
}