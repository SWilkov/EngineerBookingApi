using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineerBooking.DataLayer.SQLServer.EFCore.DataModels
{
  public class TimeSlotDataModel : BaseDataModel
  {
    [Required]
    public TimeSpan Start { get; set; }
    [Required]
    public TimeSpan End { get; set; }
    [Required]
    public int DayOfWeek { get; set; }
  }
}
