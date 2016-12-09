using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;


namespace WedDesign_Final_RyanWall.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        //public virtual ICollection<Person> People { get; set; }
        //public virtual ICollection<ToDoList> ToDoLists { get; set; }
        //public virtual ICollection<ShoppingList> ShoppingLists { get; set; }

    }

    public class DBContext : IdentityDbContext<ApplicationUser>
    {
        public DBContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        private static DBContext _databaseContext = null;

        public System.Data.Entity.DbSet<WedDesign_Final_RyanWall.Models.ShoppingList> ShoppingLists { get; set; }
        public System.Data.Entity.DbSet<WedDesign_Final_RyanWall.Models.ToDoList> ToDoLists { get; set; }
        public System.Data.Entity.DbSet<WedDesign_Final_RyanWall.Models.Person> People { get; set; }

        public static DBContext Create()
        {
            _databaseContext = new DBContext();
            return _databaseContext;
        }
    }
}