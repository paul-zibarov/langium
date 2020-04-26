using Langium.DataLayer.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Langium.DataLayer.DataAccessObjects
{
    public class UserDao
    {
        public async Task<UserModel> GetByIdAsync(int id)
        {
            using (var context = new LangiumDbContext())
            {
                try
                {
                    var user = await context.Users
                    .Include(u => u.Profile)
                        .ThenInclude(p => p.Stats)
                     .Include(u => u.Profile)
                        .ThenInclude(p => p.Categories)
                    .FirstOrDefaultAsync(u => u.Id == id);

                    if (user == null)
                    {
                        return null;
                    }

                    return user;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                    return null;
                }
            }
        }

        public async Task<UserModel> AddUserAsync(UserModel user)
        {
            using (var context = new LangiumDbContext())
            {
                try
                {
                    var added = await context.Users.AddAsync(user);
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

        public async Task<UserModel> UpdateUserAsync(UserModel user)
        {
            using (var context = new LangiumDbContext())
            {
                try
                {
                    context.Entry(user).State = EntityState.Modified;
                    context.Entry(user).Property(u => u.Password).IsModified = true;
                    await context.SaveChangesAsync();
                    return user;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                    return null;
                }
            }
        }

        public async Task<bool> RemoveAsync(int id)
        {
            using (var context = new LangiumDbContext())
            {
                try
                {
                    var entity = await context.Users.FindAsync(id);

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
