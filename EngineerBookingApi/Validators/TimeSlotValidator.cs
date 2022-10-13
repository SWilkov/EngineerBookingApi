using EngineerBooking.Framework.Models;
using FluentValidation;

namespace EngineerBookingApi.Validators
{
  public class TimeSlotValidator : AbstractValidator<TimeSlot>
  {
    public TimeSlotValidator()
    {
      RuleFor(timeSlot => timeSlot.StartTime).NotEmpty();
      RuleFor(timeSlot => timeSlot.EndTime).NotEmpty();
      RuleFor(timeSlot => timeSlot.StartTime).LessThan(timeSlot => timeSlot.EndTime);
      RuleFor(timeSlot => timeSlot.DayOfWeek).Must(day => (int)day >= 1 && (int)day <= 7); 
    }
  }
}
