#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Core/Deloitte.DSF.UserManagement.Shared/Deloitte.DSF.UserManagement.Shared.csproj", "Deloitte.DSF.UserManagement.Shared/"]
COPY ["src/Core/Deloitte.DSF.UserManagement.Domain/Deloitte.DSF.UserManagement.Domain.csproj", "Deloitte.DSF.UserManagement.Domain/"]
COPY ["src/Core/Deloitte.DSF.UserManagement.Application/Deloitte.DSF.UserManagement.Application.csproj", "Deloitte.DSF.UserManagement.Application/"]
COPY ["src/Infrastucture/Deloitte.DSF.UserManagement.Infrastucture/Deloitte.DSF.UserManagement.Infrastucture.csproj", "Deloitte.DSF.UserManagement.Infrastucture/"]
RUN dotnet restore "Deloitte.DSF.UserManagement.Service/Deloitte.DSF.UserManagement.Service.csproj"
COPY . .
WORKDIR "src/Deloitte.DSF.UserManagement.Service"
RUN dotnet build "Deloitte.DSF.UserManagement.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Deloitte.DSF.UserManagement.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Deloitte.DSF.UserManagement.Service.dll"]