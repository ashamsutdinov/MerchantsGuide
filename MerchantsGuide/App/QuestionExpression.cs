using MerchantsGuide.App.Contract;

namespace MerchantsGuide.App
{
    public class QuestionExpression : 
        Expression,
        IQuestionExpression
    {
        public QuestionExpressionType QuestionType { get; set; }
    }
}