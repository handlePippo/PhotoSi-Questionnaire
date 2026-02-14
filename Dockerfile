# build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .
RUN dotnet publish ./src/PhotoSi.Questionnaire/PhotoSi.Questionnaire.csproj -c Release -o /app/publish

# runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Development

ENTRYPOINT ["dotnet", "PhotoSi.Questionnaire.dll"]
