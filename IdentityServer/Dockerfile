FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./

RUN npm install -g bower
RUN bower install

RUN dotnet publish -c Release -o out

RUN dotnet ef database update

FROM microsoft/aspnetcore:2.0
WORKDIR /app

COPY --from=build /app/out .
COPY --from=build /app/app.db .

ENTRYPOINT [ "dotnet", "IdentityServer.dll" ]
