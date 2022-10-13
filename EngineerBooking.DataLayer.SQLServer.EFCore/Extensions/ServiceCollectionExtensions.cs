using EngineerBooking.DataLayer.Interfaces;
using EngineerBooking.DataLayer.SQLServer.EFCore.Data;
using EngineerBooking.DataLayer.SQLServer.EFCore.DataModels;
using EngineerBooking.DataLayer.SQLServer.EFCore.Interfaces;
using EngineerBooking.DataLayer.SQLServer.EFCore.Mappers;
using EngineerBooking.DataLayer.SQLServer.EFCore.Repositories;
using EngineerBooking.Framework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EngineerBooking.DataLayer.SQLServer.EFCore.Extensions
{
  public static class ServiceCollectionExtensions
  {
    public static void AddSQLServer(this IServiceCollection services, string connectionString)
    {
      #region Database
      services.AddDbContext<EngineerBookingDataContext>(options =>
        options.UseSqlServer(connectionString));
      #endregion

      #region Mappers
      services.AddScoped<IMapper<Booking, BookingDataModel>, BookingMapper>();
      services.AddScoped<IMapper<Customer, CustomerDataModel>, CustomerMapper>();
      services.AddScoped<IMapper<TimeSlot, TimeSlotDataModel>, TimeSlotMapper>();
      #endregion

      #region Repositories
      services.AddScoped<IReaderRepository<Booking>, BookingReaderRepository>();
      services.AddScoped<ISaveRepository<Booking>, SaveBookingRepository>();
      #endregion

    }
  }
}
