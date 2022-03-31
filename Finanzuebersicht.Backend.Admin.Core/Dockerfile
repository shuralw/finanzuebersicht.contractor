FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
ENV http_proxy="http://wsg.asp.krzwan.de:8080/"
ENV https_proxy="http://wsg.asp.krzwan.de:8080/"

COPY . .
RUN dotnet restore "Contract/Core.Contract.csproj"
RUN dotnet restore "API/Core.API.csproj"
RUN dotnet restore "Logic/Core.Logic.csproj"
RUN dotnet restore "Persistence/Core.Persistence.csproj"

RUN dotnet build "Contract/Core.Contract.csproj" -c Release
RUN dotnet build "API/Core.API.csproj" -c Release
RUN dotnet build "Logic/Core.Logic.csproj" -c Release
RUN dotnet build "Persistence/Core.Persistence.csproj" -c Release

FROM build AS publish
RUN dotnet publish "Contract/Core.Contract.csproj" -c Release -o /app
RUN dotnet publish "API/Core.API.csproj" -c Release -o /app
RUN dotnet publish "Logic/Core.Logic.csproj" -c Release -o /app
RUN dotnet publish "Persistence/Core.Persistence.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS final
WORKDIR /app

COPY --from=publish /app .

RUN sed -i 's/MinProtocol = TLSv1.2/MinProtocol = TLSv1/' /etc/ssl/openssl.cnf &&\
    sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf 

ENTRYPOINT ["dotnet", "Finanzuebersicht.Backend.Admin.Core.API.dll"]

ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000

HEALTHCHECK CMD curl --fail http://localhost:5000/health || exit
