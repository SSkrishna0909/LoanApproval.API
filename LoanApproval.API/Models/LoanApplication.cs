namespace LoanApproval.API.Models
{
    public class LoanApplication
    {
        public int Id { get; set; }
        public string ApplicantName { get; set; }
        public decimal Amount { get; set; }
        public int CreditScore { get; set; }
        public string Status { get; set; }
    }
}
