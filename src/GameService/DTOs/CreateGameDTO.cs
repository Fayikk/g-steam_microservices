namespace GameService.DTOs;


public class CreateGameDTO 
{
     public string Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }  
    public string CategoryId { get; set; }
}