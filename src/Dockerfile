FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 37499
EXPOSE 44388

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["WayneEnterprises.OnlineBanking.WebApi/WayneEnterprises.OnlineBanking.WebApi.csproj", "WayneEnterprises.OnlineBanking.WebApi/"]
COPY ["WayneEnterprises.Authentication/WayneEnterprises.Authentication.csproj", "WayneEnterprises.Authentication/"]
COPY ["WayneEnterprises.Authorisation/WayneEnterprises.Authorisation.csproj", "WayneEnterprises.Authorisation/"]
RUN dotnet restore "WayneEnterprises.OnlineBanking.WebApi/WayneEnterprises.OnlineBanking.WebApi.csproj"
COPY . .
WORKDIR "/src/WayneEnterprises.OnlineBanking.WebApi"
RUN apt-get update -yq && apt-get upgrade -yq && apt-get install -yq curl git nano
RUN curl -sL https://deb.nodesource.com/setup_8.x | bash - && apt-get install -yq nodejs build-essential
RUN npm install -g npm
RUN npm install
RUN dotnet build "WayneEnterprises.OnlineBanking.WebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WayneEnterprises.OnlineBanking.WebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WayneEnterprises.OnlineBanking.WebApi.dll"]