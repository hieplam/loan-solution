using System.Collections.Generic;

namespace loan_solution.Validators
{
    public class EmailValidator: ILoanValidator
    {
        public IEnumerable<ValidateResult> Validate(LoanRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.EmailAddress))
            {
                yield return new ValidateResult
                {
                    ValidateType = "Email",
                    Message = "email is empty"
                };
            }
        }
    }
}