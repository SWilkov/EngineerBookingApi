using EngineerBooking.DataLayer.SQLServer.EFCore.DataModels;
using EngineerBooking.DataLayer.SQLServer.EFCore.Interfaces;
using EngineerBooking.Framework.Models;

namespace EngineerBooking.DataLayer.SQLServer.EFCore.Mappers
{
  public class BookingMapper : IMapper<Booking, BookingDataModel>
  {
    private readonly IMapper<Customer, CustomerDataModel> _customerMapper;
    private readonly IMapper<TimeSlot, TimeSlotDataModel> _timeSlotMapper;
    public BookingMapper(IMapper<Customer, CustomerDataModel> customerMapper,
      IMapper<TimeSlot, TimeSlotDataModel> timeSlotMapper)
    {
      _customerMapper = customerMapper;
      _timeSlotMapper = timeSlotMapper;
    }
    
    public BookingDataModel Map(Booking source)
    {
      if (source is null) throw new ArgumentNullException(nameof(source));

      return new BookingDataModel
      {
        Id = source.Id,
        StartDate = source.StartDate,
        EndDate = source.EndDate,
        VehicleRegistration = String.IsNullOrWhiteSpace(source.VehicleRegistration) ? String.Empty : source.VehicleRegistration,
        Comments = String.IsNullOrWhiteSpace(source.Comments) ? String.Empty : source.Comments,
        CustomerId = source.Customer?.Id ?? 0,
        Customer = _customerMapper.Map(source.Customer),
        JobCategory = String.IsNullOrWhiteSpace(source.JobCategory) ? String.Empty : source.JobCategory
      };    
    }

    public Booking Map(BookingDataModel source)
    {
      if (source is null) throw new ArgumentNullException(nameof(source));

      return new Booking
      {
        Id = source.Id,
        StartDate = source.StartDate,
        EndDate = source.EndDate,
        VehicleRegistration = String.IsNullOrWhiteSpace(source.VehicleRegistration) ? String.Empty : source.VehicleRegistration,
        Comments = String.IsNullOrWhiteSpace(source.Comments) ? String.Empty : source.Comments,
        Customer = source.Customer is null ? throw new NullReferenceException() : _customerMapper.Map(source.Customer),
        JobCategory = String.IsNullOrWhiteSpace(source.JobCategory) ? String.Empty : source.JobCategory        
      };
    }
  }
}
