# dotnet-microservice-template

- [Serilog](https://serilog.net/) logging
- [EFCore](https://github.com/dotnet/efcore) with [PostgreSql](https://github.com/npgsql/efcore.pg)
- `BaseEntity` and `IAuditable`
- [Mapster](https://github.com/MapsterMapper/Mapster) object mapping
- [Flurl](https://flurl.dev/docs/fluent-http/) HTTP client
- [xUnit](https://xunit.net/) testing project
- Auto-apply migrations when run with  `--migrate` flag
- Automatic generation of an [optimized](https://www.thorsten-hans.com/how-to-build-smaller-and-secure-docker-images-for-net5/) docker image (20.26MB)
- Automatic building and testing on `main` branch commits and PR commits
- Simple Book example

## Requirements

### .NET 7.0.0-preview.7

https://dotnet.microsoft.com/en-us/download/dotnet/7.0