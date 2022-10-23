using EngineerBooking.Framework.Enums;
using EngineerBooking.Framework.Interfaces;

namespace EngineerBookingApi.Services
{
  public class FilePathService : IFilePathService
  {
    private readonly Dictionary<FileLocation, IFilePathService> _services;
    public FilePathService(Dictionary<FileLocation, IFilePathService> services)
    {
      _services = services;
    }
    
    public string GetPath(FileLocation fileLocation, string fileName = "") =>
      _services[fileLocation].GetPath(fileLocation, fileName);
  }
}
