ESHOP – databázová aplikace v C# s MySQL

Poadavky

Windows 10+

MySQL Server 8.x

.NET 8 Runtime

MySQL Connector/NET

Struktura projektu
/src   – zdrojové kódy aplikace
/db    – SQL skripty databáze
/doc   – dokumentace
/test  – testovací scénáøe

Instalace databáze

Spus MySQL Server

Vytvoø databázi:

CREATE DATABASE eshop;


Importuj strukturu:

mysql -u root -p eshop < db/eshop.sql

Vytvoøení DB uivatele
CREATE USER 'eshop_user'@'localhost' IDENTIFIED BY 'heslo';
GRANT ALL PRIVILEGES ON eshop.* TO 'eshop_user'@'localhost';

Spuštìní aplikace

spus Eshop.UI.exe

pøihlas se pomocí údajù k MySQL

Aplikace je plnì funkèní bez IDE.