namespace BackEnd.Models
{
    public class Charity
    {
        public int CharityId { get; set; }
        public required string CharityName { get; set; }
        public required string Description { get; set; }
        public required string ImageURL { get; set; }
        public decimal TotalDonations { get; set; }
        public int ManagerId { get; set; }
        public virtual User Manager { get; set; }
    }
}
