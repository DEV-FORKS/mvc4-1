namespace eManager.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using eManager.Domain;
    using System.Web.Security;
    using WebMatrix.WebData;
    using eManager.Web.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<eManager.Web.Infrastructure.DepartmentDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(eManager.Web.Infrastructure.DepartmentDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Departments.AddOrUpdate(
              d => d.Name,
              new Department() { Name= "Accounts" },
              new Department() { Name = "Engineering" },
              new Department() { Name= "Sales" },
              new Department() { Name= "Human Resources" }
            );            

            //if (!Roles.RoleExists("Admin"))
            //{
            //    Roles.CreateRole("Admin");
            //}
            //if (Membership.GetUser("Harsha") == null)
            //{
            //    Membership.CreateUser("Harsha", "MyP@ssw0rd");
            //    Roles.AddUserToRole("Harsha","Admin");
            //}

            WebSecurity.InitializeDatabaseConnection(
            "DefaultConnection",
            "UserProfile",
            "UserId",
            "UserName", autoCreateTables: true);

            if (!Roles.RoleExists("Admin"))
                Roles.CreateRole("Admin");

            if (!WebSecurity.UserExists("Harsha"))
                WebSecurity.CreateUserAndAccount(
                    "Harsha",
                    "password",
                    null);

            if (!Roles.GetRolesForUser("Harsha").Contains("Admin"))
                Roles.AddUsersToRoles(new[] { "Harsha" }, new[] { "Admin" });
        }
    }

}
