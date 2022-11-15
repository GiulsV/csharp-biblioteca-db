public class Dvd : Documento
{
    public int Durata { get; }

    public Dvd(string codice, string titolo, int anno, string stato, string settore, string scaffale, string autore, int durata) : base(codice, titolo, anno, stato, settore, scaffale, autore)
    {
        Durata = durata;
    }
}