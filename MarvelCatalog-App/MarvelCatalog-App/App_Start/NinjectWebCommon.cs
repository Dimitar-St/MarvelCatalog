[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MarvelCatalog_App.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MarvelCatalog_App.App_Start.NinjectWebCommon), "Stop")]

namespace MarvelCatalog_App.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using ViewModels;
    using AutoMapper;
    using Data.Contracts;
    using Data;
    using Data.Repositories;
    using Services.Contracts;
    using Services;
    using Marvel_Catalog_App.Data.Models;
    using Data.UnitOfWork;
    using Areas.Admin.Models;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
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
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                RegisterAutoMapper(kernel);
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
            kernel.Bind<IEfMarvelCatalogDbContext>().To<EfMarvelCatalogDbContext>();
            kernel.Bind<ICharacterService>().To<CharacterService>();
            kernel.Bind<IComicsService>().To<ComicsService>();
            kernel.Bind<ICreatorsService>().To<CreatorsService>();
            kernel.Bind<IUnitOfWork>().To<UnitOfwork>();
            kernel.Bind(typeof(IEfRepository<>)).To(typeof(EfRepository<>));
        }

        private static void RegisterAutoMapper(IKernel kernel)
        {
            var config = new MapperConfiguration(
                            c =>
                            {
                                c.CreateMap<CharacterDataModel, CharacterViewModel>();
                                c.CreateMap<ComicsDataModel, ComicsViewModel>();
                                c.CreateMap<CreatorsDataModel, CreatorViewModel>();
                                c.CreateMap<CharacterDataModel, CharactersAdminViewModel>();
                            });

            var mapper = config.CreateMapper();
            kernel.Bind<IMapper>().ToConstant(mapper);
        }
    }
}
