using BackEnd.Models;
using BackEnd.Repository.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class DonationController : BaseController<Donation>
    {
        private readonly IDonationRepository _donationRepository;

        public DonationController(IDonationRepository donationRepository) : base(donationRepository)
        {
            _donationRepository = donationRepository;
        }

        [HttpGet("donor/{donorId}")]
        public async Task<IActionResult> GetDonationsByDonor(int donorId)
        {
            var donations = await _donationRepository.GetDonationsByDonorAsync(donorId);
            return Ok(donations);
        }

        [HttpGet("date-range")]
        public async Task<IActionResult> GetDonationsByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var donations = await _donationRepository.GetDonationsByDateRangeAsync(startDate, endDate);
            return Ok(donations);
        }

        [HttpGet("total")]
        public async Task<IActionResult> GetTotalDonations()
        {
            var totalDonations = await _donationRepository.GetTotalDonationsAsync();
            return Ok(totalDonations);
        }
    }
}
