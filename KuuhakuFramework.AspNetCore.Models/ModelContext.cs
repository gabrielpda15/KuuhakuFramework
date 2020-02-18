using KuuhakuFramework.AspNetCore.Models.Security;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace KuuhakuFramework.AspNetCore.Models
{
    public class ModelContext : IdentityDbContext<Identity, Role, int, IdentityClaim, IdentityRole, IdentityLogin, RoleClaim, IdentityToken>
    {
        public ModelContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);



            SetTables(builder);
        }

        private void SetTables(ModelBuilder builder)
        {
            builder.Entity<Identity>().ToTable("SEC_Identity");
            builder.Entity<IdentityClaim>().ToTable("SEC_IdentityClaim");
            builder.Entity<IdentityLogin>().ToTable("SEC_IdentityLogin");
            builder.Entity<IdentityRole>().ToTable("SEC_IdentityRole");
            builder.Entity<IdentityToken>().ToTable("SEC_IdentityToken");
            builder.Entity<Role>().ToTable("SEC_Role");
            builder.Entity<RoleClaim>().ToTable("SEC_RoleClaim");
        }
    }
}
