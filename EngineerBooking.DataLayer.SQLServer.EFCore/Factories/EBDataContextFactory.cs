using EngineerBooking.DataLayer.SQLServer.EFCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EngineerBooking.DataLayer.SQLServer.EFCore.Factories
{
  /// <summary>
  /// This class is used by the EF Core CLI tools to create a new instance of the context.
  /// Used for migration purposes.
  /// </summary>
  public class EBDataContextFactory : IDesignTimeDbContextFactory<EngineerBookingDataContext>
  {
    public EngineerBookingDataContext CreateDbContext(string[] args)
    {
      var optionsBuilder = new DbContextOptionsBuilder<EngineerBookingDataContext>();
      optionsBuilder.UseSqlServer(@"Server=127.0.0.1\sql1,1433;Database=EngineeringDB;User Id=SA;Password=S3cr3tLunch#;");

      return new EngineerBookingDataContext(optionsBuilder.Options);
    }
  }
}
