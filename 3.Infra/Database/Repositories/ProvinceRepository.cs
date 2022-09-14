using Domain;
using Core;

namespace Infra;
public class ProvinceRepository: BaseRepository<Province>, IProvinceRepository
{
    public ProvinceRepository(DataContext context) : base(context)
    {
    }
}