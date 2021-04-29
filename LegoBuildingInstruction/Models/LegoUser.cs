using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Models
{
    public class LegoUser : IdentityUser
    {


        public string FirstName { get; set; }
        public string LastName { get; set; }

        List<Comment> Comments { get; set; }

    }
}
