namespace BackEnd.Models
{
    public class Programs
    {
        public int ProgramsId { get; set; }
        public required string ProgramName { get; set; }
        public required string Description { get; set; }
        public string ImageURL { get; set; }
        public decimal TotalDonations { get; set; }
        public int ManagerId { get; set; }
        public virtual User Manager { get; set; }
    }
}
