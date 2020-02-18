using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KuuhakuFramework.AspNetCore.Models.Security
{
    public class IdentityRole : IdentityUserRole<int>
    {
        [Key]
        public override int RoleId { get; set; }

        [Key]
        public override int UserId { get; set; }
    }
}
