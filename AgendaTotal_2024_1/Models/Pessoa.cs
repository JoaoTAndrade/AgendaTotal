namespace AgendaTotal_2024_1.Models
{
        public abstract class Pessoa
    {
        int Id { get; set; }
        string Nome { get; set; }
        string Logradouro { get; set; }
        int Numero { get; set; }
        string Bairro { get; set; }
        string Cidade { get; set; }
        char Estado { get; set; }
        string Pais { get; set; }
        string Telefone { get; set; }
        string Email { get; set; }


    }
}
