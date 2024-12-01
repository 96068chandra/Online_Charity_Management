using BackEnd.Models;

namespace BackEnd.Repository.Services
{
    public interface IProgramRepository:IRepository<Programs>
    {
        Task<IEnumerable<Programs>> GetProgramsByManagerAsync(int managerId);
        Task<IEnumerable<Donation>> GetProgramDonationsAsync(int programId);
        Task<decimal> GetTotalDonationsForProgramAsync(int programId);
       
        
    }
}
