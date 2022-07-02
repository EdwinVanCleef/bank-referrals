using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Referral.Data;

namespace Referral.Controllers
{
    [Route("api")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpGet("account")]
        public IActionResult Get(int accountId)
        {
            var accountList = AccountData.AccountUserList().Where(
                x => x.AccountId.Equals(accountId));

            if (accountList.Count() == 0)
                return NotFound("Account not found");

            return Ok(accountList);
        }
    }
}