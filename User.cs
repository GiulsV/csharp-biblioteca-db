public class Utente
{
    public string Nome { get; }
    public string Cognome { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }

    public Utente(string nome, string cognome, string email, string telefono)
    {
        this.Nome = nome;
        this.Cognome = cognome;
        this.Email = email;
        this.Telefono = telefono;
    }
}