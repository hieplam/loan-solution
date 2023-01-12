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
            var result = _loanValidator.Validate(request);
            return new JsonResult(result);
        }
    }
}