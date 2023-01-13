using System.ComponentModel;

namespace loan_solution
{
    public class Constant
    {
        public const string AUSTRILIA_COUNTRY_CODE = "au";
        public const string CITIZEN_STATUS = "citizen";
        public const string PERMANENT_RESIDENT_STATUS = "permanent resident";
    }

    public enum LoanCheckDecision
    {
        [Description("Unqualified")]
        Unqualified = 0,
        [Description("Qualified")]
        Qualified = 1,
        [Description("Unknown")]
        Unknown = 2
    }
}