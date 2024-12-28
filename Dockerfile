# Use the official .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy only the project file(s) first to optimize layer caching
COPY *.csproj ./

# Restore dependencies
RUN dotnet restore

# Copy the rest of the application code
COPY . . 

# Build the application
RUN dotnet build --configuration Release --output /app/build

# Publish the application
RUN dotnet publish --configuration Release --output /app/publish

# Use a smaller runtime image for final deployment
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .

# Expose the port your app will run on
EXPOSE 5000

# Start the application
ENTRYPOINT ["dotnet", "TylorShop.dll"]
