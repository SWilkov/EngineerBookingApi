using EngineerBooking.Framework.Models;

namespace EngineerBooking.DataLayer.Interfaces
{
  public interface IBookingReaderRepository : IReaderRepository<Booking>
  {
    Task<Booking> GetByDate(Booking booking);
  }
}
