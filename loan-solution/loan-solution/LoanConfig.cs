using System.Collections.Generic;

namespace loan_solution
{
    public class LoanConfig
    {
        public const string LOAN_CONFIG = nameof(LoanConfig);

        public float MinLoan { get; set; }
        public float MaxLoan { get; set; }

        public int MaxTimeTrading { get; set; }
        public int MinTimeTrading { get; set; }
        public List<string> BlacklistIndustry { get; set; }
        public List<string> WhitelistIndustry { get; set; }
    }
}