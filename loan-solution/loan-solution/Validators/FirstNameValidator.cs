using System.Collections.Generic;

namespace loan_solution.Validators
{
    public class FirstNameValidator : ILoanValidator
    {
        public IEnumerable<ValidateResult> Validate(LoanRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.FirstName))
            {
                yield return new ValidateResult
                {
                    ValidateType = "FirstName",
                    Message = "Firstname is empty"
                };
            }
        }
    }
}