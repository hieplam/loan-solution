namespace loan_solution
{
    public class LoanRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string BusinessNumber { get; set; }
        public float  LoanAmount { get; set; }
        public float  CitizenshipStatus { get; set; }
        public int    TimeTrading { get; set; }
        public int    CountryCode { get; set; }
        public int    Industry { get; set; }
    }
}