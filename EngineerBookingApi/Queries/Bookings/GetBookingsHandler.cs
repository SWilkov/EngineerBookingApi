using MediatR;

namespace EngineerBookingApi.Queries.Bookings
{
  public class GetBookingsHandler : IRequestHandler<GetBookingsRequest, GetBookingsResponse>
  {
    public async Task<GetBookingsResponse> Handle(GetBookingsRequest request, CancellationToken cancellationToken)
    {
      if (request is null) throw new ArgumentNullException(nameof(request));
      return null;
    }
  }
}
