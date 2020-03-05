FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 7475
EXPOSE 44325

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["API_5322/API_5322.csproj", "API_5322/"]
RUN dotnet restore "API_5322/API_5322.csproj"
COPY . .
WORKDIR "/src/API_5322"
RUN dotnet build "API_5322.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "API_5322.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "API_5322.dll"]