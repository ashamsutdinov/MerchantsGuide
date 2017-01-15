using System;
using System.Linq;
using MerchantsGuide.Contract;

namespace MerchantsGuide
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
            var romanNumber = "";
            var answerString = "";
            foreach (var segment in rightSegments)
            {
                string romanDigit;
                if (context.RomanDigitsMap.TryGetValue(segment, out romanDigit))
                {
                    //it is roman digit
                    romanNumber += romanDigit;
                    answerString += segment + " ";
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
            answerString = answerString.Substring(0, answerString.Length - 1);
            Console.WriteLine("{0} is {1}", answerString, decimalNumber);
        }

        private static void ProcessHowManyQuestion(IQuestionExpression questionExpression, IProblemContext context)
        {

        }
    }
}