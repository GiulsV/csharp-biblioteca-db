using System.Data.SqlClient;
public class BiblioDB
{
    private string connectionString = "Data Source=localhost;Initial Catalog=db_biblioteca;Integrated Security=True";
    private SqlConnection connection;
    public BiblioDB()
    {
        connection = new SqlConnection(connectionString);
        try
        {
            connection.Open();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void CloseConnection()
    {
        connection.Close();
    }

    public void AddDocumento(Documento documento)
    {
        string query = "INSERT INTO Documenti (codice, titolo, anno, settore, stato, scaffale, autore, tipo, durata, pagine) " +
            "VALUES (@codice, @titolo, @anno, @settore, @stato, @scaffale, @autore, @tipo, null, @numPagine)";
        SqlCommand insertCommand = new SqlCommand(query, connection);
        insertCommand.Parameters.Add(new SqlParameter("@codice", documento.Codice));
        insertCommand.Parameters.Add(new SqlParameter("@titolo", documento.Titolo));
        insertCommand.Parameters.Add(new SqlParameter("@anno", documento.Anno));
        insertCommand.Parameters.Add(new SqlParameter("@settore", documento.Settore));
        insertCommand.Parameters.Add(new SqlParameter("@disponibile", documento.Stato));
        insertCommand.Parameters.Add(new SqlParameter("@scaffale", documento.Scaffale));
        insertCommand.Parameters.Add(new SqlParameter("@autore", documento.Autore));

        if (documento is Libro)
        {
            Libro libro = (Libro)documento;
            insertCommand.Parameters.Add(new SqlParameter("@tipo", 'l'));
            insertCommand.Parameters.Add(new SqlParameter("@durata", DBNull.Value));
            insertCommand.Parameters.Add(new SqlParameter("pagine", libro.numPagine));
        }

        if (documento is Dvd)
        {
            Dvd dvd = (Dvd)documento;
            insertCommand.Parameters.Add(new SqlParameter("@tipo", 'd'));
            insertCommand.Parameters.Add(new SqlParameter("@durata", dvd.Durata));
            insertCommand.Parameters.Add(new SqlParameter("pagine", DBNull.Value));
        }

        insertCommand.ExecuteNonQuery();
    }
}
