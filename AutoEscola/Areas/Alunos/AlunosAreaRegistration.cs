using System.Web.Mvc;

namespace AutoEscola.Areas.Alunos
{
    public class AlunosAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Alunos";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Alunos_default",
                "Alunos/{controller}/{action}/{id}",
                new { controller="HomeAlunos", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
