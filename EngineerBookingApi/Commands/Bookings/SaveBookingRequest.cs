using EngineerBooking.Framework.Models;
using MediatR;

namespace EngineerBookingApi.Commands.Bookings
{
  public class SaveBookingRequest : IRequest<SaveBookingResponse>
  {
    public Booking Booking { get; private set; }
    public SaveBookingRequest(Booking booking) => Booking = booking;
  }
}
