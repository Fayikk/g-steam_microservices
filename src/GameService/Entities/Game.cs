using System.ComponentModel.DataAnnotations.Schema;
using GameService.Model;

namespace GameService.Entities;


public class Game : BaseModel
{
    public string Title { get; set; }
    public string? Description { get; set; }
    [Column(TypeName = "decimal(18, 6)")]
    public decimal Price { get; set; }  
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}