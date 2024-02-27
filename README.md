# desarrollo-servidor-aa1

```bash
docker-compose up
```
dotnet ef migrations add InitialCreate -p ./TeatroAPI.Data/TeatroAPI.Data.csproj -s ./TeatroAPI/TeatroAPI.csproj
dotnet ef migrations add NombreDeLaMigracion -p ./TeatroAPI.Data/TeatroAPI.Data.csproj -s ./TeatroAPI/TeatroAPI.csproj

dotnet ef database update  -p ./TeatroAPI.Data/TeatroAPI.Data.csproj -s ./TeatroAPI/TeatroAPI.csproj