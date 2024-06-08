using AutoMapper;
using CodeFirst;
using CodeFirst.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace CodeFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository categoryRepository = new CategoryRepository();
        private IMapper mapper;
        public CategoryController(IMapper mapper) {
            this.mapper = mapper;
        }

        [HttpGet("list-category")]
        public IActionResult Get()
        {
            List<Category> categories = categoryRepository.GetAll();
            List<CategoryDTO> categoriesDTO = mapper.Map<List<CategoryDTO>>(categories);
            return Ok(categoriesDTO);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = categoryRepository.Get(id);
            if (category == null) return NotFound("Category not found!");
            return Ok(category);
        }
        [HttpPost]
        public IActionResult Post([FromBody] CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                Category category = mapper.Map<Category>(categoryDTO);
                categoryRepository.Insert(category);
                // Trả về kết quả thành công và URI của tài nguyên mới
                return Created(Request.GetDisplayUrl(), categoryDTO);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CategoryDTO categoryDTO)
        {
            if (id != categoryDTO.Id) return BadRequest("Cannt update id category");
            var category = categoryRepository.Get(id);
            if (category == null) return NotFound("Category not found!");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Category categoryUpdate = mapper.Map<Category>(categoryDTO);
            categoryUpdate.Id = categoryDTO.Id;
            categoryRepository.Update(categoryUpdate);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = categoryRepository.Get(id);
            if (category == null) return NotFound("Category not found!");
            else
            {
                categoryRepository.Delete(id);
                return NoContent();
            }
        }
    }
}
