using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Referral.Models
{
    public class Account : IAccountInfo
    {
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public int UserId { get; set; }
    }
}
