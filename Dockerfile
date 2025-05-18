# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:9.0.0-preview.4
WORKDIR /app

# Copia tudo e restaura dependências
COPY . . 
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/out .

# Porta exposta
EXPOSE 80

# Comando para iniciar a aplicação
ENTRYPOINT ["dotnet", "Rifa-Casa.dll"]
