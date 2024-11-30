namespace BackEnd.Models
{
    public class User
    {
        public int UserId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Phone { get; set; }  

        public string? Address {  get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public bool IsApproved { get; set; }
        public bool IsManager { get; set; }
    }
}
