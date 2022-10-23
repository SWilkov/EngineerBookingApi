using EngineerBooking.Framework.Interfaces;
using EngineerBooking.Framework.Models;
using EngineerBookingApi.Notifications;
using MediatR;
using Moq;

namespace EngineeringApiTests
{
  public class SaveBookingToXmlHandlerTests
  {
    private INotificationHandler<SaveBookingSuccessNotification> _handler;
    private Mock<IFilePathService> _mockFilePathService;
    public SaveBookingToXmlHandlerTests()
    {
      _mockFilePathService = new Mock<IFilePathService>();
      _handler = new SaveBookingToXmlHandler(_mockFilePathService.Object);
    }

    [Fact]
    public void Test()
    {
      var booking = new Booking
      {
        Id = 1,
        Customer = new Customer
        {
          Id = 1,
          FirstName = "Jason",
          LastName = "Bourne",
          Email = "bourne@identity.com",
          ContactNumber = "1234",
          Address = new Address
          {
            Street = "5th Ave.",
            City = "Mew York",
            Postcode = "AA16 7UN"
          }
        },
        Comments = "Hello!",
        JobCategory = "Engineer Visist",
        StartDate = DateTime.Now,
        EndDate = DateTime.Now.AddHours(1),
        VehicleRegistration = "AA13B77"
      };

      var notification = new SaveBookingSuccessNotification(booking);
      _handler.Handle(notification, default);

    }
  }
}
