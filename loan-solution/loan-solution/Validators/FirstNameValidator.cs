using System.Collections.Generic;

namespace loan_solution.Validators
{
    public class FirstNameValidator : ILoanValidator
    {
        public IEnumerable<ValidatorResult> Validate(LoanRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.FirstName))
            {
                yield return new ValidatorResult
                {
                    Rule = "FirstName",
                    Message = "Firstname is empty",
                };
            }
        }
    }
}