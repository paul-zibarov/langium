using Langium.DataLayer.DbModels;
using Langium.Domain;
using Langium.PresentationLayer;
using Langium.WebAPI.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Langium.DataLayer.DataAccessObjects
{
    public class UserDao
    {
        public async Task<DataResult<UserModel>> GetUserByIdAsync(int id)
        {
            using (var context = new LangiumDbContext())
            {
                try
                {
                    var user = await context.Users
                    .Include(u => u.Profile)
                    .FirstOrDefaultAsync(u => u.Id == id);

                    if (user == null)
                    {
                        return new DataResult<UserModel>(null, "USER_NOT_EXISTS");
                    };

                    return new DataResult<UserModel> (user);
                }
                catch (Exception ex)
                {
                    return new DataResult<UserModel> (ex, ex.InnerException.Message);
                }
            }
        }

        public async Task<DataResult<IEnumerable<UserModel>>> GetAllUsersAsync()
        {
            using (var context = new LangiumDbContext())
            {
                try
                {
                    var users = await context.Users
                    .Include(u => u.Profile)
                    .ToListAsync();

                    return new DataResult<IEnumerable<UserModel>> (users);
                }
                catch (Exception ex)
                {
                    return new DataResult<IEnumerable<UserModel>> (ex, ex.InnerException.Message);
                }
            }
        }

        public async Task<DataResult<UserModel>> AddUserAsync(UserAuthDto user)
        {
            using (var context = new LangiumDbContext())
            {
                try
                {
                    var newUser = new UserModel()
                    {
                        Email = user.Email,
                        Password = user.Password,
                        ActivationCode = ActivationHelper.GetActivationCode(),
                        Profile = new ProfileModel
                        {
                            Stats = new StatsModel(),
                            Categories = new List<CategoryModel>()
                        }
                    };

                    var added = await context.Users.AddAsync(newUser);
                    await context.SaveChangesAsync();

                    return new DataResult<UserModel> (added.Entity);
                }
                catch (Exception ex)
                {
                    if(ex.InnerException.Message.Contains("23505"))
                    {
                        return new DataResult<UserModel>(ex, "USER_AlREADY_EXISTS");
                    }
                    else
                    {
                        return new DataResult<UserModel>(ex, ex.InnerException.Message);
                    }
                }
            }
        }

        public async Task<DataResult<UserModel>> UpdateUserAsync(UserModel user)
        {
            using (var context = new LangiumDbContext())
            {
                try
                {
                    context.Entry(user).State = EntityState.Modified;
                    await context.SaveChangesAsync();

                    var updatedUser = context.Users.FirstOrDefault(u => u.Id == user.Id);

                    return new DataResult<UserModel> (updatedUser);
                }
                catch (Exception ex)
                {
                    return new DataResult<UserModel>(ex, ex.InnerException.Message);
                }
            }
        }

        public async Task<DataResult<bool>> RemoveUserAsync(int id)
        {
            using (var context = new LangiumDbContext())
            {
                try
                {
                    var entity = await context.Users.FindAsync(id);

                    if (entity == null)
                    {
                        return new DataResult<bool>(null, "USER_NOT_EXISTS");
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
