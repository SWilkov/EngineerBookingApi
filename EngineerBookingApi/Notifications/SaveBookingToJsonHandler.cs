using EngineerBooking.Framework.Interfaces;
using MediatR;
using Newtonsoft.Json;

namespace EngineerBookingApi.Notifications
{

  /// <summary>
  /// Convert Booking to json and save to File
  /// </summary>
  public class SaveBookingToJsonHandler : INotificationHandler<SaveBookingSuccessNotification>
  {
    private readonly IFilePathService _filePathService;
    public SaveBookingToJsonHandler(IFilePathService filePathService)
    {
      _filePathService = filePathService;
    }
    
    public async Task Handle(SaveBookingSuccessNotification notification, CancellationToken cancellationToken)
    {
      if (notification is null) throw new ArgumentNullException(nameof(notification));
      if (notification.Booking is null) throw new ArgumentNullException(nameof(notification.Booking));
      
      var json = JsonConvert.SerializeObject(notification.Booking);

      if (string.IsNullOrWhiteSpace(json))
      {
        //TODO log somewhere
        return;
      }

      var path = _filePathService.GetPath(notification.FileLocation, $"booking_{notification.Booking.Id}.json");
      if (string.IsNullOrWhiteSpace(path))
      {
        //TODO log somewhere
        path = $"booking_{notification.Booking.Id}.json";
      }

      await File.WriteAllTextAsync(path, json);
    }  
  }
}
