namespace EngineerBooking.DataLayer.SQLServer.EFCore.Interfaces
{
  public interface IMapper<TFramework, TDataModel>
    where TFramework : class
    where TDataModel : class
  {
    TDataModel Map(TFramework source);
    TFramework Map(TDataModel source);
  }
}
