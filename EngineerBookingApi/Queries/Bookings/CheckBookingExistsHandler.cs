using EngineerBooking.DataLayer.Interfaces;
using EngineerBooking.Framework.Models;
using MediatR;

namespace EngineerBookingApi.Queries.Bookings
{
  public class CheckBookingExistsHandler : IRequestHandler<CheckBookingExistsRequest, CheckBookingExistsResponse>
  {
    private readonly IBookingReaderRepository _repository;
    public CheckBookingExistsHandler(IBookingReaderRepository repository)
    {
      _repository = repository;
    }

    public async Task<Booking> Handle(CheckBookingExistsRequest request, CancellationToken cancellationToken)
    {
      if (request is null) throw new ArgumentNullException(nameof(request));
      if (request.Booking is null) throw new ArgumentNullException(nameof(request.Booking));

      var booking = await _repository.GetByDate(request.Booking);
      return new CheckBookingExistsResponse(booking);
    }
  }
}
