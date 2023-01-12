using System.Collections.Generic;

namespace loan_solution.Controllers
{
    public class CheckLoanResponse
    {
        public Decision Decision { get; set; }
        public List<ValidationResult> ValidationResults { get; set; }
    }

    public class ValidationResult
    {
        public string Rule { get; set; }
        public string Message { get; set; }
    }
    
    public enum Decision
    {
        Qualified = 0,
        Unqualified = 1,
        Unknown = 2
    }
}
