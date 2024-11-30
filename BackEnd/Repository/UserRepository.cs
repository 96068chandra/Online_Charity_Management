using BackEnd.Models;
using BackEnd.Repository.Services;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> ApproveManagerAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null || user.Role.RoleName != "Manager")
            {
                return false;
            }

            user.IsApproved = true;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<User>> GetPendingManagerApprovalsAsync()
        {
            return await _context.Users
           .Where(u => u.Role.RoleName == "Manager" && !u.IsApproved)
           .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUsersByRoleAsync(string roleName)
        {
            return await _context.Users
            .Include(u => u.Role)
            .Where(u => u.Role.RoleName == roleName)
            .ToListAsync();
        }
    }
}
