using EngineerBooking.DataLayer.Interfaces;
using EngineerBooking.Framework.Models;
using MediatR;

namespace EngineerBookingApi.Queries.TimeSlots
{
  public sealed class AllTimeSlotsHandler : IRequestHandler<AllTimeSlotsRequest, AllTimeSlotsResponse>
  {
    private readonly IReaderRepository<TimeSlot> _repository;
    public AllTimeSlotsHandler(IReaderRepository<TimeSlot> repository)
    {
      _repository = repository;
    }
    
    public async Task<AllTimeSlotsResponse> Handle(AllTimeSlotsRequest request, CancellationToken cancellationToken)
    {
      if (request is null) throw new ArgumentNullException(nameof(request));

      var slots = await _repository.All();
      if (slots is null || !slots.Any())
      {
        //No bookings
        //TODO maybe to log somewhere
      }

      return new AllTimeSlotsResponse(slots.ToList());
    }
  }
}
