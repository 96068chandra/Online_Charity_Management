using BackEnd.Models;

namespace BackEnd.Repository.Services
{
    public interface IInvoiceRepository:IRepository<Invoice>
    {
        //Retrieve invoices for a specific donor.
        Task<IEnumerable<Invoice>> GetInvoicesByDonorAsync(int donorId);
        //Retrieve invoices within a specific date range.
        Task<IEnumerable<Invoice>> GetInvoicesByDateRangeAsync(DateTime startDate, DateTime endDate);
        //Retrieve detailed information for a specific invoice.
        Task<Invoice> GetInvoiceDetailsAsync(int invoiceId);

    }
}
