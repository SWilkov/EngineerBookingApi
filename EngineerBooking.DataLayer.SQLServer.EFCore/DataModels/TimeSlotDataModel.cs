using System.ComponentModel.DataAnnotations;

namespace EngineerBooking.DataLayer.SQLServer.EFCore.DataModels
{
  public class TimeSlotDataModel : BaseDataModel
  {
    [Required]
    public TimeSpan StartTime { get; set; }
    [Required]
    public TimeSpan EndTime { get; set; }
    [Required]
    public int DayOfWeek { get; set; }
  }
}
