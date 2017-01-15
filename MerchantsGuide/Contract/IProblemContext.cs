using System.Collections.Generic;

namespace MerchantsGuide.Contract
{
    public interface IProblemContext
    {
        IRomanNumberParser RomanNumberParser { get; }

        IDictionary<string, string> RomanDigitsMap { get; }

        IDictionary<string, IDictionary<string, decimal>> Quotes { get; }
        
        IExpressionProcessorFactory ExpressionProcessorFactory { get; }

        void ProcessLine(string input);
    }
}