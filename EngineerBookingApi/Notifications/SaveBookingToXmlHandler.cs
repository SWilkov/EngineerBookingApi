using EngineerBooking.Framework.Interfaces;
using EngineerBooking.Framework.Models;
using MediatR;
using System.Xml.Serialization;

namespace EngineerBookingApi.Notifications
{
  ///Convert Booking to an Xml Doc and save to File  
  public class SaveBookingToXmlHandler : INotificationHandler<SaveBookingSuccessNotification>
  {
    private readonly IFilePathService _filePathService;
    public SaveBookingToXmlHandler(IFilePathService filePathService)
    {
      _filePathService = filePathService;
    }
    
    public async Task Handle(SaveBookingSuccessNotification notification, CancellationToken cancellationToken)
    {
      if (notification is null) throw new ArgumentNullException(nameof(notification));
      if (notification.Booking is null) throw new ArgumentNullException(nameof(notification.Booking));
            
      var serializer = new XmlSerializer(typeof(Booking));

      var path = _filePathService.GetPath(notification.FileLocation, $"booking_{notification.Booking.Id}.xml");
      if (string.IsNullOrEmpty(path))
      {
        //TODO log somewhere
        path = $"booking_{notification.Booking.Id}.xml";
      }
              
      var file = File.Create(path);        
      serializer.Serialize(file, notification.Booking);     
    }
  }
}
