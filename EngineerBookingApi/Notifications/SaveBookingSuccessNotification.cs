using EngineerBooking.Framework.Models;
using MediatR;

namespace EngineerBookingApi.Notifications
{
  public class SaveBookingSuccessNotification : INotification
  {
    public Booking Booking { get; private set; }
    public SaveBookingSuccessNotification(Booking booking) 
    {
      this.Booking = booking;
    }
  }
}
