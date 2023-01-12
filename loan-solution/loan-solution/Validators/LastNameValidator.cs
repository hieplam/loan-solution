using System.Collections.Generic;

namespace loan_solution.Validators
{
    public class LastNameValidator : ILoanValidator
    {
        public IEnumerable<ValidateResult> Validate(LoanRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.LastName))
            {
                yield return new ValidateResult
                {
                    ValidateType = "LastName",
                    Message = "LastName is empty"
                };
            }
        }
    }
}