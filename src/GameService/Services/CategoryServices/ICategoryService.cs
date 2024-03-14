using GameService.DTOs.ForCategory;
using GameService.Model;

namespace GameService.Services.CategoryServices;

public interface ICategoryService 
{
    Task<BaseResponseModel> CreateCategory(CreateCategoryDTO categoryDTO);
}