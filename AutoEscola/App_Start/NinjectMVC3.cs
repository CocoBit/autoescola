[assembly: WebActivator.PreApplicationStartMethod(typeof(AutoEscola.App_Start.NinjectMVC3), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(AutoEscola.App_Start.NinjectMVC3), "Stop")]

namespace AutoEscola.App_Start
{
    using System.Reflection;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Mvc;
    using AutoEscola.Models;
    using AutoEscola.Repository;
    using AutoEscola.Models.Repositories;
    using AutoEscola.Models.Sevices.Interfaces;
    using AutoEscola.Models.Sevices;
    using AutoEscola.Contexts.Models;

    public static class NinjectMVC3 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        private static AutoEscolaContext context = new AutoEscolaContext();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestModule));
            DynamicModuleUtility.RegisterModule(typeof(HttpApplicationInitializationModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUsuarioRepository>().To<UsuarioRepository>().WithConstructorArgument("context", context);
            kernel.Bind<IPessoaRepository>().To<PessoaRepository>().WithConstructorArgument("context", context);
            kernel.Bind<IAlunoRepository>().To<AlunoRepository>().WithConstructorArgument("context", context);
        }        
    }
}
