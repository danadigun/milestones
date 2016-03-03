namespace Milestones.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<Milestones.Models.MilestoneDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Milestones.Models.MilestoneDb context)
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
            SeedMembership();
        }
        private void SeedMembership()
        {
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);

            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            //Create Admin role
            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }
            if (membership.GetUser("Daniel Adigun", false) == null)
            {
                membership.CreateUserAndAccount("Daniel Adigun", "morphy");
            }
            if (!roles.GetRolesForUser("Daniel Adigun").Contains("Admin"))
            {
                roles.AddUsersToRoles(new[] { "Daniel Adigun" }, new[] { "Admin" });
            }
            //create Milestones admin
            //Create Admin role
            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }
            if (membership.GetUser("admin@milestones", false) == null)
            {
                membership.CreateUserAndAccount("admin@milestones", "pass119");
            }
            if (!roles.GetRolesForUser("admin@milestones").Contains("Admin"))
            {
                roles.AddUsersToRoles(new[] { "admin@milestones" }, new[] { "Admin" });
            }
        }
    }
}
