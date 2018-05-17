[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WcfDI_Ninject.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(WcfDI_Ninject.App_Start.NinjectWebCommon), "Stop")]

namespace WcfDI_Ninject.App_Start
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using System;
    using System.ServiceModel.Dispatcher;
    using System.Web;
    using Wucefus.Api.Inspectors;
    using Wucefus.Core.Repositories;
    using Wucefus.Core.Services;
    using Wucefus.Core.Services.Loggers;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IConsentRepository>().To<MockedConsentRepository>().WithConstructorArgument("connectionString", @"127.0.0.1\NinjectDB");
            kernel.Bind<IConsentService>().To<ConsentService>();
            kernel.Bind<IKrisLogger>().To<KrisLogger>();
        }
    }
}
