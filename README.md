# kids-learning-challenges

## creating the .net projects/references, and Reviewing them on postman

#### Create Solution and WebApi project
```bash
➜  mkdir KlcApis
➜  cd KlcApis
➜  KlcApis git:(main) dotnet new sln
Getting ready...
The template "Solution File" was created successfully.

➜  mkdir src
➜  cd src
➜  src git:(main) ✗ dotnet new webapi -n API
The template "ASP.NET Core Web API" was created successfully.

Processing post-creation actions...
Running 'dotnet restore' on API/API.csproj...
  Determining projects to restore...
  Restored /Users/albert/_proj/jinyus/kids-learning-challenges/KlcApis/src/API/API.csproj (in 115 ms).
Restore succeeded.
```

#### Create Class libraries
```bash
➜  src git:(main) ✗ dotnet new classlib -n Application
The template "Class library" was created successfully.

Processing post-creation actions...
Running 'dotnet restore' on Application/Application.csproj...
  Determining projects to restore...
  Restored /Users/albert/_proj/jinyus/kids-learning-challenges/KlcApis/src/Application/Application.csproj (in 59 ms).
Restore succeeded.

➜  src git:(main) ✗ dotnet new classlib -n Domain     
The template "Class library" was created successfully.

Processing post-creation actions...
Running 'dotnet restore' on Domain/Domain.csproj...
  Determining projects to restore...
  Restored /Users/albert/_proj/jinyus/kids-learning-challenges/KlcApis/src/Domain/Domain.csproj (in 66 ms).
Restore succeeded.

➜  src git:(main) ✗ dotnet new classlib -n Persistence
The template "Class library" was created successfully.

Processing post-creation actions...
Running 'dotnet restore' on Persistence/Persistence.csproj...
  Determining projects to restore...
  Restored /Users/albert/_proj/jinyus/kids-learning-challenges/KlcApis/src/Persistence/Persistence.csproj (in 65 ms).
Restore succeeded.
```

#### Link the Class libraries to Solution
```bash
➜  src git:(main) ✗ cd ..
➜  KlcApis git:(main) ✗ dotnet sln add src/API/API.csproj 
Project `src/API/API.csproj` added to the solution.
➜  KlcApis git:(main) ✗ dotnet sln add src/Application/Application.csproj 
Project `src/Application/Application.csproj` added to the solution.
➜  KlcApis git:(main) ✗ dotnet sln add src/Persistence/Persistence.csproj 
Project `src/Persistence/Persistence.csproj` added to the solution.
➜  KlcApis git:(main) ✗ dotnet sln add src/Domain/Domain.csproj          
Project `src/Domain/Domain.csproj` added to the solution.
➜  KlcApis git:(main) ✗ dotnet sln list
Project(s)
----------
src/API/API.csproj
src/Application/Application.csproj
src/Persistence/Persistence.csproj
src/Domain/Domain.csproj
```

#### Dependency between projects

API <- Application <- Persistence <- Domain
                   <- Domain

```bash
➜  API git:(main) ✗ dotnet add reference ../Application 
Reference `..\Application\Application.csproj` added to the project.
➜  API git:(main) ✗ cd ../Application 
➜  Application git:(main) ✗ dotnet add reference ../Persistence 
Reference `..\Persistence\Persistence.csproj` added to the project.
➜  Application git:(main) ✗ dotnet add reference ../Domain
Reference `..\Domain\Domain.csproj` added to the project.
➜  Application git:(main) ✗ cd ../Persistence 
➜  Persistence git:(main) ✗ dotnet add reference ../Domain 
Reference `..\Domain\Domain.csproj` added to the project.
```

