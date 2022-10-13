using EngineerBooking.Framework.Models;
using FluentValidation;

namespace EngineerBookingApi.Validators
{
  public class CustomerValidator : AbstractValidator<Customer>
  {
    public CustomerValidator()
    {
      RuleFor(customer => customer.FirstName).NotEmpty();
      RuleFor(customer => customer.LastName).NotEmpty();
      RuleFor(customer => customer.Email).NotEmpty().EmailAddress();
      RuleFor(customer => customer.ContactNumber).NotEmpty();
      RuleFor(customer => customer.Address).SetValidator(new AddressValidator());

    }
  }
}
