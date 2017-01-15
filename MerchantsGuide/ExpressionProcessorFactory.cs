using System;
using MerchantsGuide.Contract;

namespace MerchantsGuide
{
    public class ExpressionProcessorFactory : 
        IExpressionProcessorFactory
    {
        public IExpressionProcessor Get(string input)
        {
            throw new NotImplementedException();
        }
    }
}