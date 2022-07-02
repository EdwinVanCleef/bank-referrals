using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Referral.Models
{
    public class Referrals 
    {
        public int RefferalId { get; set; }
        public int UserId { get; set; }
        public int ReferredId { get; set; }
        public DateTime ReferralDate { get; set; }
        public const int ReferralBonus = 25;
    }
}
