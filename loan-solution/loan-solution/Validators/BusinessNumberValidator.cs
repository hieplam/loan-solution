using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace loan_solution.Validators
{
    public class BusinessNumberValidator : ILoanValidator
    {
        private readonly IMemoryCache _memoryCache;

        public BusinessNumberValidator(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
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
            _memoryCache.TryGetValue(businessNumber, out bool? result);
            if (result.HasValue)
            {
                return result.Value;
            }
            
            return await Task.Run(() =>
            {
                //simulate external service call
                Thread.Sleep(1000);
                var ok = !string.IsNullOrWhiteSpace(businessNumber) && businessNumber.Length == 11;
                _memoryCache.Set(businessNumber, ok);
                return ok;
            });
        }
    }
}