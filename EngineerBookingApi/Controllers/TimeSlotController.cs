using EngineerBookingApi.Queries.TimeSlots;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EngineerBookingApi.Controllers
{
  [Route("api/timeslot")]
  [ApiController]
  public class TimeSlotController : ControllerBase
  {
    private readonly IMediator _mediator;
    public TimeSlotController(IMediator mediator)
    {
      _mediator = mediator;      
    }

    [HttpGet(Name = "Get Time Slots")]
    public async Task<IActionResult> GetAllTimeslots()
    {
      var request = new AllTimeSlotsRequest();
      var response = await _mediator.Send(request);

      if (response is null || response.TimeSlots is null || !response.TimeSlots.Any())
      {
        return NoContent();
      }

      return Ok(response.TimeSlots);
    }
  }
}