#### File structure and properties updated on Rider
![image](https://user-images.githubusercontent.com/59367560/116902889-9d760880-ac33-11eb-834e-77a3e5ceed65.png)

src/API/Properties/launchSettings.json (to remove https on development mode)
```json
:
  "profiles": {
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "launchUrl": "swagger",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "API": {
      "commandName": "Project",
      "dotnetRunMessages": "true",
      "launchBrowser": false,
      "launchUrl": "swagger",
      "applicationUrl": "http://localhost:5000",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
:
```

src/API/Startup.cs (comment on https redirection method)
```c#
:
// app.UseHttpsRedirection();
:
```

src/API/appsettings.Developement.json (to show more information)
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Information",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}
```

#### Test run

```bash
➜  API git:(main) ✗ dotnet run
Building...
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /Users/albert/_proj/jinyus/kids-learning-challenges/KlcApis/src/API
^Cinfo: Microsoft.Hosting.Lifetime[0]
      Application is shutting down...
➜  API git:(main) ✗ dotnet watch run
watch : Started
Building...
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /Users/albert/_proj/jinyus/kids-learning-challenges/KlcApis/src/API
```

#### Swagger - Microsoft API documentation tool
even though the localhost:5000 is not responding with 404 error, swagger will diplay a test interface for a documentaiton purpose.
[Browser]
![image](https://user-images.githubusercontent.com/59367560/116905229-9e5c6980-ac36-11eb-8a12-fa2928da11a1.png)
[Postman]
![image](https://user-images.githubusercontent.com/59367560/116906944-d5cc1580-ac38-11eb-9696-01efd949be0b.png)


## Adding an entity Framework Db Context

#### Install NuGet Packages
Microsoft.EntityFrameworkCore.Sqlite onto Persistence project

#### Create DataContext Class (Persistence > DataContext.cs)
```c#
namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<WordGame> WordGames { get; set; }
    }
}
```

#### Remove microsoft default configuration, and use ConnectionString from appsettings
```c#
/*
public Startup(IConfiguration configuration)
{
    Configuration = configuration;
}

public IConfiguration Configuration { get; }
*/

:

private readonly IConfiguration _config;

public Startup(IConfiguration config)
{
    _config = config;
}

// This method gets called by the runtime. Use this method to add services to the container.
public void ConfigureServices(IServiceCollection services)
{

    services.AddControllers();
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
    });
    services.AddDbContext<DataContext>(opt =>
    {
        opt.UseSqlite(_config.GetConnectionString("DefaultConnection"));
    });
}
```

appsettings.Development.json
```json
  "ConnectionStrings": {
    "DefaultConnection": "Data source=wordgames.db"
  }
```

#### create a migration

```bash
➜  KlcApis git:(main) ✗ dotnet tool update --global dotnet-ef
Tool 'dotnet-ef' was successfully updated from version '3.1.2' to version '5.0.5'.

➜  KlcApis git:(main) ✗ dotnet ef -h
Entity Framework Core .NET Command-line Tools 5.0.5

Usage: dotnet ef [options] [command]

Options:
  --version        Show version information
  -h|--help        Show help information
  -v|--verbose     Show verbose output.
  --no-color       Don't colorize output.
  --prefix-output  Prefix output with level.

Commands:
  database    Commands to manage the database.
  dbcontext   Commands to manage DbContext types.
  migrations  Commands to manage migrations.

Use "dotnet ef [command] --help" for more information about a command.
➜  KlcApis git:(main) ✗ dotnet ef migrations add InitialCreate -p src/Persistence -s src/API 
Build started...
Build succeeded.
Your startup project 'API' doesn't reference Microsoft.EntityFrameworkCore.Design. This package is required for the Entity Framework Core Tools to work. Ensure your startup project is correct, install the package, and try again.
:
➜  KlcApis git:(main) ✗ dotnet ef migrations add InitialCreate -p src/Persistence -s src/API
Build started...
Build succeeded.
info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
      Entity Framework Core 5.0.5 initialized 'DataContext' using provider 'Microsoft.EntityFrameworkCore.Sqlite' with options: None
Done. To undo this action, use 'ef migrations remove'
```
> if dotnet-ef has never installed, please use 'install' than 'update'
> if migration is failed, install NuGet package of 'Microsoft.EntityFrameworkCore.Design' to API project and try again.
> after being successful, you can check the migration builder on Persistence > Migrations > xxx_initialCreate.cs to handle an actual Database
> 

#### Create Database

```bash
➜  KlcApis git:(main) ✗ dotnet ef database -h


Usage: dotnet ef database [options] [command]

Options:
  -h|--help        Show help information
  -v|--verbose     Show verbose output.
  --no-color       Don't colorize output.
  --prefix-output  Prefix output with level.

