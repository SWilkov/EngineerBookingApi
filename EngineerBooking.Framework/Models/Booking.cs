namespace EngineerBooking.Framework.Models
{
  public class Booking : BaseEntity
  {
    public DateTimeOffset Date { get; set; }
    public string VehicleRegistration { get; set; } = default!;
    public string JobCategory { get; set; } = default!;
    public Customer Customer { get; set; } = default!;
    public string Comments { get; set; } = default!;
    public TimeSlot TimeSlot { get; set; } = default!;
  }
}
