namespace Core;

public class PointOfInterest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    #region Entity Framework Relationship
        public Province Province { get; set; }
        public Guid ProvinceId { get; set; }
    #endregion
}
