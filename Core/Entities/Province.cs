namespace Core;

public class Province: BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    #region Entity Framework Relationship
        public ICollection<PointOfInterest> PointOfInterests { get; set; }
    #endregion
}