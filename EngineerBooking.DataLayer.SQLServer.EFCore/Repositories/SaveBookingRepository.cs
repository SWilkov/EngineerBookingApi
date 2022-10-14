using EngineerBooking.DataLayer.Interfaces;
using EngineerBooking.DataLayer.SQLServer.EFCore.Data;
using EngineerBooking.DataLayer.SQLServer.EFCore.DataModels;
using EngineerBooking.DataLayer.SQLServer.EFCore.Interfaces;
using EngineerBooking.Framework.Models;
using Microsoft.EntityFrameworkCore;

namespace EngineerBooking.DataLayer.SQLServer.EFCore.Repositories
{
  public sealed class SaveBookingRepository : ISaveRepository<Booking>
  {
    private readonly EngineerBookingDataContext _context;
    private readonly IMapper<Booking, BookingDataModel> _mapper;
    private readonly IReaderRepository<Booking> _readerRepository;
    public SaveBookingRepository(EngineerBookingDataContext context,
      IMapper<Booking, BookingDataModel> mapper,
      IReaderRepository<Booking> readerRepository)
    {
      _context = context;
      _mapper = mapper;
      _readerRepository = readerRepository;
    }

    public async Task<Booking> Save(Booking booking)
    {
      if (booking is null) throw new ArgumentNullException(nameof(booking));

      var dataModel = _mapper.Map(booking);
      
      if (dataModel.Id == default(int))
      {
        var entity = await _context.Bookings.AddAsync(dataModel);
        if (entity.State != EntityState.Added)
        {
          //TODO log something wrong here at Db level!
        }

        await _context.SaveChangesAsync();
        var insertedBooking = await _readerRepository.GetById(entity.Entity.Id);
        return insertedBooking;
      }
      else
      {
        throw new ArgumentException("Not allowing updates to existing bookings yet! Future Dev planned :)");
      }
    }
  }
}
