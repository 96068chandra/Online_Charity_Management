using BackEnd.Models;
using BackEnd.Repository.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class ProgramController : BaseController<Programs>
    {
        private readonly IProgramRepository _programRepository;

        public ProgramController(IProgramRepository programRepository) : base(programRepository)
        {
            _programRepository = programRepository;
        }

        [HttpGet("manager/{managerId}")]
        public async Task<IActionResult> GetProgramsByManager(int managerId)
        {
            var programs = await _programRepository.GetProgramsByManagerAsync(managerId);
            return Ok(programs);
        }

        [HttpGet("{programId}/donations")]
        public async Task<IActionResult> GetProgramDonations(int programId)
        {
            var donations = await _programRepository.GetProgramDonationsAsync(programId);
            return Ok(donations);
        }

        [HttpGet("{programId}/total-donations")]
        public async Task<IActionResult> GetTotalDonationsForProgram(int programId)
        {
            var totalDonations = await _programRepository.GetTotalDonationsForProgramAsync(programId);
            return Ok(totalDonations);
        }
    }
}