Commands:
  drop    Drops the database.
  update  Updates the database to a specified migration.

Use "database [command] --help" for more information about a command.
```

API > Program.cs
```c#
:
public static void Main(string[] args)
{
    var host = CreateHostBuilder(args).Build();
    using var scope = host.Services.CreateScope();
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<DataContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occured during migraiton");
    }

    host.Run();
}
:
```

```bash
➜  API git:(main) ✗ dotnet watch run
watch : Started
Building...
info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
      Entity Framework Core 5.0.5 initialized 'DataContext' using provider 'Microsoft.EntityFrameworkCore.Sqlite' with options: None
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (8ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      PRAGMA journal_mode = 'wal';
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE "__EFMigrationsHistory" (
          "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
          "ProductVersion" TEXT NOT NULL
      );
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT COUNT(*) FROM "sqlite_master" WHERE "name" = '__EFMigrationsHistory' AND "type" = 'table';
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT "MigrationId", "ProductVersion"
      FROM "__EFMigrationsHistory"
      ORDER BY "MigrationId";
info: Microsoft.EntityFrameworkCore.Migrations[20402]
      Applying migration '20210504185813_InitialCreate'.
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE "WordGames" (
          "Id" TEXT NOT NULL CONSTRAINT "PK_WordGames" PRIMARY KEY,
          "Question" TEXT NULL,
          "Date" TEXT NOT NULL,
          "Description" TEXT NULL,
          "Category" TEXT NULL,
          "Answer" TEXT NULL,
          "WrongAnswer1" TEXT NULL,
          "WrongAnswer2" TEXT NULL,
          "WrongAnswer3" TEXT NULL,
          "WrongAnswer4" TEXT NULL,
          "WrongAnswer5" TEXT NULL
      );
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
      VALUES ('20210504185813_InitialCreate', '5.0.5');
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /Users/albert/_proj/jinyus/kids-learning-challenges/KlcApis/src/API

```
> check database created via Database window (database file will be shown after more than one item is inserted to the table)

Test Seed items onto the table, and inject it via program start
example of Seed items
Persistence > Seed.cs
```c#
namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.WordGames.Any()) return;

            var testWordGames = new List<WordGame>
            {
                new WordGame
                {
                    Question = "Wrath",
                    Date = DateTime.Now,
                    Description = "do it",
                    Category = "Synonyms",
                    Answer = "anger",
                    WrongAnswer1 = "crime",
                    WrongAnswer2 = "knot",
                    WrongAnswer3 = "smoke",
                    WrongAnswer4 = "happiness",
                    WrongAnswer5 = "sadness",
                },
                new WordGame
                {
                  :
                }
                  :
                  :
                
            };

            await context.WordGames.AddRangeAsync(testWordGames);
            await context.SaveChangesAsync();
        }
    }
}
```

Inject by program start
API > Program.cs
```c#
:
public static async Task Main(string[] args)
{
    var host = CreateHostBuilder(args).Build();
    using var scope = host.Services.CreateScope();
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<DataContext>();
        await context.Database.MigrateAsync();
        await Seed.SeedData(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occured during migraiton");
    }

    await host.RunAsync();
}
:
```
![image](https://user-images.githubusercontent.com/59367560/117577843-6a27f380-b0e3-11eb-810e-02d281c342eb.png)

API endpoint route
API > Controllers > BaseApiController.cs
```c#
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        
    }
}
```

API > Controllers > WordGamesControllers.cs
```c#
namespace API.Controllers
{
    public class WordGamesController : BaseApiController
    {
        private readonly DataContext _context;

        public WordGamesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<WordGame>>> GetWordGames()
        {
            return await _context.WordGames.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WordGame>> GetWordGame(Guid id)
        {
            return await _context.WordGames.FindAsync(id);
        }
    }
}
```
> annotation 'ApiController' is connecting the api controller with endpoint
> annotation 'Route' will be describing the path right after hostname: e.g. http://localhost:5000/api/wordgames
>  * wordgames is parsed from 'WordGamesController' Class Name

Result from postman
![image](https://user-images.githubusercontent.com/59367560/117578038-59c44880-b0e4-11eb-8ce0-6ca98c2c46e4.png)



