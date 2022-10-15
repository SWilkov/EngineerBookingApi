# EngineerBookingApi

### Setup

1. The Api uses SQL server 2019 and the connection string should be added in `app.settings.json` as `DefaultConnection` see `Program.cs` for setup. 
2. The Api uses Entity Framework Core for database access once you have added a new database called `EngineeringDB` run `dotnet ef database update` from the following project [EFCore](https://github.com/SWilkov/EngineerBookingApi/tree/master/EngineerBooking.DataLayer.SQLServer.EFCore) and the tables will be added automatically.
3. There is a file with setup queries for SQL [here](https://github.com/SWilkov/EngineerBookingApi/blob/master/EngineerBooking.DataLayer.SQLServer.EFCore/engineeringDBSeedData.sql)

