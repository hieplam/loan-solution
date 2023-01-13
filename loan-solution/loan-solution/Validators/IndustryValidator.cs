using System;
using System.Collections.Generic;
using System.Linq;

namespace loan_solution.Validators
{
    public class IndustryValidator : ILoanValidator
    {
        private readonly LoanConfig _loanConfig;

        public IndustryValidator(LoanConfig config)
        {
            _loanConfig = config;
        }

        public IEnumerable<ValidatorResult> Validate(LoanRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Industry) 
                || _loanConfig.BlacklistIndustry.Any(x => x.Equals(request.Industry.ToLower(), StringComparison.OrdinalIgnoreCase)))
            {
                yield return new ValidatorResult
                {
                    Rule = "Industry",
                    Message = "Industry is not valid",
                    Decision = LoanCheckDecision.Unqualified
                };
            } else if (!_loanConfig.WhitelistIndustry.Any(x => x.Equals(request.Industry.ToLower(), StringComparison.OrdinalIgnoreCase)))
            {
                yield return new ValidatorResult
                {
                    Rule = "Industry",
                    Message = "Industry is un-know",
                    Decision = LoanCheckDecision.Unknown
                };
            }
        }
    }
}