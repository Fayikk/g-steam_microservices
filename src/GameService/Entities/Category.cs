using GameService.Model;

namespace GameService.Entities;


public class Category : BaseModel
{
    public string CategoryName { get; set; }   = default!; 
    public string CategoryDescription { get; set; } = default!;
    public ICollection<Game> Games { get; set; }
}