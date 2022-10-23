using EngineerBooking.Framework.Models;

namespace EngineerBookingApi.Queries.Bookings
{
  public class GetBookingsResponse
  {
    public ICollection<Booking> Bookings { get; private set; }
    public GetBookingsResponse(ICollection<Booking> bookings)
    {
      this.Bookings = bookings;
    }
  }
}
