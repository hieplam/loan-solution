using System.Collections.Generic;

namespace loan_solution.Validators
{
    public class CitizenshipStatusValidator : ILoanValidator
    {
        public IEnumerable<ValidatorResult> Validate(LoanRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.CitizenshipStatus)
                || (request.CitizenshipStatus.ToLower() != Constant.CITIZEN_STATUS && request.CitizenshipStatus.ToLower() != Constant.PERMANENT_RESIDENT_STATUS))
            {
                yield return new ValidatorResult
                {
                    Rule = "CitizenshipStatus",
                    Message = "Citizenship status is not valid",
                };
            } 
        }
    }
}