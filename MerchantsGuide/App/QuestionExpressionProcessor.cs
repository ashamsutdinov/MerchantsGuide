using System;
using System.Collections.Generic;
using System.Linq;
using MerchantsGuide.App.Contract;

namespace MerchantsGuide.App
{
    public class QuestionExpressionProcessor :
        ExpressionProcessor
    {
        private const string HowMuchQuestion = "how much";

        private const string HowManyQuestion = "how many";

        private const string QuestionSegment = "?";

        public override void ProcessInternal(IExpression prototype, IProblemContext context)
        {
            var questionExpression = new QuestionExpression
            {
                Left = prototype.Left,
                Right = prototype.Right
            };

            if (prototype.Left.StartsWith(HowMuchQuestion))
            {
                questionExpression.QuestionType = QuestionExpressionType.HowMuch;
            }
            else if (prototype.Left.StartsWith(HowManyQuestion))
            {
                questionExpression.QuestionType = QuestionExpressionType.HowMany;
            }
            else
            {
                throw new Exception("Invalid expression");
            }

            switch (questionExpression.QuestionType)
            {
                case QuestionExpressionType.HowMuch:
                    ProcessHowMuchQuestion(questionExpression, context);
                    break;
                case QuestionExpressionType.HowMany:
                    ProcessHowManyQuestion(questionExpression, context);
                    break;
            }
        }

        private static void ProcessHowMuchQuestion(IQuestionExpression questionExpression, IProblemContext context)
        {
            var rightSegments = questionExpression.Right.Split(' ').Where(s => s != QuestionSegment);
            var romanNumber = ParseRomanNumber(rightSegments, context);
            var decimalNumber = context.RomanNumberParser.Parse(romanNumber);
            if (decimalNumber == -1)
            {
                throw new Exception("Invalid expression");
            }
            var answerString = questionExpression.Right.Replace(HowMuchQuestion, "");
            answerString = answerString.Substring(0, answerString.Length - 1).Trim();
            Console.WriteLine("{0} is {1}", answerString, decimalNumber);
        }

        private static void ProcessHowManyQuestion(IQuestionExpression questionExpression, IProblemContext context)
        {
            var leftSegments = questionExpression.Left.Split(' ');
            var leftResourceCode = leftSegments.Last();
            IDictionary<string, decimal> leftQuotes;
            if (!context.Quotes.TryGetValue(leftResourceCode, out leftQuotes))
            {
                throw new Exception("Invaid expression");
            }
            var rightSegments = questionExpression.Right.Split(' ').Where(s => s != QuestionSegment).ToArray();
            var rightResourceCode = rightSegments.Last();

            decimal quote;
            if (!leftQuotes.TryGetValue(rightResourceCode, out quote))
            {
                throw new Exception("Invalid expression");
            }
            var romanNumber = ParseRomanNumber(rightSegments.Take(rightSegments.Length - 1), context);
            var decimalNumber = context.RomanNumberParser.Parse(romanNumber);
            var price = Math.Round(decimalNumber / quote);
            var answerString = questionExpression.Right.Substring(0, questionExpression.Right.Length - 1).Trim();
            Console.WriteLine("{0} is {1} {2}", answerString, (int)price, leftResourceCode);
        }
    }
}