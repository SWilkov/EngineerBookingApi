using System.ComponentModel.DataAnnotations;

namespace EngineerBooking.DataLayer.SQLServer.EFCore.DataModels
{
  public class CustomerDataModel : BaseDataModel
  {
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string ContactNumber { get; set; }
    [Required]
    public string Street { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string Postcode { get; set; }
    public ICollection<BookingDataModel> Bookings { get; set; }
  }
}
