using CMS.Domain.Entities;

namespace CMS.Domain.Interfaces
{
    public interface IRewardsEmailRepository
    {
        Task<RewardsEmail> CreateAsync(RewardsEmail entity, CancellationToken cancellationToken);
        Task<RewardsEmail> GetByTokenAsync(string token, CancellationToken cancellationToken);
        Task<IEnumerable<RewardsEmail>> GetAllAsync(CancellationToken cancellationToken);
    }
}
