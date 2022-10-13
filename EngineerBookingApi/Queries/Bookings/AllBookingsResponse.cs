using EngineerBooking.Framework.Models;

namespace EngineerBookingApi.Queries.Bookings
{
  public class AllBookingsResponse
  {
    public ICollection<Booking> Bookings { get; private set; }
    public AllBookingsResponse(ICollection<Booking> bookings)
    {
      this.Bookings = bookings;
    }
  }
}
