# ITN_DOT
Technologie .NET

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
