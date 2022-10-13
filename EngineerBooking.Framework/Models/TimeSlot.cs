namespace EngineerBooking.Framework.Models
{
  public class TimeSlot : BaseEntity
  {
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public Day DayOfWeek { get; set; }
  }
}
