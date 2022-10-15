using EngineerBooking.Framework.Models;
using MediatR;
using System.Xml;
using System.Xml.Serialization;

namespace EngineerBookingApi.Notifications
{
  public class SaveBookingToXmlHandler : INotificationHandler<SaveBookingSuccessNotification>
  {
    public async Task Handle(SaveBookingSuccessNotification notification, CancellationToken cancellationToken)
    {
      if (notification is null) throw new ArgumentNullException(nameof(notification));
      if (notification.Booking is null) throw new ArgumentNullException(nameof(notification.Booking));

      //TODO serializer should be injected in the constructor for testing purposes
      //TODO This is erroring with an InvalidOpException something to do with teh Types in Booking
      var serializer = new XmlSerializer(typeof(Booking));

      var doc = new XmlDocument();
      using (var writer = doc.CreateNavigator().AppendChild())
      {
        serializer.Serialize(writer, notification.Booking);
      }     
    }
  }
}
