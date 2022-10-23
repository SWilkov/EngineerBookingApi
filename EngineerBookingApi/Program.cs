using EngineerBooking.Framework.Models;
using EngineerBookingApi.Validators;
using FluentValidation;
using EngineerBooking.DataLayer.SQLServer.EFCore.Extensions;
using MediatR;
using EngineerBookingApi.Framework.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
  options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                   .AllowAnyMethod()
                                   .AllowAnyHeader());
});

#region DataLayer
builder.Services.AddSQLServer(builder.Configuration.GetConnectionString("DefaultConnection"));
#endregion

#region Validators
builder.Services.AddScoped<IValidator<Address>, AddressValidator>();
builder.Services.AddScoped<IValidator<Customer>, CustomerValidator>();
builder.Services.AddScoped<IValidator<TimeSlot>, TimeSlotValidator>();
builder.Services.AddScoped<IValidator<Booking>, BookingValidator>();
builder.Services.AddScoped<IValidator<BookingParameters>, BookingParametersValidator>();
#endregion

#region Mediator
builder.Services.AddMediatR(typeof(Program));
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
