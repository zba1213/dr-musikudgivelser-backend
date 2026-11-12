# Musikudgivelser API

Åbn `MusicRecords.sln` i Visual Studio med understøttelse af .NET 10, eller kør disse kommandoer fra denne mappe.

```powershell
dotnet run --project MusicRecords.Api
dotnet test MusicRecords.sln
```

Kør de to kommandoer i hver sin terminal, hvis API'et skal blive ved med at køre. Åbn [Swagger](http://localhost:5080/swagger) eller [GET /api/records](http://localhost:5080/api/records). Swagger viser HTTP 200 og svarmodellen for JSON-listen.

Importér `postman/MusicRecords.postman_collection.json` i Postman. Sæt collection-variablen `baseUrl` til API'ets adresse uden skråstreg til sidst. Tryk **Send** på **GET alle musikudgivelser** og se **Test Results**. Brug Azure-adressen efter publicering.

## Azure via GitHub Actions

1. Brug en Windows App Service med .NET 10 og HTTPS. I appens miljøvariabler sætter du `FrontendOrigin` til frontendens HTTPS-origin, fx `https://dit-frontend-hostnavn`, uden sti eller afsluttende skråstreg. Lokal standard er `http://localhost:5500`.
2. På GitHub sætter du variablerne `AZURE_WEBAPP_NAME` til App Service-navnet og `API_BASE_URL` til API'ets faktiske HTTPS-adresse i **Settings → Secrets and variables → Actions**.
3. Aktivér SCM Basic Auth Publishing Credentials i Azure til denne publiceringsmetode. Hent appens publiceringsprofil og læg hele XML-indholdet i GitHub-hemmeligheden `AZURE_WEBAPP_PUBLISH_PROFILE`.
4. Flet pull requesten til `master`, eller kør workflowet manuelt på `master` efter opsætningen. Workflowet tester repository'et før publicering og kontrollerer derefter det publicerede endpoint. Kør også Postman-collectionen mod Azure.

[Azure App Service og GitHub Actions](https://learn.microsoft.com/en-us/azure/app-service/deploy-github-actions)
