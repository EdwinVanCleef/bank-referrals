using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Referral.Models
{
    public class User : IUserinfo
    {
        [Range(1, 999)]
        [Required(ErrorMessage = "User ID is required")]
        public int UserID { get; set; }

        [StringLength(60, MinimumLength = 2)]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [StringLength(60, MinimumLength = 2)]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
    }
}
