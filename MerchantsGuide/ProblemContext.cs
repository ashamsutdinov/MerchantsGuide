using System;
using System.Collections.Generic;
using MerchantsGuide.Contract;

namespace MerchantsGuide
{
    public class ProblemContext : 
        IProblemContext
    {
        public IRomanNumberParser RomanNumberParser { get; private set; }

        public IDictionary<string, string> RomanDigitsMap { get; private set; }

        public IDictionary<string, IDictionary<string, double>> Quotes { get; private set; }

        public IExpressionProcessorFactory ExpressionProcessorFactory { get; private set; }

        public ProblemContext()
        {
            RomanDigitsMap = new Dictionary<string, string>();
            RomanNumberParser = new RomanNumberParser();
            ExpressionProcessorFactory = new ExpressionProcessorFactory();
            Quotes = new Dictionary<string, IDictionary<string, double>>();
        }

        public void ProcessLine(string input)
        {
            var processor = ExpressionProcessorFactory.Get(input);
            var expression = processor.Parse(input, this);
            if (expression.Type == ExpressionType.Question)
            {
                var question = expression as IQuestionExpression;
                var questionProcessor = processor as IQuestionProcessor;
                if (question != null && questionProcessor != null)
                {
                    var output = questionProcessor.GetAnswer(question);
                    if (!string.IsNullOrEmpty(output))
                    {
                        Console.WriteLine(output);
                    }
                }
            }
        }
    }
}