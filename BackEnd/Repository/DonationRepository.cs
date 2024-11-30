using BackEnd.Models;
using BackEnd.Repository.Services;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repository
{
    public class DonationRepository : Repository<Donation>, IDonationRepository
    {
        private readonly ApplicationDbContext _context;

        public DonationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Donation>> GetDonationsByDonorAsync(int donorId)
        {
            return await _context.Donations
                .Where(d => d.DonorId == donorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Donation>> GetDonationsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Donations
                .Where(d => d.Date >= startDate && d.Date <= endDate)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalDonationsAsync()
        {
            return await _context.Donations
                .SumAsync(d => d.Amount);
        }
    }
}
