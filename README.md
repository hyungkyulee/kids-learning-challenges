# kids-learning-challenges

## creating the .net projects and references

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
![image](https://user-images.githubusercontent.com/59367560/116905229-9e5c6980-ac36-11eb-8a12-fa2928da11a1.png)
