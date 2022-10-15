/****** Script for SelectTopNRows command from SSMS  ******/

INSERT INTO dbo.TimeSlots([StartTime], [EndTime], [DayOfWeek], [CreatedAt]) VALUES ('08:00:00','10:00:00', 1, GETDATE());
INSERT INTO dbo.TimeSlots([StartTime], [EndTime], [DayOfWeek], [CreatedAt]) VALUES ('11:00:00','13:00:00', 1, GETDATE());
INSERT INTO dbo.TimeSlots([StartTime], [EndTime], [DayOfWeek], [CreatedAt]) VALUES ('14:00:00','16:00:00', 1, GETDATE());

INSERT INTO dbo.TimeSlots([StartTime], [EndTime], [DayOfWeek], [CreatedAt]) VALUES ('09:00:00','11:00:00', 2, GETDATE());
INSERT INTO dbo.TimeSlots([StartTime], [EndTime], [DayOfWeek], [CreatedAt]) VALUES ('12:00:00','14:00:00', 2, GETDATE());
INSERT INTO dbo.TimeSlots([StartTime], [EndTime], [DayOfWeek], [CreatedAt]) VALUES ('15:00:00','17:00:00', 2, GETDATE());

INSERT INTO dbo.TimeSlots([StartTime], [EndTime], [DayOfWeek], [CreatedAt]) VALUES ('08:00:00','10:00:00', 3, GETDATE());
INSERT INTO dbo.TimeSlots([StartTime], [EndTime], [DayOfWeek], [CreatedAt]) VALUES ('11:00:00','13:00:00', 3, GETDATE());
INSERT INTO dbo.TimeSlots([StartTime], [EndTime], [DayOfWeek], [CreatedAt]) VALUES ('14:00:00','16:00:00', 3, GETDATE());

INSERT INTO dbo.TimeSlots([StartTime], [EndTime], [DayOfWeek], [CreatedAt]) VALUES ('09:00:00','11:00:00', 4, GETDATE());
INSERT INTO dbo.TimeSlots([StartTime], [EndTime], [DayOfWeek], [CreatedAt]) VALUES ('12:00:00','14:00:00', 4, GETDATE());
INSERT INTO dbo.TimeSlots([StartTime], [EndTime], [DayOfWeek], [CreatedAt]) VALUES ('15:00:00','17:00:00', 4, GETDATE());

INSERT INTO dbo.TimeSlots([StartTime], [EndTime], [DayOfWeek], [CreatedAt]) VALUES ('08:00:00','10:00:00', 5, GETDATE());
INSERT INTO dbo.TimeSlots([StartTime], [EndTime], [DayOfWeek], [CreatedAt]) VALUES ('11:00:00','13:00:00', 5, GETDATE());

INSERT INTO dbo.Customers([FirstName], [LastName], [Email], [ContactNumber], [Street], [City], [Postcode], [CreatedAt])
VALUES ('Joe', 'Blogger', 'jbloggs@gmail.com', '07777 767574', '12 Maypole Avenue', 'Birmingham', 'B12 4DD', GETDATE());

INSERT INTO dbo.Customers([FirstName], [LastName], [Email], [ContactNumber], [Street], [City], [Postcode], [CreatedAt])
VALUES ('Sarah', 'Jones', 'joness@gmail.com', '07777 767574', '2 Old Street', 'London', 'N1 7NY', GETDATE());

INSERT INTO dbo.Bookings([StartDate], [EndDate], [VehicleRegistration], [JobCategory], [CustomerId], [Comments], [CreatedAt])
VALUES ('2022-10-17 11:00:00', '2022-10-17 13:00:00', 'BB16YUH', 'warranty', 1, '', GETDATE());

INSERT INTO dbo.Bookings([StartDate], [EndDate], [VehicleRegistration], [JobCategory], [CustomerId], [Comments], [CreatedAt])
VALUES ('2022-10-18 09:00:00', '2022-10-18 11:00:00', 'BB16YUH', 'warranty', 1, '', GETDATE());

INSERT INTO dbo.Bookings([StartDate], [EndDate], [VehicleRegistration], [JobCategory], [CustomerId], [Comments], [CreatedAt])
VALUES ('2022-10-20 09:00:00', '2022-10-20 11:00:00', 'EE14DRT', 'warranty', 2, '', GETDATE());







