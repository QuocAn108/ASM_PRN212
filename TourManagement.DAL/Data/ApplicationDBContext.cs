using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManagement.DAL.Model;

namespace TourManagement.DAL.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {

        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<TourDestination> TourDestinations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = GetConnectionString();
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("Connection string is not initialized.");
                }
                optionsBuilder.UseSqlServer(connectionString, options =>
                    options.EnableRetryOnFailure(
                        maxRetryCount: 3,
                        maxRetryDelay: TimeSpan.FromSeconds(5),
                        errorNumbersToAdd: null
                    ));
            }
        }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
         .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
         .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
         .Build();

            var strConn = config.GetConnectionString("DefaultConnectionStringDB");

            if (string.IsNullOrEmpty(strConn))
            {
                throw new InvalidOperationException("Connection string is not initialized.");
            }

            return strConn;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TourDestination>()
                .HasKey(td => new { td.LocationId, td.TourId });

            modelBuilder.Entity<TourDestination>()
                .HasOne(td => td.Location)
                .WithMany(kf => kf.TourDestinations)
                .HasForeignKey(td => td.LocationId);

            modelBuilder.Entity<TourDestination>()
                .HasOne(td => td.Tour)
                .WithMany(t => t.TourDestinations)
                .HasForeignKey(td => td.TourId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
