

using System.Text.Json.Serialization;

namespace EngineerBooking.Framework.Models
{
  public class Booking : BaseEntity
  {
    public Booking()
    {

    }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public string VehicleRegistration { get; set; } = default!;
    public string JobCategory { get; set; } = default!;
    public Customer Customer { get; set; } = default!;    
    public string Comments { get; set; } = default!;    
  }
}
