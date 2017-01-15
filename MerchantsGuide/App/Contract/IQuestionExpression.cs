namespace MerchantsGuide.App.Contract
{
    public interface IQuestionExpression : 
        IExpression
    {
        QuestionExpressionType QuestionType { get; }
    }
}