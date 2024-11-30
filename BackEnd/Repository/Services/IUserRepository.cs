using BackEnd.Models;

namespace BackEnd.Repository.Services
{
    public interface IUserRepository:IRepository<User>
    {
        Task<IEnumerable<User>> GetUsersByRoleAsync(string roleName);
        //Retrieve managers who are pending approval.
        Task<IEnumerable<User>> GetPendingManagerApprovalsAsync();
        //Approve a manager's signup request.
        Task<bool> ApproveManagerAsync(int userId);
    }
}
