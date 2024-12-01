using BackEnd.Models;
using BackEnd.Repository.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class CharityController : BaseController<Charity>
    {
        private readonly ICharityRepository _charityRepository;

        public CharityController(ICharityRepository charityRepository) : base(charityRepository)
        {
            _charityRepository = charityRepository;
        }

        [HttpGet("manager/{managerId}")]
        public async Task<IActionResult> GetCharitiesByManager(int managerId)
        {
            var charities = await _charityRepository.GetCharitiesByManagerAsync(managerId);
            return Ok(charities);
        }

        [HttpGet("{charityId}/donations")]
        public async Task<IActionResult> GetCharityDonations(int charityId)
        {
            var donations = await _charityRepository.GetCharityDonationsAsync(charityId);
            return Ok(donations);
        }

        [HttpGet("{charityId}/total-donations")]
        public async Task<IActionResult> GetTotalDonationsForCharity(int charityId)
        {
            var totalDonations = await _charityRepository.GetTotalDonationsForCharityAsync(charityId);
            return Ok(totalDonations);
        }
    }
}
