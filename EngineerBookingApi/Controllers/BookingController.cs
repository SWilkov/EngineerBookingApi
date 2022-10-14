using EngineerBooking.Framework.Models;
using EngineerBookingApi.Commands.Bookings;
using EngineerBookingApi.Notifications;
using EngineerBookingApi.Queries.Bookings;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EngineerBookingApi.Controllers
{
  [Route("api/booking")]
  [ApiController]
  public class BookingController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly IValidator<Booking> _validator;
    public BookingController(IMediator mediator,
      IValidator<Booking> validator)
    {
      _mediator = mediator;
      _validator = validator;
    }
    
    [HttpGet(Name = "Get All Bookings")]
    public async Task<IActionResult> GetAllBookings()
    {
      var request = new AllBookingsRequest();
      var response = await _mediator.Send(request);

      if (response is null || response.Bookings is null || !response.Bookings.Any())
      {
        return NoContent();
      }

      return Ok(response.Bookings);
    }

    [HttpPost(Name = "Save Booking")]
    public async Task<IActionResult> SaveBooking([FromBody] Booking booking)
    {
      if (booking is null) return BadRequest("No Booking data detected!");

      var validationResult = _validator.Validate(booking);
      if (!validationResult.IsValid)
      {
        return BadRequest(validationResult.Errors);
      }

      //Check if Booking already exists for this date & time
      var checkRequest = new CheckBookingExistsRequest(booking);
      var checkResponse = await _mediator.Send(checkRequest);
      if (checkResponse.Booking is not null && checkResponse.Booking.Id > default(int))
      {
        return BadRequest($"Booking already exists @{checkResponse.Booking.StartDate} for {checkResponse.Booking.Customer?.FirstName} {checkResponse.Booking.Customer?.LastName}");
      }

      var request = new SaveBookingRequest(booking);
      var response = await _mediator.Send(request);

      if (response is null || response.Booking is null)
      {
        return NoContent();
      }
      
      if (!response.IsSuccess)
      {        
        return BadRequest($"Error saving new Booking: {response.Message}");
      }

      //Success so run any success handlers
      var successNotification = new SaveBookingSuccessNotification(response.Booking);
      await _mediator.Publish(successNotification);

      return Ok(response.Booking);
    }
  }
}
