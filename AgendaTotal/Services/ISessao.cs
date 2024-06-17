using NuGet.Protocol.Plugins;
using AgendaTotal.Models;

namespace AgendaTotal.Services
{
    public interface ISessao
    {
        void addTokenLogin(Usuario usuario);

        Usuario getTokenLogin();

        // Adicionar na classe Sessão (Sessão.cs) todos os métodos que estarão protegidos pela sessão.
        // Por exemplo: void update() do CarroController
        void deleteTokenLogin();
    }
}