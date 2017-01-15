using System.Collections.Generic;

namespace MerchantsGuide.Contract
{
    public interface IProblemContext
    {
        IRomanNumberParser RomanNumberParser { get; }

        IDictionary<string, string> RomanDigitsMap { get; }

        IExpressionProcessorFactory ExpressionProcessorFactory { get; }

        void ProcessLine(string input);
    }
}