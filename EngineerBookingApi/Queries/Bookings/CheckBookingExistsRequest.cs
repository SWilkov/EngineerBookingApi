using EngineerBooking.Framework.Models;
using MediatR;

namespace EngineerBookingApi.Queries.Bookings
{
  public class CheckBookingExistsRequest : IRequest<CheckBookingExistsResponse>
  {
    public Booking Booking { get; private set; }
    public CheckBookingExistsRequest(Booking booking) => this.Booking = booking;
  }
}
