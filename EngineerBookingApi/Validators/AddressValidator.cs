using EngineerBooking.Framework.Models;
using FluentValidation;

namespace EngineerBookingApi.Validators
{
  public class AddressValidator : AbstractValidator<Address>
  {
    public AddressValidator()
    {
      RuleFor(address => address.Street).NotEmpty();      
      RuleFor(address => address.City).NotEmpty();
      RuleFor(address => address.Postcode).NotEmpty().MaximumLength(7);
    }
  }
}
