using System.Collections.Generic;

namespace loan_solution.Validators
{
    public class EmailValidator : ILoanValidator
    {
        public IEnumerable<ValidatorResult> Validate(LoanRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.EmailAddress))
            {
                yield return new ValidatorResult
                {
                    Rule = "Email",
                    Message = "email address is empty",
                };
            }
        }
    }
}