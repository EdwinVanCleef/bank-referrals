using Referral.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Referral.Data
{
    public class UserData
    {
        public static List<User> UserList = new List<User>()
        {
            new User() {FirstName = "Joel", LastName = "Cruz", UserID = 1},
            new User() {FirstName = "Dave", LastName = "Mirra", UserID = 2}
        };
    }
}
