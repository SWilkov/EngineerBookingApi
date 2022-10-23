using EngineerBooking.Framework.Enums;
using EngineerBooking.Framework.Models;
using MediatR;

namespace EngineerBookingApi.Notifications
{
  /// <summary>
  /// Notification Published when a booking is successfully saved
  /// </summary>
  public class SaveBookingSuccessNotification : INotification
  {
    public Booking Booking { get; private set; }
    public FileLocation FileLocation { get; private set; }
    public SaveBookingSuccessNotification(Booking booking, 
      FileLocation fileLocation = FileLocation.ExecutingAssembly)
    {
      Booking = booking;
      FileLocation = fileLocation;
    }
  }
}
