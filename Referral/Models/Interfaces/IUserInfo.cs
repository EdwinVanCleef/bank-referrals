using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Referral.Models
{
    interface IUserinfo
    {
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
