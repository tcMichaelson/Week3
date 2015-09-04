namespace Identity.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Identity.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Identity.Models.ApplicationDbContext";
        }

        protected override void Seed(Identity.Models.ApplicationDbContext context)
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

            context.Users.AddOrUpdate(
                new Models.ApplicationUser {
                    FirstName = "Tom",
                    LastName = "Michaelson",
                    Email = "tc.michaelson@gmail.com"
                },
                new Models.ApplicationUser {
                    FirstName = "Frank",
                    LastName = "Estrada",
                    Email = "freestrada@gmail.com"
                },
                new Models.ApplicationUser {
                    FirstName = "Ed",
                    LastName = "Cantata",
                    Email = "ICanTaTa@gmail.com"
                });
        }
    }
}