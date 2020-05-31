using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Langium.DataLayer.DataAccessObjects;
using Langium.DataLayer.DbModels;
using Langium.PresentationLayer;
using Langium.PresentationLayer.ViewModels;
using Langium.WebAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Langium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserDao _dao = new UserDao();

        // GET api/users
        [HttpGet]
        public async Task<DataResult<IEnumerable<UserModel>>> Get()
        {
            return await _dao.GetAllUsersAsync();
        }

        // GET api/users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> Get(int id)
        {
            var user = await _dao.GetUserByIdAsync(id);

            if(user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound(user);
            }
        }

        // POST api/users/register
        [HttpPost("register")]
        public async Task<ActionResult<UserModel>> Post(UserAuthDto user)
        {
            var added = await _dao.AddUserAsync(user);
            
            if(added != null)
            {
                return Ok(added);
            }
            else
            {
                return BadRequest(added);
            }
            
        }

        // PUT api/user/5
        [HttpPut("{id}/edit")]
        public async Task<ActionResult<UserModel>> Put(int id, UserUpdateDto userData)
        {
            var user = _dao.GetUserByIdAsync(id).Result.Data;

            if(user != null)
            {
                if(user.Password == userData.CurrentPassword)
                {
                    if (!string.IsNullOrEmpty(userData.Email))
                    {
                        user.Email = userData.Email;
                    }

                    if (!string.IsNullOrEmpty(userData.NewPassword))
                    {
                        user.Password = userData.NewPassword;
                    }

                    var result = await _dao.UpdateUserAsync(user);

                    return Ok(result);
                }
                
                return BadRequest(new DataResult<UserModel>(null, "WRONG_PASSWORD"));
            }

            return NotFound(new DataResult<UserModel>(null, "USER_NOT_EXISTS"));
        }

        // DELETE api/users/5/delete
        [HttpDelete("{id}/delete")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var result = await _dao.RemoveUserAsync(id);

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
