namespace MerchantsGuide.Contract
{
    public interface IQuestionProcessor
    {
        string GetAnswer(IQuestionExpression expression);
    }
}