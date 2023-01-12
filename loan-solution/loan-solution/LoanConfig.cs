namespace loan_solution
{
    public class LoanConfig
    {
        public const string LOAN_CONFIG = nameof(LoanConfig);

        public float MinLoan { get; set; }
        public float MaxLoan { get; set; }
    }
}