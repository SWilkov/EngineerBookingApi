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

    /// <summary>
    /// Handler to retrieve all the Time slots from database
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Response object with Time Slots</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<AllTimeSlotsResponse> Handle(AllTimeSlotsRequest request, CancellationToken cancellationToken)
    {
      if (request is null) throw new ArgumentNullException(nameof(request));

      var slots = await _repository.All();
      if (slots is null || !slots.Any())
      {
        //No bookings
        //TODO maybe to log somewhere
        return new AllTimeSlotsResponse(new List<TimeSlot>());
      }

      return new AllTimeSlotsResponse(slots.ToList());
    }
  }
}
