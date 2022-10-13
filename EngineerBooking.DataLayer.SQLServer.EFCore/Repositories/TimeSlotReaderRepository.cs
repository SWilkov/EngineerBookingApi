using EngineerBooking.DataLayer.Interfaces;
using EngineerBooking.DataLayer.SQLServer.EFCore.Data;
using EngineerBooking.DataLayer.SQLServer.EFCore.DataModels;
using EngineerBooking.DataLayer.SQLServer.EFCore.Interfaces;
using EngineerBooking.Framework.Models;
using Microsoft.EntityFrameworkCore;

namespace EngineerBooking.DataLayer.SQLServer.EFCore.Repositories
{
  public class TimeSlotReaderRepository : IReaderRepository<TimeSlot>
  {
    private readonly EngineerBookingDataContext _context;
    private readonly IMapper<TimeSlot, TimeSlotDataModel> _mapper;

    public TimeSlotReaderRepository(EngineerBookingDataContext context,
      IMapper<TimeSlot, TimeSlotDataModel> mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<IEnumerable<TimeSlot>> All()
    {
      var dataModels = await _context.TimeSlots        
        .ToListAsync();

      if (dataModels is null) return Enumerable.Empty<TimeSlot>();

      return dataModels.Select(_mapper.Map);
    }

    public async Task<TimeSlot> GetById(int id)
    {
      var dataModel = await _context.TimeSlots        
        .FirstOrDefaultAsync(b => b.Id == id);

      if (dataModel is null) return null;

      return _mapper.Map(dataModel);
    }
  }
}
