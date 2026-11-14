FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
WORKDIR /src
COPY ["LibraryManagementSystem.csproj", "./"]
RUN dotnet restore "LibraryManagementSystem.csproj"
COPY . .
RUN dotnet publish "LibraryManagementSystem.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview AS final
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "LibraryManagementSystem.dll"]
