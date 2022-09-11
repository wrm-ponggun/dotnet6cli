using System.Drawing;
namespace Core;

public class Province
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    #region Entity Framework Relationship
        public ICollection<PointOfInterest> PointOfInterests { get; set; }
    #endregion
}