using BackEnd.Models;
using BackEnd.Repository.Services;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repository
{
    public class CharityRepository : Repository<Charity>, ICharityRepository
    {
        private readonly ApplicationDbContext _context;

        public CharityRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Charity>> GetCharitiesByManagerAsync(int managerId)
        {
            return await _context.Charities
                .Where(c => c.ManagerId == managerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Donation>> GetCharityDonationsAsync(int charityId)
        {
            return await _context.Donations
                .Where(d => d.CharityId == charityId)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalDonationsForCharityAsync(int charityId)
        {
            return await _context.Donations
                .Where(d => d.CharityId == charityId)
                .SumAsync(d => d.Amount);
        }
    }
}
