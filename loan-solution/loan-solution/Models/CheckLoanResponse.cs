using System.Collections.Generic;

namespace loan_solution.Controllers
{
    public class CheckLoanResponse
    {
        public string Decision { get; set; }
        public List<ValidationResult> ValidationResults { get; set; }
    }

    public class ValidationResult
    {
        public string Rule { get; set; }
        public string Message { get; set; }
        public string Decision { get; set; }
    }
}
