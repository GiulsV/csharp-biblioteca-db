/*
 Riprendiamo l’esercizio della biblioteca considerando però aclune varianti:
non è necessario (ma consigliato) ragionare con gli oggetti.
evitiamo categoricamente la questione dell’eredità tra oggetti
potete implementare una singola tabella per tutti i documenti: ovviamente in questo caso ci dovrà essere una colonna che gestisce il tipo di documento
Realizzate almeno le tabelle dei documenti e dei prestiti con le opportune relazioni; qui potete inserire solo un campo nome cliente nel prestito e ignorare la parte di registrazione richiesta
nel database potete usare una sola colonna varchar, direttamente nel documento, per inserire il nome e cognome dell’autore
Bonus: implementate anche la tabella utente e i controllo di registrazione (che significa che l’utente è dentro al db e quindi prima di fare il prestito deve essere trovato dal bibliotecario attraverso il sistema)

 */


//Lista Documenti
List<Documento> documenti = new List<Documento>();

//DVD
Dvd dvd1 = new Dvd("123", "Harry Potter", 2001, "In prestito", "Fantastico", "D6", "Chris Columbus", 159);
Dvd dvd2 = new Dvd("1234", "Big Fish", 2003, "Disponibile", "Drammatico", "D9", "Tim Burton", 125);
Dvd dvd3 = new Dvd("12345", "Nuovo Cinema Paradiso", 1988, "Disponibile", "Sentimentale", "D10", "Giuseppe Tornatore", 130);
documenti.Add(dvd1);
documenti.Add(dvd2);
documenti.Add(dvd3);
//Libri
Libro libro1 = new Libro("00123", "Clean Code", 2008, "In prestito", "Informatica", "L8", "Robert Cecil Martin", 431);
Libro libro2 = new Libro("001234", "La Divina Commedia", 2022, "Disponibile", "Poema", "L21", "Dante Alighieri", 259);
Libro libro3 = new Libro("0012345", "Anna Karenina", 1877, "In prestito", "Romanzo", "L4", "Lev Tolstoj", 1107);
documenti.Add(libro1);
documenti.Add(libro2);
documenti.Add(libro3);

//Lista utenti
List<Utente> utenti = new List<Utente>();
Utente utente1 = new Utente("Mario", "Rossi", "rossi@gmail.com", "3523144537");
Utente utente2 = new Utente("Paolo", "Verdi", "verdi@gmail.com", "0861592048");
utenti.Add(utente1);
utenti.Add(utente2);

//Lista prestiti
List<Prestito> prestiti = new List<Prestito>();
Prestito prestito1 = new Prestito("08/02/2022", "08/03/2022", dvd3, utente1);
Prestito prestito2 = new Prestito("20/04/2022", "20/05/2022", libro1, utente2);
Prestito prestito3 = new Prestito("07/10/2022", "07/11/2022", dvd2, utente2);
prestiti.Add(prestito1);
prestiti.Add(prestito2);
prestiti.Add(prestito3);

//Menu
Console.WriteLine("Benvenuto, effetua una scelta:");
Console.WriteLine("[1] eseguire una ricerca");
Console.WriteLine("[2] effettuare un prestito");
Console.WriteLine("[3] cercare un prestito");
int scelta = Convert.ToInt32(Console.ReadLine());

//Eseguire una ricerca
if (scelta == 1)
{
    Console.WriteLine("Digita [codice] per cercare codice");
    Console.WriteLine("Digita [titolo] per cercare titolo");
    string sceltaRicerca = Console.ReadLine();

    if (sceltaRicerca == "codice")          //per codice
    {
        Console.WriteLine("Inserisci il codice");
        string codiceRicerca = Console.ReadLine();

        foreach (Documento item in documenti)
        {
            if (item.Codice == codiceRicerca)
            {
                Console.WriteLine("{1}: {0} ", item, item.GetType().ToString());
            }
        }
    }
    else if (sceltaRicerca == "titolo")         //per titolo
    {
        Console.WriteLine("Inserisci il titolo");
        string titoloRicerca = Console.ReadLine();

        foreach (Documento item in documenti)
        {
            if (item.Titolo == titoloRicerca)
            {
                Console.WriteLine("{1}: {0} ", item, item.GetType().ToString());
            }
        }
    }
    else { Console.WriteLine("Documento non presente nel database"); }       //errore
}
//Effettuare un prestito
else if (scelta == 2)
{
    Console.WriteLine("Inizio prestito");
    string startPrestito = Console.ReadLine();
    Console.WriteLine("Fine prestito");
    string endPrestito = Console.ReadLine();
    Console.WriteLine("Titolo del documento");
    string titoloRicerca = Console.ReadLine();
    Documento docPrestito = new Documento("", "", 0, "", "", "", "");
    bool presente = true;

    foreach (Documento item in documenti)
    {
        if (item.Titolo == titoloRicerca)
        {
            Console.WriteLine("{1}: {0} ", item, item.GetType().ToString());
            docPrestito = item;

            if (item.Stato == "In prestito")
            {
                Console.WriteLine("Il documento è attualmente in prestito");
                presente = false;
            }
        }
    }
    if (docPrestito.Titolo == "")    //documento non trovato
    {
        Console.WriteLine("Documento non trovato");
    }
    else if (presente == true)      //inserisco dati utente che richiede il prestito
    {
        Console.WriteLine("Nome di chi richiede il prestito");
        string nome = Console.ReadLine();
        Console.WriteLine("Cognome di chi richiede il prestito");
        string cognome = Console.ReadLine();

        foreach (Utente item in utenti)
        {
            if (item.Nome == nome && item.Cognome == cognome)
            {

                Utente utente = item;
                Prestito prestito = new Prestito(startPrestito, endPrestito, docPrestito, utente);
                Console.WriteLine("{1}: {0} ", prestito, prestito.GetType().ToString());
                prestiti.Add(prestito);
            }
        }
    }
}
//Cercare un prestito
else if (scelta == 3)
{
    Console.WriteLine("Nome di chi cerca il prestito");
    string nome = Console.ReadLine();
    Console.WriteLine("Cognome di chi cerca il prestito");
    string cognome = Console.ReadLine();

    foreach (Prestito item in prestiti)
    {
        if (item.Utente.Nome == nome && item.Utente.Cognome == cognome)
        {
            Console.WriteLine("{1}: {0} ", item, item.GetType().ToString());
        }
    }
}
else        //Errore
{
    Console.WriteLine("Scelta errata");
}