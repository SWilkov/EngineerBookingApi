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
      var serializer = new XmlSerializer(notification.Booking.GetType());

      var doc = new XmlDocument();
      using (var writer = doc.CreateNavigator().AppendChild())
      {
        serializer.Serialize(writer, notification.Booking);
      }
      //using var textWriter = new StreamWriter($"booking_{notification.Booking.Id}.xml");
      //serializer.Serialize(textWriter, notification.Booking);
    }
  }
}
