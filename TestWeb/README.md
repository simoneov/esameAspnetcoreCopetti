C'è un gestionale già esistente per il tracciamento delle ferie dei dipendenti.

fatto
0.
Creare un repo Git, aggiungere il docente come collaboratore e caricare in push le implementazioni richieste nei punti sottostanti.
L'appsettings.json va aggiunto al .gitignore.
Nell'appsettings va creata una proprietà DbConnectionString con la stringa di connessione, usata poi nel Program.cs.

più o meno fatto
1.
Correggere gli script SQL, che hanno evidenti errori.

fatto
2.
In EmployeesController.List(), lo sviluppatore precedente non sapeva come prendere
nome e cognome della entity e concatenarli con uno spazio in mezzo
per restituire un'unica stringa NameSurname.

fatto
3.
La lista di impiegati va restituita ordinata per cognome e poi per nome.

fatto
4.
Il parametro di input filter va usato per filtrare la lista restituita.
Se il parametro è popolato (cioè non null e non stringa vuota),
bisogna restituire solo gli impiegati con quella stringa presente
nel nome o nel cognome (case insensitive).
Quindi un impiegato come Mario Rossi deve risultare nella lista sia con un filtro come "ri" che come "ro".

fatto
5.
Sul metodo List() manca il giusto attributo per permettere l'accesso solo in Get.

fatto
6.
Nel metodo AddVacation(), ricevo un dto con nome e cognome dell'impiegato a cui aggiungere le ferie (separati da uno spazio).
Lo sviluppatore precedente non sapeva come usare questa informazione per pescare il giusto impiegato con una query di EF Core.
Completa la query (non è permesso pescare tutti i dipendenti in memoria, bisogna usare una query di LINQ to SQL).

fatto
7.
In AddVacation(), la riga che aggiunge una Vacation all'Employee scoppia con una NullReferenceException.
Cosa bisogna aggiungere alla query subito precedente per correggere?

fatto
8.
In AddVacation() bisogna validare il dto: per esempio, l'EmployeeId dev'essere valido.
Inoltre, la data di End deve essere uguale o superiore alla data di Start.
Aggiungere le validazioni necessarie, e se il dto non è valido, impostare uno status code di 400.


9.
I dati di inizio e fine vacanza non devono essere scritti così come sono sul database, ma bisogna ridurli in caso di vacanze sovrapposte.
Per esempio, supponiamo che ci siano già le seguenti vacanze segnate:
1/4 - 10/4
15/4 - 20/4
Se si aggiunge un nuovo periodo di vacanza con intervallo 8/4 - 16/4, a database va aggiunto con intervallo 11/4-14/4,
perché i giorni 8-10 e 15-16 si sovrappongono a periodi già schedulati.

fatto
10.
In GetVacationDays() gestire la possibilità che l'employeeId di input non corrisponda a nessun impiegato.

fatto
11.
GetVacationDays() calcola i giorni totali di vacanza di un impiegato in forma di TimeSpan.
Non si sapeva però come convertire poi un TimeSpan nel numero totale di giorni per popolare il Dto.
Trova il modo di fare la conversione, e verifica anche anche l'aggregate calcoli il numero totale di giorni in modo corretto.

12.
GetVacationDays() non dovrebbe calcolare i weekend.
Se un impiegato ha vacanza dal 7/4 al 14/4, i giorni di vacanza saranno i 5 giorni infrasettimanali.
Vanno cioè esclusi sabati e domeniche.
