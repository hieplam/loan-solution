using System.Collections.Generic;

namespace loan_solution.Validators
{
    public class LastNameValidator : ILoanValidator
    {
        public IEnumerable<ValidatorResult> Validate(LoanRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.LastName))
            {
                yield return new ValidatorResult
                {
                    Rule = "LastName",
                    Message = "LastName is empty",
                };
            }
        }
    }
}