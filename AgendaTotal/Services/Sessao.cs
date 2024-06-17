using AgendaTotal.Services;
using Microsoft.Build.Framework;
using Newtonsoft.Json;
using NuGet.Common;
using NuGet.Protocol.Plugins;
using AgendaTotal.Models;

namespace AgendaTotal.Services
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly string tokenSessao;

        public Sessao(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.tokenSessao = "login";
        }
        public void addTokenLogin(Usuario login)
        {
            string loginTokenJson = JsonConvert.SerializeObject(login);
            this.httpContextAccessor.HttpContext.Session.SetString(this.tokenSessao, loginTokenJson);
        }

        public Usuario getTokenLogin()
        {
            string loginTokenJson = this.httpContextAccessor.HttpContext.Session.GetString(this.tokenSessao);
            return loginTokenJson != null ? JsonConvert.DeserializeObject<Usuario>(loginTokenJson) : null;
        }

        public void deleteTokenLogin()
        {
            this.httpContextAccessor.HttpContext.Session.Remove(this.tokenSessao);
        }
    }
}
