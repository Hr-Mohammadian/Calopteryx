***Modular Monolith | CQRS | Repository | Event-Driven | Audit | Specification | Policy Authorization***
![Caloptery-log-text](https://user-images.githubusercontent.com/27955954/225509012-410f6523-9ac6-403a-87ce-9ee90d6a6941.png)

**How to start the solution?**
----------------

Start the infrastructure using [Docker](https://docs.docker.com/get-docker/):

```
docker-compose up -d
```

Start API located under Bootstrapper project:

```
cd src/Bootstrapper/Calopteryx.Bootstrapper
dotnet run
```
Build Migration Example
````
dotnet ef migrations add initial --startup-project ..\..\..\..\Bootstrapper\Calopteryx.Bootstrapper\ --project ../Calopteryx.Modules.Identity.Core.csproj --context IdentitiesDbContext -o ./DAL/Migrations
````
