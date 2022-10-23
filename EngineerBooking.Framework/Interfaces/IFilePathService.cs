using EngineerBooking.Framework.Enums;

namespace EngineerBooking.Framework.Interfaces
{
  public interface IFilePathService
  {
    string GetPath(FileLocation fileLocation, string fileName = "");    
  }
}
