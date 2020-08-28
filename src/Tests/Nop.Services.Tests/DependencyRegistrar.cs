using Autofac;
using Nop.Core.Caching;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Tests;

namespace Nop.Services.Tests
{
    /// <summary>
    /// Dependency registrar
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="appSettings">App settings</param>
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, AppSettings appSettings)
        {
            //cache managers
            builder.RegisterType<TestCacheManager>().As<IStaticCacheManager>().Named<IStaticCacheManager>("nop_cache_static").SingleInstance();
        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order => 0;
    }

}
