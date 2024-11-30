using BackEnd.Models;

namespace BackEnd.Repository.Services
{
    public interface IDonationRepository:IRepository<Donation>
    {
        // Retrieve donations made by a specific donor.
        Task<IEnumerable<Donation>> GetDonationsByDonorAsync(int donorId);
        //Retrieve donations within a specific date range.
        Task<IEnumerable<Donation>> GetDonationsByDateRangeAsync(DateTime startDate, DateTime endDate);
        // Calculate the total amount of donations.
        Task<decimal> GetTotalDonationsAsync();
    }
}
