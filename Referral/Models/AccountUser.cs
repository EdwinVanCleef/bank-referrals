using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Referral.Models
{
    public class AccountUser : IAccountInfo, IUserinfo
    {
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
