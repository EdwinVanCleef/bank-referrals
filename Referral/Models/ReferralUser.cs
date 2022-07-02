using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Referral.Models
{
    public class ReferralUser : Referrals, IUserinfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
