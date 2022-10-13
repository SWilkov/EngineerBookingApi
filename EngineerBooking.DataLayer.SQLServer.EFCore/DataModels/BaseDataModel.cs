using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineerBooking.DataLayer.SQLServer.EFCore.DataModels
{
  public class BaseDataModel
  {
    [Required]
    public int Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
  }
}
