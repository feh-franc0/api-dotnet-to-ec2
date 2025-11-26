# ---------- ETAPA 1: IMAGEM COM SDK PARA COMPILAR O PROJETO ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# ---------- DEFINE O DIRETÓRIO DE TRABALHO DENTRO DO CONTAINER ----------
WORKDIR /src

# ---------- COPIA TODOS OS ARQUIVOS DO PROJETO PARA DENTRO DO CONTAINER ----------
COPY . .

# ---------- RESTAURA AS DEPENDÊNCIAS (NUGET PACKAGES) ----------
RUN dotnet restore

# ---------- COMPILA O PROJETO EM MODO RELEASE E PUBLICA OS BINÁRIOS ----------
RUN dotnet publish -c Release -o /app/publish


# ---------- ETAPA 2: IMAGEM FINAL (SÓ RUNTIME, MAIS LEVE) ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# ---------- DEFINE O DIRETÓRIO DE EXECUÇÃO ----------
WORKDIR /app

# ---------- COPIA OS ARQUIVOS COMPILADOS DA ETAPA DE BUILD ----------
COPY --from=build /app/publish .

# ---------- CONFIGURA A API PARA OUVIR EM TODAS AS INTERFACES NA PORTA 5000 ----------
ENV ASPNETCORE_URLS=http://0.0.0.0:5000

# ---------- COMANDO QUE INICIA A API QUANDO O CONTAINER SOBE ----------
ENTRYPOINT ["dotnet", "ApiSeguidores.dll"]
