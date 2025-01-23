# Web-application-in-.NET---Railway-system

Opis projektu w .NET


Opis projektu w .NET
Ten projekt został stworzony w celu zarządzania danymi w relacyjnej bazie danych(System kolejowy). Posiada następujące funkcjonalności:

1.Umożliwia dodawaniei usuwanie rekordów w tabelach bazy danych.

2.Specjalne funkcje zarządzania danymi: przycisk do kasowania wszystkich danych z wybranej tabeli.
Przycisk uzupełniający wybraną kolumnę predefiniowanymi wartościami, np. anonimizacja danych np. powód opóźnienia w tabeli opóźnień.

3.Filtrowanie i sortowanie: filtrowanie po określonych polach, takich jak stacja źródłowa i docelowa (realizowane przez pole tekstowe do wyszukiwania).
Sortowanie po czasie odjazdu oraz stacji źródłowej.

4. Relacja master-slave:
Tabela master: tabela pociągi pełni rolę główną, wyświetlając listę dostępnych pociągów.
Tabela slave: tabela rozkład działa jako zależna, dynamicznie wczytując harmonogramy dla wybranego pociągu.
Po zaznaczeniu konkretnego pociągu w tabeli pociągi aplikacja automatycznie wyświetla odpowiadające mu rozkłady jazdy w tabeli rozkład. 
