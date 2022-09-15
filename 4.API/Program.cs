using Microsoft.EntityFrameworkCore;
using Core;
using Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

#region Configure IOption Pattern 
// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-6.0

builder.Services.Configure<MailGunEmailProviderOptions>(
    builder.Configuration.GetSection(MailGunEmailProviderOptions.ConfigItem));

builder.Services.Configure<SendgridEmailProviderOptions>(
    builder.Configuration.GetSection(SendgridEmailProviderOptions.ConfigItem));

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await SeedDatabase();

app.Run();

async Task SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbcontext = scope.ServiceProvider.GetRequiredService<DataContext>();
        await dbcontext.Database.MigrateAsync(); // Run migration scripts
        await Infra.Seed.SeedData(dbcontext); // Seed data to the project
    }
}
