using System;
using MerchantsGuide.Contract;

namespace MerchantsGuide
{
    public class QuestionExpressionProcessor : 
        ExpressionProcessor,
        IQuestionProcessor
    {
        public override IExpression ParseInternal(IExpression prototype, IProblemContext context)
        {
            throw new NotImplementedException();
        }

        public string GetAnswer(IQuestionExpression expression)
        {
            throw new NotImplementedException();
        }
    }
}