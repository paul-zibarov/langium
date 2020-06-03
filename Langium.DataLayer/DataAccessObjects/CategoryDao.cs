using Langium.DataLayer.DbModels;
using Langium.PresentationLayer;
using Langium.PresentationLayer.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Langium.DataLayer.DataAccessObjects
{
    public class CategoryDao
    {
        public async Task<DataResult<CategoryModel>> GetCategoryByIdAsync(int id)
        {
            using (var context = new LangiumDbContext())
            {
                try
                {
                    var category = await context.Categories
                    .Include(c => c.Words)
                        .ThenInclude(w => w.Lexeme)
                    .Include(c => c.Words)
                        .ThenInclude(w => w.Transcription)
                    .Include(c => c.Words)
                        .ThenInclude(w => w.Translations)
                    .FirstOrDefaultAsync(c => c.Id == id);

                    if (category == null)
                    {
                        return new DataResult<CategoryModel>(null, "CATEGORY_NOT_EXISTS");
                    };

                    return new DataResult<CategoryModel>(category);
                }
                catch (Exception ex)
                {
                    return new DataResult<CategoryModel>(ex, ex.InnerException.Message);
                }
            }
        }

        public async Task<DataResult<IEnumerable<CategoryModel>>> GetUserCategoriesAsync(int profileId)
        {
            using (var context = new LangiumDbContext())
            {
                try
                {
                    var categories = await context.Categories
                    .Include(c => c.Words)
                        .ThenInclude(w => w.Lexeme)
                    .Include(c => c.Words)
                        .ThenInclude(w => w.Transcription)
                    .Include(c => c.Words)
                        .ThenInclude(w => w.Translations)
                    .Where(c => c.ProfileId == profileId)
                    .ToListAsync();

                    return new DataResult<IEnumerable<CategoryModel>>(categories);
                }
                catch (Exception ex)
                {
                    return new DataResult<IEnumerable<CategoryModel>>(ex, ex.InnerException.Message);
                }
            }
        }

        public async Task<DataResult<CategoryModel>> AddCategoryAsync(CategoryAddDto category)
        {
            using (var context = new LangiumDbContext())
            {
                try
                {
                    var newCategory = new CategoryModel()
                    {
                        Name = category.Name,
                        Description = category.Description,
                        Words = new List<WordModel>(),
                        ProfileId = category.ProfileId
                    };

                    var categoryWithSameName = await context.Categories.FirstOrDefaultAsync(c => c.Name == category.Name && c.ProfileId == category.ProfileId);

                    if (categoryWithSameName == null)
                    {
                        var added = await context.Categories.AddAsync(newCategory);
                        await context.SaveChangesAsync();

                        return new DataResult<CategoryModel>(added.Entity);
                    }
                    else
                    {
                        return new DataResult<CategoryModel>(null, "CATEGORY_WITH_SAME_NAME_AlREADY_EXISTS");
                    }
                }
                catch (Exception ex)
                {
                    return new DataResult<CategoryModel>(ex, ex.InnerException.Message);
                }
            }
        }

        public async Task<DataResult<CategoryModel>> UpdateCategoryAsync(CategoryModel category)
        {
            using (var context = new LangiumDbContext())
            {
                try
                {
                    context.Entry(category).State = EntityState.Modified;
                    await context.SaveChangesAsync();

                    var updatedCategory = context.Categories.FirstOrDefault(c => c.Id == category.Id);

                    return new DataResult<CategoryModel>(updatedCategory);
                }
                catch (Exception ex)
                {
                    return new DataResult<CategoryModel>(ex, ex.InnerException.Message);
                }
            }
        }

        public async Task<DataResult<bool>> RemoveCategoryAsync(int id)
        {
            using (var context = new LangiumDbContext())
            {
                try
                {
                    var entity = await context.Categories.FindAsync(id);

                    if (entity == null)
                    {
                        return new DataResult<bool>(null, "CATEGORY_NOT_EXISTS");
                    }

                    context.Remove(entity);

                    await context.SaveChangesAsync();

                    return new DataResult<bool>(true);
                }
                catch (Exception ex)
                {
                    return new DataResult<bool>(ex, ex.Message);
                }
            }
        }
    }
}
