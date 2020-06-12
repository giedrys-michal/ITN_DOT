# ITN_DOT
Technologie .NET

Migracja bazy danych:

https://docs.microsoft.com/pl-pl/ef/ef6/modeling/code-first/migrations/?redirectedfrom=MSDN

Samouczek tutaj:

https://docs.microsoft.com/pl-pl/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application#initialize-db-with-test-data

wymagania projektowe:
paginacja
testy
entity framework
chat hubowy

HUBY:
manager pakietów: signalR core
dodać hub - proj -> dodaj (SiećWeb) - signalR Hub class
dodać akcję w kontrolerze
dodać widok
dodać klasę początkowa OWIN o nazwie startup

nazwy metod w widoku są z małej litery, dlatego w klasie Huba należy dodać dataannotation dla nazw metod również z małej litery:
"[HubMethodName("wyslijBezNicka")]"
