public class Documento
{
    public string Codice { get; set; }
    public string Titolo { get; }

    public int Anno { get; set; }
    public string Settore { get; }
    public string Stato { get; set; }
    public string Scaffale { get; set; }
    public string Autore { get; }

    public Documento(string codice, string titolo, int anno, string stato, string settore, string scaffale, string autore)
    {
        Codice = codice;
        Titolo = titolo;
        Anno = anno;
        Stato = stato;
        Settore = settore;
        Scaffale = scaffale;
        Autore = autore;
    }
    public override string ToString()
    {
        return Titolo + " Codice : " + Codice;
    }
}