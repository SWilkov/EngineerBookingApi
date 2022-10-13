namespace EngineerBooking.Framework.Models
{
  public class TimeSlot : BaseEntity
  {
    public TimeSpan Start { get; set; }
    public TimeSpan End { get; set; }
    public Day DayOfWeek { get; set; }
  }
}
