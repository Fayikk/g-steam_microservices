using System.Net;

namespace GameService.Model;


public class BaseResponseModel
{
    public BaseResponseModel()
    {
        ErrorMessages = new List<string>();
        
    }


    public object Result { get; set; }  
    public List<string> ErrorMessages { get; set; }
    public string Message { get; set; }
    public bool IsSuccess { get; set; } 
    public HttpStatusCode StatusCode {get; set;}

}