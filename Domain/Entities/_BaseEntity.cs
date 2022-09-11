using System.Security.Principal;
namespace Domain;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public bool IsActive { get; set; } 
}