using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace loan_solution.Validators
{
    public class LoanAmountValidator : ILoanValidator
    {
        private readonly LoanConfig _loanConfig;

        public LoanAmountValidator(LoanConfig config)
        {
            _loanConfig = config;
        }
        
        public IEnumerable<ValidateResult> Validate(LoanRequest request)
        {
            if (request.LoanAmount <= _loanConfig.MinLoan || request.LoanAmount >= _loanConfig.MaxLoan)
            {
                yield return new ValidateResult
                {
                    ValidateType = "LoanAmount",
                    Message = $"Loan amount should between {_loanConfig.MaxLoan} and {_loanConfig.MinLoan}"
                };
            }
        }
    }
}