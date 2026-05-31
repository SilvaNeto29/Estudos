# 1. Sobe o container
docker compose up -d

# 2. Aguarda ~30s pro SQL Server inicializar (ele é lento pra subir)

# 3. Conecta no container
docker exec -it sqlserver2022 bash

-- init/01_setup.sql
-- Executado automaticamente ao criar o container (se você montar a pasta ./init)
-- Ajuste os nomes conforme seu projeto

-- Cria banco de desenvolvimento
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'DevDB')
BEGIN
    CREATE DATABASE DevDB;
END
GO

-- Cria login de aplicação (opcional — use SA apenas localmente)
USE [master];
GO

IF NOT EXISTS (SELECT name FROM sys.server_principals WHERE name = 'dev_user')
BEGIN
    CREATE LOGIN dev_user WITH PASSWORD = 'Dev@Strong123', CHECK_POLICY = OFF;
END
GO

USE [DevDB];
GO

IF NOT EXISTS (SELECT name FROM sys.database_principals WHERE name = 'dev_user')
BEGIN
    CREATE USER dev_user FOR LOGIN dev_user;
    ALTER ROLE db_owner ADD MEMBER dev_user;
END
GO