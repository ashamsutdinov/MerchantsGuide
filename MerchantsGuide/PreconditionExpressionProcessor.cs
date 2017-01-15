using System.Collections.Generic;
using System.Net.Mime;
using MerchantsGuide.Contract;

namespace MerchantsGuide
{
    public class PreconditionExpressionProcessor :
        ExpressionProcessor
    {
        public override IExpression ParseInternal(IExpression prototype, IProblemContext context)
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
                    ParseRomanDigitPrecondition(prototype, context);
                    break;
                case PreconditionExpressionType.Quote:
                    ParseQuotePrecondition(prototype, context);
                    break;
            }

            return resultExpression;
        }

        private static void ParseRomanDigitPrecondition(IExpression prototype, IProblemContext context)
        {
            context.RomanDigitsMap[prototype.Left] = prototype.Right;
        }

        private static void ParseQuotePrecondition(IExpression prototype, IProblemContext context)
        {
            var romanNumber = "";
            var leftSegments = prototype.Left.Split(' ');
            var rightSegments = prototype.Right.Split(' ');
            var rightAmount = double.Parse(rightSegments[0]);
            var rightResourceCode = rightSegments[1];
            foreach (var segment in leftSegments)
            {
                string romanDigit;
                if (context.RomanDigitsMap.TryGetValue(segment, out romanDigit))
                {
                    //it is roman digit
                    romanNumber += segment;
                }
                else
                {
                    //it is resource code
                    var leftResourceCode = segment;
                    IDictionary<string, double> leftToRightQuotes;
                    if (!context.Quotes.TryGetValue(leftResourceCode, out leftToRightQuotes))
                    {
                        leftToRightQuotes = new Dictionary<string, double>();
                        context.Quotes[leftResourceCode] = leftToRightQuotes;
                    }
                    var leftAmount = context.RomanNumberParser.Parse(romanNumber) * 1.0;
                    var leftToRightQuote = rightAmount / leftAmount;
                    leftToRightQuotes[rightResourceCode] = leftToRightQuote;

                    IDictionary<string, double> rightToLeftQuotes;
                    if (!context.Quotes.TryGetValue(rightResourceCode, out rightToLeftQuotes))
                    {
                        rightToLeftQuotes = new Dictionary<string, double>();
                        context.Quotes[rightResourceCode] = rightToLeftQuotes;
                    }
                    var rightToLeftQuote = leftAmount / rightAmount;
                    rightToLeftQuotes[leftResourceCode] = rightToLeftQuote;
                }
            }
        }
    }
}