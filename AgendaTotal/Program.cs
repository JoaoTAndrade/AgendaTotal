namespace AgendaTotal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // 0. adicionado os servi�os de Interface e Classe de HttpContextAcessor e da Sessao.
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<Services.ISessao, Services.Sessao>();

            // 1. Adicionar o Servi�o de gerenciamento de Sess�o.
            builder.Services.AddSession(options => {
                /*
                 A propriedade IdTimeout refere-se ao tempo de expira��o da sess�o por inatividade.
                 O tempo padr�o para a inatividade da aplica��o ASP.NET � de 20 minutos.
                 */
                options.IdleTimeout = TimeSpan.FromMinutes(10); //10 minutos para expirar a sess�o.
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;

            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession(); // 2. Adicionar o uso de sessao ap�s UseAuthorization() e antes MapControllerRoute(...)

            app.MapControllerRoute(
                name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");
            //pattern: "{controller=Carros}/{action=Details}/{id=2}");
            pattern: "{controller=Login}/{action=Login}/{id?}");

            app.Run();
        }
    }
}