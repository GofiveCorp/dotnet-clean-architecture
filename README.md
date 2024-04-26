
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

Resource
 - [CleanArchitecture template](https://github.com/jasontaylordev/CleanArchitecture)
 - [.NET จับมือทำ by Ponggun](https://medium.com/@ponggun/%E0%B8%9A%E0%B8%97%E0%B8%84%E0%B8%A7%E0%B8%B2%E0%B8%A1%E0%B8%8A%E0%B8%B8%E0%B8%94-net-6-%E0%B9%81%E0%B8%9A%E0%B8%9A%E0%B8%88%E0%B8%B1%E0%B8%9A%E0%B8%A1%E0%B8%B7%E0%B8%AD%E0%B8%97%E0%B8%B3-0-%E0%B9%80%E0%B8%81%E0%B8%A3%E0%B8%B4%E0%B9%88%E0%B8%99%E0%B8%99%E0%B8%B3-a61b277352f9)
 - [Use the SQLite database](https://learn.microsoft.com/en-us/training/modules/build-web-api-minimal-database/5-exercise-use-sqlite-database)






