using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Referral.Data;
using Referral.Models;

namespace Referral.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("user")]
        public IActionResult Get(int pageNumber = 1, int pageSize = 10)
        {
            if (UserData.UserList.Count == 0)
                return NotFound("No data available");

            var userList = UserData.UserList
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            return Ok(userList);
        }

        // TODO AUTO GENERATED USER ID
        [HttpPost("user/[action]")]
        public IActionResult Create([FromBody]User user)
        {
            if (UserData.UserList.Any(x => x.FirstName.Equals(user.FirstName) &&
                x.LastName.Equals(user.LastName)))
                return BadRequest("User already exists.");

            UserData.UserList.Add(user);

            if (!AccountData.AccountList.Any(x => x.UserId.Equals(user.UserID)))
            {
                AccountData.AccountList.Add(new Account()
                {
                    AccountId = 1,
                    Balance = 0.00M,
                    UserId = user.UserID,
                });
            }

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("user/[action]/{id}")]
        public IActionResult Update(int id, [FromBody]User user)
        {
            if (!UserData.UserList.Any(x => x.UserID.Equals(id)))
                return BadRequest("Employee does not exist");

            UserData.UserList[id - 1] = user;
            return Ok("User record updated successfully");
        }

        [HttpDelete("user/[action]/{id}")]
        public IActionResult Delete(int id)
        {
            if (!UserData.UserList.Any(x => x.UserID.Equals(id)))
                return BadRequest("User record updated successfully");

            UserData.UserList.RemoveAt(id - 1);
            return Ok("User record deleted successfully");
        }
    }
}