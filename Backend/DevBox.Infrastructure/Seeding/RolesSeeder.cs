using DevBox.Domain.Entities;
using DevBox.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DevBox.Infrastructure.Seeding
{
    public class RolesSeeder
    {
        public static void Seed(DevBoxDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Roles != null && !context.Roles.Any())
            {
                context.Roles.AddRange(
                    new Role { Name = "Admin" },
                    new Role { Name = "User" }
                );

                context.SaveChanges();
            }
        }
    }
}