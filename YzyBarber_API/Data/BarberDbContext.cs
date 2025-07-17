using Microsoft.EntityFrameworkCore;
using YzyBarber_API.Entities;

namespace YzyBarber_API.Data
{
    public class BarberDbContext:DbContext
    {
        public BarberDbContext(DbContextOptions<BarberDbContext> options) : base(options)
        {
        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Barber> Barbers { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Company> Companies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Company Configuration
            modelBuilder.Entity<Company>(builder =>
            {
                builder.HasKey(c => c.CompanyId);
            });

            // Branch Configuration
            modelBuilder.Entity<Branch>(builder =>
            {
                builder.HasKey(b => b.BranchId);

                builder.HasOne(b => b.Company)
                       .WithMany()
                       .HasForeignKey(b => b.CompanyId)
                       .OnDelete(DeleteBehavior.Restrict);
            });

            // Client Configuration
            modelBuilder.Entity<Client>(builder =>
            {
                builder.HasKey(c => c.ClientId);
            });

            // Barber Configuration
            modelBuilder.Entity<Barber>(builder =>
            {
                builder.HasKey(b => b.BarberId);

                builder.HasOne(b => b.Branch)
                       .WithMany()
                       .HasForeignKey(b => b.BranchId)
                       .OnDelete(DeleteBehavior.Restrict);
            });

            // Appointment Configuration
            modelBuilder.Entity<Appointment>(builder =>
            {
                builder.HasKey(a => a.AppointmentId);

                builder.HasOne(a => a.Client)
                       .WithMany()
                       .HasForeignKey(a => a.ClientId)
                       .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(a => a.Barber)
                       .WithMany()
                       .HasForeignKey(a => a.BarberId)
                       .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
