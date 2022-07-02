using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Referral.Models;

namespace Referral.Data
{
    public class TransactionData
    {
        public static List<Transactions> TransactionList = new List<Transactions>()
        {
            new Transactions() {Amount = 100.00M, TransactionDate = DateTime.Now,
                TransactionId = 1, TranType = TransactionType.Deposit.ToString(), AccountId = 1},
            new Transactions() {Amount = 25.00M, TransactionDate = DateTime.Now,
                TransactionId = 2, TranType = TransactionType.Referral.ToString(), AccountId = 1}
        };
    }
}
