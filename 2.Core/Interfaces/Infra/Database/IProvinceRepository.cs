using Domain;

namespace Core;

public interface IProvinceRepository : IBaseRepository<Province>
{
    public Task<Province> GetByIdWithPointOfInterestAsync(Guid id);
}