﻿using System.Text.Json.Serialization;

namespace EngineerBooking.Framework.Models
{
  public class Customer : BaseEntity
  {
    public Customer()
    {
      
    }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string ContactNumber { get; set; } = default!;
    public Address Address { get; set; } = default!;
    [JsonIgnore]
    public ICollection<Booking> Bookings { get; set; }
  }
}
