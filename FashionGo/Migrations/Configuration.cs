namespace FashionGo.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(FashionGo.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var roles = new[] { "Admin", "Editor", "Users" };
            foreach (var role in roles)
            {
                if (!(context.Roles.Any(u => u.Name == role)))
                {
                    context.Roles.Add(new IdentityRole() { Name = role });
                }
            }

            //context.SaveChanges();

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!(context.Users.Any(u => u.UserName == "fashiongovn@gmail.com")))
            {
                var userToInsert = new ApplicationUser { UserName = "fashiongovn@gmail.com", Email = "fashiongovn@gmail.com", PhoneNumber = "0913542486" };
                userManager.Create(userToInsert, "Thoitrangsi@123");
                userManager.AddToRole(userToInsert.Id, "Admin");
            }
            context.SaveChanges();
        }
    }
}
