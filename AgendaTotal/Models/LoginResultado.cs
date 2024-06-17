namespace AgendaTotal.Models
{
    public class LoginResultado
    {
        public int Id { get; set; }

        public bool Sucesso { get; set; }

        public string TipoUsuario { get; set; }

        public LoginResultado()
        {
            Id = 0;
            TipoUsuario = string.Empty;
        }
    }
}
