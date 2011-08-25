using System.Web.Mvc;

namespace AutoEscola.Areas.Administracao
{
    public class AdministracaoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Administracao";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Administracao_default",
                "Administracao/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
