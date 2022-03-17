using App.Repository;
using App.Service.Mapping;
using Autofac;
using System.Reflection;
using Module = Autofac.Module;

namespace App.Web.Modules
{
    public class RepositoryServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            // Repository ve service projelerinde sonu Repository ve Service ile biten tüm interface ler otomatik olarak inject ediliyor
            var mvcAssembly = Assembly.GetExecutingAssembly();

            var serviceAssembly = Assembly.GetAssembly(typeof(MapperProfile));

            var repositoryAssembly = Assembly.GetAssembly(typeof(AksaContext));

            builder.RegisterAssemblyTypes(mvcAssembly, serviceAssembly, repositoryAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();


            builder.RegisterAssemblyTypes(mvcAssembly, serviceAssembly, repositoryAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
