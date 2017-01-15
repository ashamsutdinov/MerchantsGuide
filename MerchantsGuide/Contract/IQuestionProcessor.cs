namespace MerchantsGuide.Contract
{
    public interface IQuestionProcessor
    {
        string GetAnswer(QuestionExpression expression);
    }
}