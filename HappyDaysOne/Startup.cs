//owin is open web interface for .Net, it defines standard interface between web server and .Net
//each Owin app has a startup class that is configured with different components
//the startup class contains the configuration method used to create roles and users
using Microsoft.Owin;
using Owin;
using HappyDaysOne.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
 

[assembly: OwinStartupAttribute(typeof(HappyDaysOne.Startup))]
namespace HappyDaysOne
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        // This method is used to create default User roles and Admin user for login of the app   
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //creating 1st admin role and default admin user  
            if (!roleManager.RoleExists("Admin"))
            {
                // creating 1st admin ROLE
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //creating default admin superUser to maintain the site, validation logic for usernames and pw is found in HappyDaysOne/App_Start/IndentityConfig.cs
                var superUser = new ApplicationUser();
                superUser.UserName = "ClareShiels";
                superUser.Email = "clare.cashin@gmail.com";

                string superUserPWD = "Twilight1";

                var chkUser = UserManager.Create(superUser, superUserPWD);

                //Add default superUser to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(superUser.Id, "Admin");

                }
            }

            //creating a clubManager role
            if (!roleManager.RoleExists("Club Manager"))
            {
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "Club Manager";
                    roleManager.Create(role);
            }

            // creating a Child's Guardian role    
            if (!roleManager.RoleExists("Child's Guardian"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Child's Guardian";
                roleManager.Create(role);

            }
        }
    }
}
