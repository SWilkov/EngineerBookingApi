using System.ComponentModel.DataAnnotations;

namespace EngineerBooking.DataLayer.SQLServer.EFCore.DataModels
{
  public class BookingDataModel : BaseDataModel
  {
    [Required]
    public string VehicleRegistration { get; set; }
    [Required]
    public DateTimeOffset StartDate { get; set; }
    [Required]
    public DateTimeOffset EndDate { get; set; }
    [Required]
    public string JobCategory { get; set; }

    [Required]
    public int CustomerId { get; set; }
    public CustomerDataModel Customer { get; set; }
    public string Comments { get; set; }
  }
}
