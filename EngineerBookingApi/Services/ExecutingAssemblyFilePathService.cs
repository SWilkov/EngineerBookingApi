using EngineerBooking.Framework.Enums;
using EngineerBooking.Framework.Interfaces;
using System.Reflection;

namespace EngineerBookingApi.Services
{
  public class ExecutingAssemblyFilePathService : IFilePathService
  {
    public string GetPath(FileLocation fileLocation, string fileName = "")
    {
      if (fileLocation != FileLocation.ExecutingAssembly)
        throw new ArgumentException("File Location should be Executing Assembly");

      return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
    }
  }
}
