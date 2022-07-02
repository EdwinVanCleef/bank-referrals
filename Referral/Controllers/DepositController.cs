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
    public class DepositController : ControllerBase
    {
        [HttpPost("[action]")]
        public IActionResult Deposit([FromBody]AccountDeposit account)
        {
            if (!AccountData.AccountList.Any(x => x.AccountId.Equals(account.AccountId)))
                return BadRequest("Account not found");

            AccountData.ApplyDeposit(account.AccountId, account.Deposit);

            var transaction = new Transactions
            {
                AccountId = account.AccountId,
                Amount = account.Deposit,
                TransactionDate = DateTime.Now,
                TransactionId = TransactionData.TransactionList.Count() + 1,
                TranType = TransactionType.Deposit.ToString()
            };

            TransactionData.TransactionList.Add(transaction);

            return Ok("Successful Deposit");
        }
    }
}