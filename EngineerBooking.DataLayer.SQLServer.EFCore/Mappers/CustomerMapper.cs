using EngineerBooking.DataLayer.SQLServer.EFCore.DataModels;
using EngineerBooking.DataLayer.SQLServer.EFCore.Interfaces;
using EngineerBooking.Framework.Models;

namespace EngineerBooking.DataLayer.SQLServer.EFCore.Mappers
{
  public class CustomerMapper : IMapper<Customer, CustomerDataModel>
  {
    public CustomerDataModel Map(Customer source)
    {
      if (source is null) throw new ArgumentNullException(nameof(source));

      return new CustomerDataModel
      {
        Id = source.Id,
        FirstName = String.IsNullOrWhiteSpace(source.FirstName) ? String.Empty : source.FirstName,
        LastName = String.IsNullOrWhiteSpace(source.LastName) ? String.Empty : source.LastName,
        Email = String.IsNullOrWhiteSpace(source.Email) ? String.Empty : source.Email,
        ContactNumber = String.IsNullOrWhiteSpace(source.ContactNumber) ? String.Empty : source.ContactNumber,
        Street = source.Address?.Street ?? String.Empty,
        City = source.Address?.City ?? String.Empty,
        Postcode = source.Address?.Postcode ?? String.Empty
      };
    }

    public Customer Map(CustomerDataModel source)
    {
      if (source is null) throw new ArgumentNullException(nameof(source));

      return new Customer
      {
        Id = source.Id,
        FirstName = String.IsNullOrWhiteSpace(source.FirstName) ? String.Empty : source.FirstName,
        LastName = String.IsNullOrWhiteSpace(source.LastName) ? String.Empty : source.LastName,
        Email = String.IsNullOrWhiteSpace(source.Email) ? String.Empty : source.Email,,
        ContactNumber = String.IsNullOrWhiteSpace(source.ContactNumber) ? String.Empty : source.ContactNumber,
        Address = new Address
        {
          Street = String.IsNullOrWhiteSpace(source.Street) ? String.Empty : source.Street,
          City = String.IsNullOrWhiteSpace(source.City) ? String.Empty : source.City,
          Postcode = String.IsNullOrWhiteSpace(source.Postcode) ? String.Empty : source.Postcode
        }
      };
    }
    }
  }
}
