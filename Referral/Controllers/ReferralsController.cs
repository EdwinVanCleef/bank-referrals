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
    public class ReferralsController : ControllerBase
    {
        [HttpGet("referrals")]
        public IActionResult Get(int pageNumber = 1, int pageSize = 10)
        {
            if (ReferralsData.ReferralsList.Count == 0)
                return NotFound("No data available");

            var referralList = ReferralsData.ReferralsList
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            return Ok(referralList);
        }

        [HttpPost("[action]")]
        public IActionResult ExecuteReferral([FromBody]ReferralUser referral)
        {
            if (!UserData.UserList.Any(x => x.UserID.Equals(referral.UserId)))
                return BadRequest("User does not exist.");

            var referralUser = new User
            {
                FirstName = referral.FirstName,
                LastName = referral.LastName,
                UserID = referral.ReferredId
            };

            var referrals = new Referrals
            {
                UserId = referral.UserId,
                ReferralDate = referral.ReferralDate,
                ReferredId = referral.ReferredId,
                RefferalId = referral.RefferalId
            };

            UserData.UserList.Add(referralUser);
            ReferralsData.ReferralsList.Add(referrals);
            AccountData.ApplyReferralIncentive(referral.UserId);

            var transaction = new Transactions
            { 
                AccountId = AccountData.AccountId, 
                Amount = Referrals.ReferralBonus, 
                TransactionDate = DateTime.Now,
                TransactionId = TransactionData.TransactionList.Count() + 1, 
                TranType = TransactionType.Referral.ToString()
            };

            TransactionData.TransactionList.Add(transaction);

            return Ok("Successfuly applied referral");
        }
    }
}