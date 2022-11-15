public class Libro : Documento
{
    public int numPagine { get; }

    public Libro(string codice, string titolo, int anno, string stato, string settore, string scaffale, string autore, int pagine) : base(codice, titolo, anno, stato, settore, scaffale, autore)
    {
        numPagine = pagine;
    }
}
