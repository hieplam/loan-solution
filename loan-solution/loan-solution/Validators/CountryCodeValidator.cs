using System.Collections.Generic;

namespace loan_solution.Validators
{
    public class CountryCodeValidator : ILoanValidator
    {
        public IEnumerable<ValidatorResult> Validate(LoanRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.CountryCode) || request.CountryCode.ToLower() != Constant.AUSTRILIA_COUNTRY_CODE)
            {
                yield return new ValidatorResult
                {
                    Rule = "CountryCode",
                    Message = "Country code is not valid",
                };
            }
        }
    }
}