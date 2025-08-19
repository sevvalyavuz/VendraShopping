namespace Vendra.Models;

public class UserTypes
{
    public int Id { get; set; }
    public string Grup { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime ModifiedAt { get; set; } = DateTime.Now;
}