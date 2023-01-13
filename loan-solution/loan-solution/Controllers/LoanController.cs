using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using loan_solution.Validators;

namespace loan_solution.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanValidator _loanValidator;

        public LoanController(ILoanValidator loanValidator)
        {
            _loanValidator = loanValidator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]LoanRequest request)
        {
            var validatorResult = _loanValidator.Validate(request).ToList();
            string finalDecision;
            if (!validatorResult.Any())
            {
                finalDecision = LoanCheckDecision.Qualified.ToString();
            }
            else
            {
                var isHavingUnknown = validatorResult.Any(x => x.Decision == LoanCheckDecision.Unknown);
                if (isHavingUnknown)
                {
                    finalDecision = LoanCheckDecision.Unknown.ToString();
                }
                else
                {
                    finalDecision = LoanCheckDecision.Unqualified.ToString();
                }
            }
            
            var checkLoanResponse = new CheckLoanResponse();
            var validateResults = validatorResult.Select(x => new ValidationResult
            {
                Rule = x.Rule,
                Message = x.Message,
                Decision = x.Decision.ToString()
            }).ToList();
            checkLoanResponse.ValidationResults = validateResults;

            checkLoanResponse.Decision = finalDecision;
            return new JsonResult(checkLoanResponse);
        }
    }
}