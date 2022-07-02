using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Referral.Models
{
    public enum TransactionType
    {
        Deposit,
        Referral
    }

    public class Transactions 
    {
        public int TransactionId { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TranType { get; set; }
    }   
}
