using Microsoft.EntityFrameworkCore;

namespace BackEnd.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Programs> Programs { get; set; }
        public DbSet<Charity> Charities { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed roles
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Admin" },
                new Role { RoleId = 2, RoleName = "Manager" },
                new Role { RoleId = 3, RoleName = "Donor" }
            );

            // User and Role
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId);

            // Program and Manager
            modelBuilder.Entity<Programs>()
                .HasOne(p => p.Manager)
                .WithMany()
                .HasForeignKey(p => p.ManagerId);

            // Charity and Manager
            modelBuilder.Entity<Charity>()
                .HasOne(c => c.Manager)
                .WithMany()
                .HasForeignKey(c => c.ManagerId);

            // Donation and User (Donor)
            modelBuilder.Entity<Donation>()
                .HasOne(d => d.Donor)
                .WithMany()
                .HasForeignKey(d => d.DonorId);

            // Donation and Program
            modelBuilder.Entity<Donation>()
                .HasOne(d => d.Program)
                .WithMany()
                .HasForeignKey(d => d.ProgramId);

            // Donation and Charity
            modelBuilder.Entity<Donation>()
                .HasOne(d => d.Charity)
                .WithMany()
                .HasForeignKey(d => d.CharityId);

            // Invoice and Donation
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Donation)
                .WithOne()
                .HasForeignKey<Invoice>(i => i.DonationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Invoice and User (Donor)
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Donor)
                .WithMany()
                .HasForeignKey(i => i.DonorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Invoice and Program
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Program)
                .WithMany()
                .HasForeignKey(i => i.ProgramId)
                .OnDelete(DeleteBehavior.Restrict);

            // Invoice and Charity
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Charity)
                .WithMany()
                .HasForeignKey(i => i.CharityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
