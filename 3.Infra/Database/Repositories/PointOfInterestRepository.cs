using Domain;
using Core;

namespace Infra;
public class PointOfInterestRepository: BaseRepository<PointOfInterest>, IPointOfInterestRepository
{
    public PointOfInterestRepository(DataContext context) : base(context)
    {
    }
}