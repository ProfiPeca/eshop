# ESHOP – databázová aplikace v C# a MySQL
Autor-Petr Čermák
Tento projekt je školní databázová aplikace typu **ESHOP**, vytvořená v jazyce **C# (.NET 8, WPF)** s využitím **relační databáze MySQL** a návrhového vzoru **Table Gateway**.

Projekt je navržen tak, aby byl:
- spustitelný
- testovatelný dle testovacích scénářů
- strukturovaný.
---
Obsah projektu:

- UI vrstva: WPF
- Data vrstva: Table Gateway (ADO.NET, MySQL)
- Domain vrstva: Entity (Product, Customer, Order, …)
- Databázová logika je striktně oddělena od uživatelského rozhraní
- relační databázový systém
- minimálně 5 tabulek
- M:N vazba
- ENUM, FLOAT, BOOL, DATETIME
- transakce
- reporty
- import dat
- konfigurace a ošetření chyb

---

## Požadavky

- Windows 10 nebo novější
- MySQL Server 8.x
- .NET 8 Runtime

---

## Instalace databáze

1. Spusť MySQL Server
2. Vytvoř databázi importem SQL souboru:

```bash

sql
CREATE USER 'eshop_user'@'localhost' IDENTIFIED BY 'heslo';
GRANT ALL PRIVILEGES ON eshop.* TO 'eshop_user'@'localhost';
FLUSH PRIVILEGES;
Spuštění aplikace
Varianta A – spuštění hotového EXE (tester)
Spusť soubor:

Eshop.UI.exe

V přihlašovacím okně zadej:

Host: localhost

Databáze: eshop

Uživatel: dle MySQL

Heslo: dle MySQL

Varianta B – spuštění ve Visual Studiu (vývoj)
Otevři soubor:

Eshop.sln
Nastav projekt Eshop.UI jako Startup Project

Stiskni F5 nebo klikni na Start

Visual Studio provede build automaticky.

Funkcionalita aplikace
Přihlášení do MySQL databáze přes UI

Správa produktů (CRUD)

Vytváření objednávek (transakce nad více tabulkami)

M:N vazba objednávka–produkt

Souhrnné reporty (SQL VIEW + agregace)

Import dat:

CSV → produkty

JSON → zákazníci

Ošetření chyb (připojení, vstupy, transakce)

Testování
Postup testování je popsán v souborech ve složce /test
