namespace BackEnd.Models
{
    public class Donation
    {
        public int DonationId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int DonorId { get; set; }
        public int? ProgramId { get; set; }
        public int? CharityId { get; set; }
        public virtual User Donor { get; set; }
        public virtual Programs Program { get; set; }
        public virtual Charity Charity { get; set; }
    }
}
