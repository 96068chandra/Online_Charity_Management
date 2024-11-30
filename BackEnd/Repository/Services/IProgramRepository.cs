using BackEnd.Models;

namespace BackEnd.Repository.Services
{
    public interface IProgramRepository
    {
    //   Task<IEnumerable<Program>> GetProgramsByManagerAsync(int managerId);
        Task<IEnumerable<Donation>> GetProgramDonationsAsync(int programId);
        Task<decimal> GetTotalDonationsForProgramAsync(int programId);
       
        
    }
}
