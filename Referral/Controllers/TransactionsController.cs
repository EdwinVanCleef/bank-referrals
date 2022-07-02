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
    public class TransactionsController : ControllerBase
    {
        [HttpGet("transactions")]
        public IActionResult Get(int pageNumber = 1, int pageSize = 10)
        {
            if (TransactionData.TransactionList.Count == 0)
                return NotFound("No data available");

            var transactionList = TransactionData.TransactionList
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            return Ok(transactionList);
        }

        [HttpGet("transactions/[action]")]
        public IActionResult Search(int accountId)
        {
            var transactionList = TransactionData.TransactionList.Where(
                x => x.AccountId.Equals(accountId));

            if (transactionList.Count() == 0)
                return NotFound("Tranasction not found");

            return Ok(transactionList);
        }
    }
}