using EngineerBooking.DataLayer.SQLServer.EFCore.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineerBooking.DataLayer.SQLServer.EFCore.Data
{
  public static class DatabaseInitialiser
  {
    public static void SeedData()
    {
      var optionsBuilder = new DbContextOptionsBuilder<EngineerBookingDataContext>();
      optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EngineeringDB;Trusted_Connection=True;");

      //using (var context = new EngineerBookingDataContext(optionsBuilder.Options))
      //{
      //  context.Database.EnsureCreated();
        
      //  if (!context.Customers.Any())
      //  {
      //    var customers = new List<CustomerDataModel>
      //    {
      //      new CustomerDataModel             
      //      { 
      //        FirstName = "John",
      //        LastName = "Smith",
      //        Email = "jsmith@msn.com",
      //        ContactNumber = "111 444 555",
      //        Postcode = "S1 N56",
      //        Street = "11 James Street",
      //        City = "London",
      //        Bookings = null              
      //      },
      //      new CustomerDataModel 
      //      { 
      //        FirstName = "Jane",
      //        LastName = "Doe",
      //        Email = "janedoe@outlook.com",
      //        ContactNumber = "689 444 555",
      //        Postcode = "N22 N56",
      //        Street = "3B Rutherford Close",
      //        City = "Durham",
      //        Bookings = null
      //      }
      //    };
      //    context.Customers.AddRange(customers);

      //    context.SaveChanges();
      //  }
        
      //  if (!context.TimeSlots.Any())
      //  {
      //    var slots = new List<TimeSlotsDataModel>()
      //    {
      //      new TimeSlotsDataModel
      //      {
      //        Day = 1,
      //        Start = TimeOnly.FromTimeSpan(TimeSpan.FromHours(8)),
      //        End = TimeOnly.FromTimeSpan(TimeSpan.FromHours(10)),
      //      },
      //      new TimeSlotsDataModel
      //      {
      //        Day = 1,
      //        Start = TimeOnly.FromTimeSpan(TimeSpan.FromHours(11)),
      //        End = TimeOnly.FromTimeSpan(TimeSpan.FromHours(13))
      //      },
      //      new TimeSlotsDataModel
      //      {
      //        Day = 1,
      //        Start = TimeOnly.FromTimeSpan(TimeSpan.FromHours(14)),
      //        End = TimeOnly.FromTimeSpan(TimeSpan.FromHours(16))
      //      }
      //    };
      //    context.TimeSlots.AddRange(slots);
      //    context.SaveChanges();
      //  }

      //  if (!context.Bookings.Any())
      //  {
      //    var booking = new BookingDataModel
      //    {
      //      Date = new DateTimeOffset(2022, 10, 15, 7, 0, 0, TimeSpan.FromHours(0)),
      //      Comments = "Some comment!",
      //      JobCategory = "warranty",
      //      VehicleRegistration = "AA15 BBU",
      //      CustomerId = 1,
      //      TimeSlotId = 1
      //    };
      //    context.Bookings.Add(booking);
      //    context.SaveChanges();
      //  }
      //}
    }
  }
}