using Domain.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Context
{
    public static class ApplicationDbContextSeed
    {
        public static void Seed(this ModelBuilder builder)
        {
            SeedRoles(builder);
        }

        private static void SeedRoles(this ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "1", Name = Roles.User, NormalizedName = Roles.User.ToUpper() },
            new IdentityRole { Id = "2", Name = Roles.Moderator, NormalizedName = Roles.Moderator.ToUpper() },
            new IdentityRole { Id = "3", Name = Roles.Administrator, NormalizedName = Roles.Administrator.ToUpper() });
        }


    }
}
