using EngineerBooking.DataLayer.Interfaces;
using EngineerBooking.Framework.Models;
using FluentValidation;
using MediatR;
using System.Text;

namespace EngineerBookingApi.Commands.Bookings
{
  public class SaveBookingHandler : IRequestHandler<SaveBookingRequest, SaveBookingResponse>
  {
    private readonly IValidator<Booking> _validator;
    private readonly ISaveRepository<Booking> _saveRepository;
    public SaveBookingHandler(IValidator<Booking> validator,
      ISaveRepository<Booking> saveRepository)
    {
      _validator = validator;
      _saveRepository = saveRepository;
    }
    
    /// <summary>
    /// Save a new Booking to the DB. Validates beforehand
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Response obj with the updated booking</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<SaveBookingResponse> Handle(SaveBookingRequest request, CancellationToken cancellationToken)
    {
      if (request is null) throw new ArgumentNullException(nameof(request));
      if (request.Booking is null) throw new ArgumentNullException(nameof(request.Booking));

      var validationResult = _validator.Validate(request.Booking);
      if (!validationResult.IsValid)
      {
        var errorBuilder = new StringBuilder();
        validationResult.Errors.ForEach(x => errorBuilder.Append($" {x.ErrorMessage}."));
        
        var error = new SaveBookingResponse(null);
        error.IsSuccess = false;
        error.Message = errorBuilder is null ? "unknown error!" : errorBuilder.ToString();
        return error;
      }

      var saved = await _saveRepository.Save(request.Booking);
      if (saved is null)
      {
        var errorSaving = new SaveBookingResponse(request.Booking, false);
        errorSaving.Message = $"Error saving booking: {request.Booking.StartDate} for {request.Booking.Customer?.FirstName} {request.Booking.Customer?.LastName}";
        return errorSaving;
      }

      return new SaveBookingResponse(saved);
    }
  }
}
