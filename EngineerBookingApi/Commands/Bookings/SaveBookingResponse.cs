using EngineerBooking.Framework.Models;

namespace EngineerBookingApi.Commands.Bookings
{
    public class SaveBookingResponse
    {
    public Booking Booking { get; private set; }
    public bool IsSuccess { get; set; } = false;
    public string Message { get; set; } = string.Empty;
    public SaveBookingResponse(Booking booking, bool isSuccess = true)
    {
      this.Booking = booking;
      this.IsSuccess = isSuccess;
    }
  }
}
