using BackEnd.Models;
using BackEnd.Repository.Services;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repository
{
    public class ProgramRepository :Repository<Programs>, IProgramRepository
    {
        private readonly ApplicationDbContext _context;

        public ProgramRepository(ApplicationDbContext context) :base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Programs>> GetProgramsByManagerAsync(int managerId)
        {
            return await _context.Programs
                .Where(p => p.ManagerId == managerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Donation>> GetProgramDonationsAsync(int programId)
        {
            return await _context.Donations
                .Where(d => d.ProgramId == programId)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalDonationsForProgramAsync(int programId)
        {
            return await _context.Donations
                .Where(d => d.ProgramId == programId)
                .SumAsync(d => d.Amount);
        }
    }
}
