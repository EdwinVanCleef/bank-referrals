using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Referral.Models
{
    interface IAccountInfo
    {
        int AccountId { get; set; }
        decimal Balance { get; set; }
    }
}
