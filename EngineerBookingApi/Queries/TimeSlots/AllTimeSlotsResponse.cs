using EngineerBooking.Framework.Models;

namespace EngineerBookingApi.Queries.TimeSlots
{
  public class AllTimeSlotsResponse
  {
    public ICollection<TimeSlot> TimeSlots { get; private set; }
    public AllTimeSlotsResponse(ICollection<TimeSlot> slots) => TimeSlots = slots;
  }
}
