using BackEnd.Models;
using BackEnd.Repository.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class InvoiceController : BaseController<Invoice>
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceController(IInvoiceRepository invoiceRepository) : base(invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        [HttpGet("donor/{donorId}")]
        public async Task<IActionResult> GetInvoicesByDonor(int donorId)
        {
            var invoices = await _invoiceRepository.GetInvoicesByDonorAsync(donorId);
            return Ok(invoices);
        }

        [HttpGet("date-range")]
        public async Task<IActionResult> GetInvoicesByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var invoices = await _invoiceRepository.GetInvoicesByDateRangeAsync(startDate, endDate);
            return Ok(invoices);
        }

        [HttpGet("{invoiceId}/details")]
        public async Task<IActionResult> GetInvoiceDetails(int invoiceId)
        {
            var invoice = await _invoiceRepository.GetInvoiceDetailsAsync(invoiceId);
            if (invoice == null)
            {
                return NotFound();
            }
            return Ok(invoice);
        }
    }
}