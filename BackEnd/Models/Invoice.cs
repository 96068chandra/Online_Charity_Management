using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        [Required]
        public int DonationId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        public int DonorId { get; set; }

        public int? ProgramId { get; set; }

        public int? CharityId { get; set; }

        [ForeignKey("DonationId")]
        public virtual Donation Donation { get; set; }

        [ForeignKey("DonorId")]
        public virtual User Donor { get; set; }

        [ForeignKey("ProgramId")]
        public virtual Program Program { get; set; }

        [ForeignKey("CharityId")]
        public virtual Charity Charity { get; set; }
    }
}
