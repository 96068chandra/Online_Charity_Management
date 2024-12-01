using BackEnd.Models;
using BackEnd.Repository.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController<User>
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("role/{roleName}")]
        public async Task<IActionResult> GetUsersByRole(string roleName)
        {
            var users = await _userRepository.GetUsersByRoleAsync(roleName);
            return Ok(users);
        }

        [HttpGet("pending-approvals")]
        public async Task<IActionResult> GetPendingManagerApprovals()
        {
            var users = await _userRepository.GetPendingManagerApprovalsAsync();
            return Ok(users);
        }

        [HttpPost("approve-manager/{userId}")]
        public async Task<IActionResult> ApproveManager(int userId)
        {
            var result = await _userRepository.ApproveManagerAsync(userId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
