FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 59418
EXPOSE 44349

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["InitialWebApi/InitialWebApi.csproj", "InitialWebApi/"]
RUN dotnet restore "InitialWebApi/InitialWebApi.csproj"
COPY . .
WORKDIR "/src/InitialWebApi"
RUN dotnet build "InitialWebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "InitialWebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "InitialWebApi.dll"]