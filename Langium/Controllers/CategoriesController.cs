using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Langium.DataLayer.DataAccessObjects;
using Langium.DataLayer.DbModels;
using Langium.PresentationLayer;
using Langium.PresentationLayer.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Langium.WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryDao _dao = new CategoryDao();

        // GET api/categories/profile/{id}
        [HttpGet("profile/{id}")]
        public async Task<ActionResult<IEnumerable<CategoryModel>>> GetProfileCategories(int id)
        {
            var result = await _dao.GetUserCategoriesAsync(id);

            if (result.Data.Count() != 0 && result.Succeded && result.Exception == null && string.IsNullOrEmpty(result.ErrorMessage))
            {
                return Ok(result);
            }
            else if (result.Exception == null)
            {
                return NotFound(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        // GET api/categories/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryModel>> GetCategory(int id)
        {
            var result = await _dao.GetCategoryByIdAsync(id);

            if (result.Data != null && result.Succeded && result.Exception == null && string.IsNullOrEmpty(result.ErrorMessage))
            {
                return Ok(result);
            }
            else if (result.Exception == null)
            {
                return NotFound(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        // POST api/categories/add
        [HttpPost("add")]
        public async Task<ActionResult<UserModel>> Post(CategoryAddDto category)
        {
            var result = await _dao.AddCategoryAsync(category);

            if (result.Data != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("{id}/edit")]
        public async Task<ActionResult<UserModel>> Put(int id, CategoryUpdateDto categoryData)
        {
            var category = _dao.GetCategoryByIdAsync(id).Result.Data;

            if (category!= null)
            {
                var userCategories = _dao.GetUserCategoriesAsync(id).Result.Data.Where(c => c.Name == categoryData.Name).ToList();

                if (userCategories.Count() != 0 || string.IsNullOrEmpty(categoryData.Name))
                {
                    return BadRequest(new DataResult<CategoryModel>(null, "CATEGORY_WITH_SAME_NAME_AlREADY_EXISTS"));
                }
                else
                {
                    category.Name = categoryData.Name;
                    category.Description = categoryData.Description;
                    var result = await _dao.UpdateCategoryAsync(category);

                    return Ok(result);
                }
            }

            return NotFound(new DataResult<CategoryModel>(null, "CATEGORY_NOT_EXISTS"));
        }

        // DELETE api/users/5/delete
        [HttpDelete("{id}/delete")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var result = await _dao.RemoveCategoryAsync(id);

            if (result.Succeded)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
    }
}
