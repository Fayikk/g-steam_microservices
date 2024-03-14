namespace Contracts;


public class AddGame
{
    public string Id { get; set; }
     public string Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }  
    public Guid CategoryId { get; set; }
}