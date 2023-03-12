# Entity Framework Core Migration Demo
This repository demonstrates how DB schema migrations can be done in Entity Framework Core
Migrations documentation: https://docs.microsoft.com/en-us/ef/core/cli/dotnet

Prerequisites:

Install-Package Microsoft.EntityFrameworkCore -Version 5.0.9

Install-Package Microsoft.EntityFrameworkCore.Tools -Version 5.0.9 

Install-Package Microsoft.EntityFrameworkCore.Design -Version 5.0.9

Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 5.0.9

Install-Package Microsoft.Extensions.Configuration.Json -Version 5.0.0


if not already done:
dotnet tool install --global dotnet-ef  //from package manager console, to install dotnet cli tools
dotnet tool update --global dotnet-ef

How migration works:
Add/delete/modify Entity classes and/or their fluent configuration, then:

While in Package Manager console, keep solution directory as the current directory, then issue:
dotnet ef migrations add 'new_name' --project EfCoreMigrationDemo.Data  //add new migration snapshot with the specified 'new_name'
dotnet ef migrations remove --project EfCoreMigrationDemo.Data //remove last migration snapshot that is not synced to DB.

dotnet ef database update 'name' --project EfCoreMigrationDemo.Data  //Sync DB with the particular migration name
dotnet ef database update 0 --project EfCoreMigrationDemo.Data  //Remove all migrations from DB

dotnet ef migrations script 'fromName' 'toName' --project EfCoreMigrationDemo.Data //create script out of migration. fromName: all changes after fromName. toName: all changes up to toName (including toName) Use 0 in the place of fromName for initial migration.





