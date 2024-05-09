using KursovayaBlazorNet6.Domains;
using KursovayaBlazorNet6.UsersRoles;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace KursovayaBlazorNet6.DataAccessLayer
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Service> Services { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<CategoryUslugi> CategoryUslugi { get; set; }


        public DbSet<CategoryMedic> CategoryMedic { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        

        public DbSet<Reviews> Reviews { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}
