# desarrollo-servidor-aa1

```bash
docker-compose up
```
Importante: la base de datos tiene que estar encendida con la ruta de http de localhost

dotnet ef migrations add CreacionInicial -p ./TeatroAPI.Data/TeatroAPI.Data.csproj -s ./TeatroAPI/TeatroAPI.csproj
dotnet ef migrations add MigracionInicial -p ./TeatroAPI.Data/TeatroAPI.Data.csproj -s ./TeatroAPI/TeatroAPI.csproj

dotnet ef database update  -p ./TeatroAPI.Data/TeatroAPI.Data.csproj -s ./TeatroAPI/TeatroAPI.csproj