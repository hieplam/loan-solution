using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;

namespace loan_solution.Validators
{
    public interface ILoanValidator
    {
        IEnumerable<ValidateResult> Validate(LoanRequest request);
    }
    
    public class LoanValidator : ILoanValidator
    {
        private readonly IEnumerable<ILoanValidator> _validators;
        private readonly LoanConfig _loanConfig;

        public LoanValidator(IOptions<LoanConfig> config)
        {
            _loanConfig = config.Value;

            _validators = new List<ILoanValidator>()
            {
                new FirstNameValidator(),
                new LastNameValidator(),
                new EmailValidator(),
                new PhoneNumberValidator(),
                new BusinessNumberValidator(),
                new LoanAmountValidator(_loanConfig),
            };
        }
        public IEnumerable<ValidateResult> Validate(LoanRequest loan)
        {
            return _validators.SelectMany(validator => validator.Validate(loan));
        }

    }

    public class ValidateResult
    {
        public string ValidateType { get; set; }
        public string Message { get; set; }
    }
}