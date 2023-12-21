FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS foundation
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
COPY . ./
RUN dotnet restore "./UserNotifications/UserNotifications.Api.csproj"
COPY . .
WORKDIR "./UserNotifications/"
RUN dotnet build "UserNotifications.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserNotifications.Api.csproj" -c Release -o /app/publish

FROM foundation AS final
WORKDIR /app
COPY --from=publish /app/publish ./
RUN ls ./
ENTRYPOINT ["dotnet", "UserNotifications.Api.dll"]
