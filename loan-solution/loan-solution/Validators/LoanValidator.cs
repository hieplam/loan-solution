using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;

namespace loan_solution.Validators
{
    public interface ILoanValidator
    {
        IEnumerable<ValidatorResult> Validate(LoanRequest request);
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
                new CitizenshipStatusValidator(),
                new TimeTradingValidator(_loanConfig),
                new CountryCodeValidator(),
                new IndustryValidator(_loanConfig),
            };
        }
        public IEnumerable<ValidatorResult> Validate(LoanRequest loan)
        {
            return _validators.SelectMany(validator => validator.Validate(loan));
        }

    }

    public class ValidatorResult
    {
        public string Rule { get; set; }
        public string Message { get; set; }
        public LoanCheckDecision Decision { get; set; }
    }
}