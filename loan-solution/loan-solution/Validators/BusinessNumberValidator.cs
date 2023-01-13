using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace loan_solution.Validators
{
    public class BusinessNumberValidator : ILoanValidator
    {
        public IEnumerable<ValidatorResult> Validate(LoanRequest request)
        {
            var isBusinessNumber = IsValidBusinessNumber(request.BusinessNumber);
            if (!isBusinessNumber.Result)
            {
                yield return new ValidatorResult
                {
                    Rule = "BusinessNumber",
                    Message = "BusinessNumber is not correct",
                };
            }
        }

        public async Task<bool> IsValidBusinessNumber(string businessNumber)
        {
            return await Task.Run(() =>
            {
                //simulate external service call
                Thread.Sleep(1000);
                return !string.IsNullOrWhiteSpace(businessNumber) && businessNumber.Length == 11;
            });
        }
    }
}