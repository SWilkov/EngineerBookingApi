namespace EngineerBooking.DataLayer.Interfaces
{
  public interface ISaveRepository<T>
    where T: class
  {
    Task<T> Save(T entity);
  }
}
