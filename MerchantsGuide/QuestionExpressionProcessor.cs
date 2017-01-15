using System;
using MerchantsGuide.Contract;

namespace MerchantsGuide
{
    public class QuestionExpressionProcessor :
        ExpressionProcessor
    {
        private const string HowMuchQuestion = "how much";

        private const string HowManyQuestion = "how many";

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

        }

        private static void ProcessHowManyQuestion(IQuestionExpression questionExpression, IProblemContext context)
        {

        }
    }
}