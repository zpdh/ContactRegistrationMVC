using ContactRegistrationMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactRegistrationMVC.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<ContactModel> Contacts { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }

}
