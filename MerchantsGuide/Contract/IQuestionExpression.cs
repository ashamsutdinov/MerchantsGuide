namespace MerchantsGuide.Contract
{
    public interface IQuestionExpression
    {
        QuestionExpressionType QuestionType { get; }

        string SellResource { get; }

        int SellAmount { get; }

        string BuyResource { get; }

        int BuyAmount { get; }
    }
}