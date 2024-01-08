using Microsoft.EntityFrameworkCore;
using VolunteerManagementApp.Models;

namespace VolunteerManagementApp.DAL
{
    public class VolunteerDbContext : DbContext
    {
        public VolunteerDbContext(DbContextOptions<VolunteerDbContext> options) : base(options)
        {
        }

        public DbSet<Volunteer> Volunteers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // You can configure additional settings for your entities here
            // Example: modelBuilder.Entity<Volunteer>().Property(v => v.FirstName).IsRequired();
        }
    } }