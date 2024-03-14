using AutoMapper;
using GameService.Data;
using GameService.DTOs.ForCategory;
using GameService.Entities;
using GameService.Model;

namespace GameService.Services.CategoryServices;

public class CategoryService : ICategoryService
{
    private readonly GameDbContext _dbContext;
    private readonly IMapper _mapper;
    private BaseResponseModel _responseModel;

    public CategoryService(GameDbContext dbContext,IMapper mapper,BaseResponseModel responseModel)
    {
        _responseModel = responseModel;
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel> CreateCategory(CreateCategoryDTO categoryDTO)
    {
       var objResult = _mapper.Map<Category>(categoryDTO);

       await _dbContext.Categories.AddAsync(objResult);

        if (await _dbContext.SaveChangesAsync() > 0)
        {
            _responseModel.IsSuccess = true;
            _responseModel.Message = "Added Process is sucess";
            _responseModel.StatusCode = System.Net.HttpStatusCode.OK;
            return _responseModel;
        }

        _responseModel.IsSuccess = false;
        _responseModel.StatusCode = System.Net.HttpStatusCode.BadGateway;
        return _responseModel;


    }
}