using BackEnd.Models;
using BackEnd.Repository.Services;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repository
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        private readonly ApplicationDbContext _context;

        public InvoiceRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesByDonorAsync(int donorId)
        {
            return await _context.Invoices
                .Where(i => i.DonorId == donorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Invoices
                .Where(i => i.Date >= startDate && i.Date <= endDate)
                .ToListAsync();
        }

        public async Task<Invoice> GetInvoiceDetailsAsync(int invoiceId)
        {
            return await _context.Invoices
                .Include(i => i.Donation)
                .Include(i => i.Donor)
                .Include(i => i.Program)
                .Include(i => i.Charity)
                .FirstOrDefaultAsync(i => i.InvoiceId == invoiceId);
        }
    }
}
