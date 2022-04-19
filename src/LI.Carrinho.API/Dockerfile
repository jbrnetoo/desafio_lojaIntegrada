#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/LI.Carrinho.API/LI.Carrinho.API.csproj", "src/LI.Carrinho.API/"]
RUN dotnet restore "src/LI.Carrinho.API/LI.Carrinho.API.csproj"
COPY . .
WORKDIR "/src/src/LI.Carrinho.API"
RUN dotnet build "LI.Carrinho.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LI.Carrinho.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LI.Carrinho.API.dll"]