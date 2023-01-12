using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace loan_solution.Validators
{
    public class PhoneNumberValidator : ILoanValidator
    {
        public IEnumerable<ValidateResult> Validate(LoanRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.PhoneNumber) 
                || !(IsMobileNumber(request.PhoneNumber) || IsLandlineNumber(request.PhoneNumber)))
            {
                yield return new ValidateResult
                {
                    ValidateType = "PhoneNumber",
                    Message = "phone number is not valid"
                };
            }
        }

        public bool IsLandlineNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"^0(2|3|7|8)\d{8}$");
        }
        
        public bool IsMobileNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"(\+614|04)\d{8}$");
        }
    }
}