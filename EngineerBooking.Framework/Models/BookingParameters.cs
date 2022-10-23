namespace EngineerBookingApi.Framework.Models
{
  public class BookingParameters
  {    
    public int PageNumber { get; set; } = 1;
    public int BookingsPerPage { get; set; } = 10;
  }
}
