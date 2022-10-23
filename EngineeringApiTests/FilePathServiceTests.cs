using EngineerBooking.Framework.Enums;
using EngineerBooking.Framework.Interfaces;
using EngineerBookingApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringApiTests
{
  public class FilePathServiceTests
  {
    private IFilePathService _filePathService;
    public FilePathServiceTests()
    {
      _filePathService = new FilePathService(new Dictionary<FileLocation, IFilePathService>
      {
        { FileLocation.MyDocuments, new MyDocumentsFilePathService() },
        { FileLocation.ExecutingAssembly, new ExecutingAssemblyFilePathService() }
      });
    }

    [Fact]
    public void save_to_my_documents_path_not_null()
    {
      var fileName = "bookings.json";
      var path = _filePathService.GetPath(FileLocation.MyDocuments, fileName);

      Assert.NotNull(path);
    }

    [Fact]
    public void save_to_executing_assembly_path_not_null()
    {
      var fileName = "bookings.json";
      var path = _filePathService.GetPath(FileLocation.ExecutingAssembly, fileName);

      Assert.NotNull(path);
    }

    [Fact]
    public void save_to_my_documents_contains_documents_folder()
    {
      var fileName = "bookings.json";
      var path = _filePathService.GetPath(FileLocation.MyDocuments, fileName);

      Assert.NotNull(path);
      Assert.True(path.Contains("Documents"));
    }

    [Fact]
    public void save_to_executing_assembly_contains_bin_debug_folder()
    {
      var fileName = "bookings.json";
      var path = _filePathService.GetPath(FileLocation.ExecutingAssembly, fileName);

      Assert.NotNull(path);
      Assert.True(path.Contains("bin"));
      Assert.True(path.Contains("Debug"));
    }
  }
}
