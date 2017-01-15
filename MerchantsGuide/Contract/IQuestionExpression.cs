namespace MerchantsGuide.Contract
{
    public interface IQuestionExpression : 
        IExpression
    {
        QuestionExpressionType QuestionType { get; }
    }
}