using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infra;
public class DataContext: DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {

    }

    #region DbSet List
    public DbSet<Province> Provinces { get; set; }
    public DbSet<PointOfInterest> PointOfInterests { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ProvinceConfiguration());
        builder.ApplyConfiguration(new PointOfInterestConfiguration());
    }
}