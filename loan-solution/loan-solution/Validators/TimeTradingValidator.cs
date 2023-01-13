using System.Collections.Generic;

namespace loan_solution.Validators
{
    public class TimeTradingValidator : ILoanValidator
    {
        private readonly LoanConfig _loanConfig;

        public TimeTradingValidator(LoanConfig config)
        {
            _loanConfig = config;
        }
        public IEnumerable<ValidatorResult> Validate(LoanRequest request)
        {
            if (request.TimeTrading <= _loanConfig.MinTimeTrading || request.TimeTrading >= _loanConfig.MaxTimeTrading)
            {
                yield return new ValidatorResult
                {
                    Rule = "TimeTrading",
                    Message = $"time trading should between {_loanConfig.MaxTimeTrading} and {_loanConfig.MinTimeTrading}"
                };
            }
        }
    }
}