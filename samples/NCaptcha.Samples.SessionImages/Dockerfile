FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base

# install System.Drawing native dependencies
RUN apt-get update \
    && apt-get install -y --allow-unauthenticated \
    libc6-dev \
    libgdiplus \
    libx11-dev \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["samples/NCaptcha.Samples.SessionImages/NCaptcha.Samples.SessionImages.csproj", "samples/NCaptcha.Samples.SessionImages/"]
COPY ["src/NCaptcha.AspNetCore.SessionImages/NCaptcha.AspNetCore.SessionImages.csproj", "src/NCaptcha.AspNetCore.SessionImages/"]
COPY ["src/NCaptcha.Targets.Images/NCaptcha.Targets.Images.csproj", "src/NCaptcha.Targets.Images/"]
COPY ["src/NCaptcha/NCaptcha.csproj", "src/NCaptcha/"]
COPY ["src/NCaptcha.State.Session/NCaptcha.State.Session.csproj", "src/NCaptcha.State.Session/"]
RUN dotnet restore "samples/NCaptcha.Samples.SessionImages/NCaptcha.Samples.SessionImages.csproj"
COPY . .
WORKDIR "/src/samples/NCaptcha.Samples.SessionImages"
RUN dotnet build "NCaptcha.Samples.SessionImages.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "NCaptcha.Samples.SessionImages.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NCaptcha.Samples.SessionImages.dll"]
