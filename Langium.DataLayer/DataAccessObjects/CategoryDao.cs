using Langium.DataLayer.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Langium.DataLayer.DataAccessObjects
{
    class CategoryDao
    {
        public async Task<CategoryModel> GetCategoryByIdAsync(int id)
        {
            using (var context = new LangiumDbContext())
            {
                try
                {
                    var category = await context.Categories
                    .Include(c => c.Words)
                    .FirstOrDefaultAsync(c => c.Id == id);

                    if (category == null)
                    {
                        return null;
                    }

                    return category;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                    return null;
                }
            }
        }

        public async Task<CategoryModel> AddCategoryAsync(CategoryModel category)
        {
            using (var context = new LangiumDbContext())
            {
                try
                {
                    var added = await context.Categories.AddAsync(category);
                    await context.SaveChangesAsync();
                    return added.Entity;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                    return null;
                }
            }
        }

        public async Task<CategoryModel> UpdateCategoryAsync(CategoryModel category)
        {
            using (var context = new LangiumDbContext())
            {
                try
                {
                    context.Entry(category).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                    return category;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                    return null;
                }
            }
        }

        public async Task<bool> RemoveCategoryAsync(int id)
        {
            using (var context = new LangiumDbContext())
            {
                try
                {
                    var entity = await context.Categories.FindAsync(id);

                    if (entity == null)
                    {
                        return false;
                    }

                    context.Remove(entity);
                    await context.SaveChangesAsync();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                    return false;
                }

            }
        }
    }
}
