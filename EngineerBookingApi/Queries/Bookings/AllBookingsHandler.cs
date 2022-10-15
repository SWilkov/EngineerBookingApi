using EngineerBooking.DataLayer.Interfaces;
using EngineerBooking.Framework.Models;
using MediatR;

namespace EngineerBookingApi.Queries.Bookings
{
  public sealed class AllBookingsHandler : IRequestHandler<AllBookingsRequest, AllBookingsResponse>
  {
    private readonly IBookingReaderRepository _repository;
    public AllBookingsHandler(IBookingReaderRepository repository)
    {
      _repository = repository;
    }
    
    public async Task<AllBookingsResponse> Handle(AllBookingsRequest request, CancellationToken cancellationToken)
    {
      if (request is null) throw new ArgumentNullException(nameof(request));

      var bookings = await _repository.All();
      if (bookings is null || !bookings.Any())
      {
        //No bookings
        //TODO maybe to log somewhere
      }

      return new AllBookingsResponse(bookings.ToList());
    }
  }
}
