using MerchantsGuide.App.Contract;

namespace MerchantsGuide.App
{
    public class ExpressionProcessorFactory : 
        IExpressionProcessorFactory
    {
        private IExpressionProcessor _simpleExpressionProcessor;

        private IExpressionProcessor _questionExpressionProcessor;

        public IExpressionProcessor Get(string input)
        {
            if (string.IsNullOrEmpty(input))
                return null;

            if (input.EndsWith("?"))
            {
                return _questionExpressionProcessor ?? (_questionExpressionProcessor = new QuestionExpressionProcessor());
            }

            return _simpleExpressionProcessor ?? (_simpleExpressionProcessor = new PreconditionExpressionProcessor());
        }
    }
}