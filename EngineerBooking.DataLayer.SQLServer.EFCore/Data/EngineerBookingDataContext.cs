using EngineerBooking.DataLayer.SQLServer.EFCore.DataModels;
using Microsoft.EntityFrameworkCore;

namespace EngineerBooking.DataLayer.SQLServer.EFCore.Data
{
  public class EngineerBookingDataContext : DbContext
  {
    public DbSet<BookingDataModel> Bookings { get; set; }
    public DbSet<CustomerDataModel> Customers { get; set; }
    public DbSet<TimeSlotDataModel> TimeSlots { get; set; }

    public EngineerBookingDataContext(DbContextOptions<EngineerBookingDataContext> options) : base(options)
    {
      
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasDefaultSchema("engineering");
      
      modelBuilder.Entity<BookingDataModel>()
        .HasKey(x => x.Id);
      
      modelBuilder.Entity<BookingDataModel>()
        .HasOne(b => b.Customer)
        .WithMany(c => c.Bookings)
        .HasForeignKey(b => b.CustomerId)
        .OnDelete(DeleteBehavior.Cascade);
      
      modelBuilder.Entity<BookingDataModel>()
        .Property(x => x.VehicleRegistration)
        .HasMaxLength(8);
      
      modelBuilder.Entity<BookingDataModel>()
        .Property(x => x.Comments)
        .HasMaxLength(500);
      
      modelBuilder.Entity<CustomerDataModel>()
        .HasKey(x => x.Id);

      modelBuilder.Entity<TimeSlotDataModel>()
        .HasKey(x => x.Id);
    }    
  }
}
