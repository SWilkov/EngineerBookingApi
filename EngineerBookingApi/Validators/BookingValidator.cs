using EngineerBooking.Framework.Models;
using FluentValidation;

namespace EngineerBookingApi.Validators
{
  public class BookingValidator : AbstractValidator<Booking>
  {
    public BookingValidator()
    {
      RuleFor(booking => booking.Customer).SetValidator(new CustomerValidator());
      RuleFor(booking => booking.TimeSlot).SetValidator(new TimeSlotValidator());
      RuleFor(booking => booking.Date).NotEmpty();
      RuleFor(booking => booking.VehicleRegistration).NotEmpty().MaximumLength(7);
      RuleFor(booking => booking.JobCategory).NotEmpty();
      RuleFor(booking => booking.Comments).MaximumLength(500);
    }
  }
}
