using EngineerBooking.Framework.Enums;
using EngineerBooking.Framework.Interfaces;

namespace EngineerBookingApi.Services
{
  public class MyDocumentsFilePathService : IFilePathService
  {
    public string GetPath(FileLocation fileLocation, string fileName = "")
    {
      if (fileLocation != FileLocation.MyDocuments)
        throw new ArgumentException("FileLocation must be MyDocuments");

      return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);
    }
  }
}
