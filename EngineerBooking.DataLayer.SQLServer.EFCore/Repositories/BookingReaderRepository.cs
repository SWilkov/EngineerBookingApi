using EngineerBooking.DataLayer.Interfaces;
using EngineerBooking.DataLayer.SQLServer.EFCore.Data;
using EngineerBooking.DataLayer.SQLServer.EFCore.DataModels;
using EngineerBooking.DataLayer.SQLServer.EFCore.Interfaces;
using EngineerBooking.Framework.Models;
using Microsoft.EntityFrameworkCore;

namespace EngineerBooking.DataLayer.SQLServer.EFCore.Repositories
{
  public class BookingReaderRepository : IReaderRepository<Booking>
  {
    private readonly EngineerBookingDataContext _context;
    private readonly IMapper<Booking, BookingDataModel> _mapper;

    public BookingReaderRepository(EngineerBookingDataContext context,
      IMapper<Booking, BookingDataModel> mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<IEnumerable<Booking>> All()
    {
      var dataModels = await _context.Bookings
        .Include(b => b.Customer)
        .ToListAsync();

      if (dataModels is null) return Enumerable.Empty<Booking>();

      return dataModels.Select(_mapper.Map);
    }

    public async Task<Booking> GetById(int id)
    {
      var dataModel = await _context.Bookings
        .Include(b => b.Customer)        
        .FirstOrDefaultAsync(b => b.Id == id);

      if (dataModel is null) return null;

      return _mapper.Map(dataModel);
    }
  }
}
