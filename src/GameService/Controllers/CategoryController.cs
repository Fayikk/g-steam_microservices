using GameService.DTOs.ForCategory;
using GameService.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace GameService.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }


    [HttpPost]
    public async Task<ActionResult> CreateCategory(CreateCategoryDTO model)
    {
        var result = await _categoryService.CreateCategory(model);
        return Ok(result);

    }

}