using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.CategoryDTOs;
using EntityLayer.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CategoryController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult GetListCategory()
        {
            var values = _mapper.Map<List<ResultCategoryDTO>>(_categoryService.TGetListAll());
            if (values == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(values);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var findCategory = _mapper.Map<GetCategoryDTO>(_categoryService.TGetById(id));
            if (findCategory == null) 
            { 
                return NotFound();
            }
            else
            {
                return Ok(findCategory);
            }
        }
		[HttpGet("GetCategoryCount")]
        public IActionResult GetCategoryCount()
        {
            var categoryCount = _mapper.Map<int>(_categoryService.TGetCategoryCount());
			return Ok(categoryCount);


		}
		[HttpGet("ActiveCategoryCount")]
		public IActionResult ActiveCategoryCount()
		{
			var categoryCount = _mapper.Map<int>(_categoryService.TActiveCategoryCount());
			return Ok(categoryCount);


		}
		[HttpGet("PassiveCategoryCount")]
		public IActionResult PassiveCategoryCount()
		{
			var categoryCount = _mapper.Map<int>(_categoryService.TPassiveCategoryCount());
			return Ok(categoryCount);


		}
		[HttpPost]
        public IActionResult CreateCategory(CreateCategoryDTO p)
        {
            var value = _mapper.Map<Category>(p);
            _categoryService.TInsert(value);
            return Ok("Kategori Başarıyla Eklendi.");
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDTO p)
        {
			var value = _mapper.Map<Category>(p);
			_categoryService.TUpdate(value);
			return Ok("Kategori Başarıyla Güncellendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var findCategory=_categoryService.TGetById(id);
            _categoryService.TDelete(findCategory);
            return Ok("Kategori Başarıyla Silindi.");
        }
    }
}
