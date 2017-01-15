using System;
using MerchantsGuide.Contract;

namespace MerchantsGuide
{
    public class QuestionExpressionProcessor : 
        IQuestionProcessor,
        IExpressionProcessor
    {
        public IExpression Parse(string input, IProblemContext context)
        {
            throw new NotImplementedException();
        }
        public string GetAnswer(QuestionExpression expression)
        {
            throw new NotImplementedException();
        }
    }
}