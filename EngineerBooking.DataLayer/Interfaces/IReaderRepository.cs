namespace EngineerBooking.DataLayer.Interfaces
{
  public interface IReaderRepository<T> 
    where T: class
  {
    Task<IEnumerable<T>> All();
    Task<T> GetById(int id);
  }
}
