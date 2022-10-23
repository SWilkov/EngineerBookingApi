using EngineerBookingApi.Framework.Models;
using MediatR;

namespace EngineerBookingApi.Queries.Bookings
{
  public class GetBookingsRequest : IRequest<GetBookingsResponse>
  {
    public BookingParameters BookingParameters { get; private set; }
    public GetBookingsRequest(BookingParameters bookingParameters) =>
      this.BookingParameters = bookingParameters;
  }
}
