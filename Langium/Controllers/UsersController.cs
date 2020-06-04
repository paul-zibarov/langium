using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Langium.DataLayer.DataAccessObjects;
using Langium.DataLayer.DbModels;
using Langium.Domain;
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
        public async Task<ActionResult<IEnumerable<UserModel>>> Get()
        {
            var result =  await _dao.GetAllUsersAsync();

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

        // GET api/users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> Get(int id)
        {
            var result = await _dao.GetUserByIdAsync(id);

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

        // POST api/users/register
        [HttpPost("register")]
        public async Task<ActionResult<UserModel>> Register(UserAuthDto regData)
        {
            if(CheckHelper.IsValidEmail(regData.Email))
            {
                var added = await _dao.AddUserAsync(regData);

                if (added.Data != null)
                {
                    return Ok(added);
                }
                else
                {
                    return BadRequest(added);
                }
            }
            else
            {
                return BadRequest(new DataResult<UserModel>(null, "INVALID_EMAIL"));
            }
            
        }

        // POST api/user/auth   
        [HttpPost("auth")]
        public async Task<ActionResult<UserModel>> Auth(UserAuthDto authData)
        {
            var user = _dao.GetAllUsersAsync().Result.Data.Where(u => u.Email == authData.Email && u.Password == authData.Password).ToList();

            if (user.Count() == 1)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest(new DataResult<UserModel>(null, "WRONG_EMAIL_OR_PASSWORD"));
            }
        }

        // PUT api/user/{id}
        [HttpPut("{id}/edit")]
        public async Task<ActionResult<UserModel>> Put(int id, UserUpdateDto userData)
        {
            var user = _dao.GetUserByIdAsync(id).Result.Data;

            if(user != null)
            {
                if(user.Password == userData.CurrentPassword)
                {
                    if(CheckHelper.IsValidEmail(userData.Email))
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

                    return BadRequest(new DataResult<UserModel>(null, "INVALID_EMAIL"));
                }
                
                return BadRequest(new DataResult<UserModel>(null, "WRONG_PASSWORD"));
            }

            return NotFound(new DataResult<UserModel>(null, "USER_NOT_EXISTS"));
        }

        // DELETE api/users/{id}/delete
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
