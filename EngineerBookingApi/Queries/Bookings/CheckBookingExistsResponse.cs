using EngineerBooking.Framework.Models;

namespace EngineerBookingApi.Queries.Bookings
{
  public class CheckBookingExistsResponse
  {
    public Booking Booking { get; private set; }
    public CheckBookingExistsResponse(Booking booking) => this.Booking = booking;
  }
}
