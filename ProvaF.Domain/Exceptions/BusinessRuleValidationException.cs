using System;

namespace ProvaF.Domain.Exceptions
{
    public class BusinessRuleValidationException : Exception
    {
        public string Details { get; }

        public BusinessRuleValidationException(string message) : base(message)
        {
        
        }

        public BusinessRuleValidationException(string message, string details) : base(message)
        {
            this.Details = details;
        }
    }

    public class ContaInvalidaValidationException : BusinessRuleValidationException
    {
        public ContaInvalidaValidationException(string message) : base(message)
        {
        }

        public ContaInvalidaValidationException(string message, string details) : base(message, details)
        {
        }
    }

    public class ValorInvalidoValidationException : BusinessRuleValidationException
    {
        public ValorInvalidoValidationException(string message) : base(message)
        {
        }

        public ValorInvalidoValidationException(string message, string details) : base(message, details)
        {
        }
    }
}