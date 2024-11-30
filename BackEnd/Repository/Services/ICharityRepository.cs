using BackEnd.Models;

namespace BackEnd.Repository.Services
{
    public interface ICharityRepository:IRepository<Charity>
    {
        //GetCharitiesByManager: Retrieve charities managed by a specific manager.
        Task<IEnumerable<Charity>> GetCharitiesByManagerAsync(int managerId);
        //GetCharityDonations: Retrieve donations for a specific charity.
        Task<IEnumerable<Donation>> GetCharityDonationsAsync(int charityId);
        //GetTotalDonationsForCharity: Calculate the total donations for a specific charity.

        Task<decimal> GetTotalDonationsForCharityAsync(int charityId);
    }

}
