# ESHOP – databázová aplikace v C# a MySQL
Autor-Petr Čermák
Tento projekt je školní databázová aplikace typu **ESHOP**, vytvořená v jazyce **C# (.NET 8, WPF)** s využitím **relační databáze MySQL** a návrhového vzoru **Table Gateway**.

Projekt je navržen tak, aby byl:
- spustitelný jak v exe tak sln
- testovatelný dle testovacích scénářů
- strukturovaný
---
Obsah projektu:

- Rozdělení podle Three-tier architektury
	- UI vrstva: ve formě Windows Presentation Foundation (WPF), složka UI2
	- Data vrstva: komunikace s MySQL (přihlášení + crud metody), složka Data2
	- Domain vrstva: má struktury entit, složka Domain2
- relační databázový systém
- 5 tabulek
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

## Jak zprovoznit aplikaci

1. V MySQL vytvoříte databázi dle eshop\db\eshop.sql
2. Spustíte program v eshop\src\UI2\bin\Release\net8.0-windows\UI2.exe
