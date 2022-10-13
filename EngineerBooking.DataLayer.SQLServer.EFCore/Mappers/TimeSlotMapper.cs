using EngineerBooking.DataLayer.SQLServer.EFCore.DataModels;
using EngineerBooking.DataLayer.SQLServer.EFCore.Interfaces;
using EngineerBooking.Framework.Models;

namespace EngineerBooking.DataLayer.SQLServer.EFCore.Mappers
{
  public class TimeSlotMapper : IMapper<TimeSlot, TimeSlotDataModel>
  {
    public TimeSlotDataModel Map(TimeSlot source)
    {
      if (source is null) throw new ArgumentNullException(nameof(source));

      return new TimeSlotDataModel
      {
        Id = source.Id,
        StartTime = source.StartTime,
        EndTime = source.EndTime,
        DayOfWeek = (int)source.DayOfWeek
      };
    }

    public TimeSlot Map(TimeSlotDataModel source)
    {
      if (source is null) throw new ArgumentNullException(nameof(source));

      return new TimeSlot
      {
        Id = source.Id,
        StartTime = source.StartTime,
        EndTime = source.EndTime,
        DayOfWeek = (Day)source.DayOfWeek
      };
    }
  }
}
