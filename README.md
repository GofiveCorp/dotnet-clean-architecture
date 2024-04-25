
# Clean architecture with dotnet 8
### Getting started
The following is required to build and run the project
 - [.NET8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

To launch the API
```bash
cd ./API
dotnet run
```

### Database (SQLite)
The dotnet-ef tool must be install to use the database command
```bash
dotnet tool install --global dotnet-ef
```

Add migration file from database config to infra 
```bash
dotnet ef migrations add "Initial" --project ./Infra --startup-project ./API --output-dir ./Database/Migrations
```

Run a database migration
```bash
dotnet ef migrations add "Initial" --project ./Infra --startup-project ./API --output-dir ./Database/Migrations
```






