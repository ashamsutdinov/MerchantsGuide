using System.Collections.Generic;
using MerchantsGuide.App;
using MerchantsGuide.App.Contract;

namespace MerchantsGuide
{
    public class ProblemContext : 
        IProblemContext
    {
        public IRomanNumberParser RomanNumberParser { get; private set; }

        public IDictionary<string, string> RomanDigitsMap { get; private set; }

        public IDictionary<string, IDictionary<string, decimal>> Quotes { get; private set; }

        public IExpressionProcessorFactory ExpressionProcessorFactory { get; private set; }

        public ProblemContext()
        {
            RomanDigitsMap = new Dictionary<string, string>();
            RomanNumberParser = new RomanNumberParser();
            ExpressionProcessorFactory = new ExpressionProcessorFactory();
            Quotes = new Dictionary<string, IDictionary<string, decimal>>();
        }

        public void ProcessLine(string input)
        {
            var processor = ExpressionProcessorFactory.Get(input);
            processor.Process(input, this);
        }
    }
}