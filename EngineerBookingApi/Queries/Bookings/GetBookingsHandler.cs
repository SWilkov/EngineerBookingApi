using EngineerBooking.DataLayer.Interfaces;
using EngineerBooking.Framework.Models;
using MediatR;

namespace EngineerBookingApi.Queries.Bookings
{
  public class GetBookingsHandler : IRequestHandler<GetBookingsRequest, GetBookingsResponse>
  {
    private readonly IBookingReaderRepository _repository;
    public GetBookingsHandler(IBookingReaderRepository repository)
    {
      _repository = repository;
    }
    
    /// <summary>
    /// Get Bookings using pagination
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>List of bookings</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<GetBookingsResponse> Handle(GetBookingsRequest request, CancellationToken cancellationToken)
    {
      if (request is null) throw new ArgumentNullException(nameof(request));
      if (request.BookingParameters is null) throw new ArgumentNullException(nameof(request.BookingParameters));
      
      var bookings = await _repository.Get(request.BookingParameters);
      if (bookings is null || !bookings.Any())
      {
        //No bookings
        //TODO maybe to log somewhere
        return new GetBookingsResponse(new List<Booking>());
      }

      return new GetBookingsResponse(bookings.ToList());
    }
  }
}
