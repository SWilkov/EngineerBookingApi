using EngineerBookingApi.Framework.Models;
using FluentValidation;

namespace EngineerBookingApi.Validators
{
  public class BookingParametersValidator : AbstractValidator<BookingParameters>
  {
    public BookingParametersValidator()
    {
      RuleFor(bp => bp.PageNumber).GreaterThanOrEqualTo(1);
      RuleFor(bp => bp.BookingsPerPage).GreaterThanOrEqualTo(1);
    }
  }
}
