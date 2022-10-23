using EngineerBooking.Framework.Models;
using EngineerBookingApi.Framework.Models;

namespace EngineerBooking.DataLayer.Interfaces
{
  public interface IBookingReaderRepository : IReaderRepository<Booking>
  {
    Task<Booking> GetByDate(Booking booking);
    Task<IEnumerable<Booking>> Get(BookingParameters bookingParameters);
  }
}
