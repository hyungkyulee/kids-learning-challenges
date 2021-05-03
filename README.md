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

## Dependency between projects

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




