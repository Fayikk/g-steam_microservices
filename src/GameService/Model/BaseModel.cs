namespace GameService.Model;


public abstract class BaseModel
{
    public BaseModel()
    {
        Id = new Guid();
        CreatedDate = DateTime.UtcNow;
    }

    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }

}