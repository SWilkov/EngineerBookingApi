using MediatR;
using Newtonsoft.Json;

namespace EngineerBookingApi.Notifications
{

  /// <summary>
  /// Convert Booking to json and save to File
  /// </summary>
  public class SaveBookingToJsonHandler : INotificationHandler<SaveBookingSuccessNotification>
  {
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
    
      await File.WriteAllTextAsync($"booking_{notification.Booking.Id}.json", json);
    }  
  }
}
