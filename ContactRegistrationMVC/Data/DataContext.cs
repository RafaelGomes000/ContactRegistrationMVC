using ContactRegistrationMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;

namespace ContactRegistrationMVC.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ContactModel> Contact { get; set; }
        public DbSet<UserModel> Users { get; set; }

    }
}
