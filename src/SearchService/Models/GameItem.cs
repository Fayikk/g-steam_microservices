using MongoDB.Entities;

namespace SearchService.Models;


public class GameItem : Entity
{
     public string Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }  
    public Guid CategoryId { get; set; }
}