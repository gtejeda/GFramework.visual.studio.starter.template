using System;
using GFramework.core.commanding;
using GFramework.core.persistence;
using GFramework.core.querying;
using GFramework.data.dapper.commands;
using GFramework.data.dapper.handlers;
using GFramework.data.dapper.persistence;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using $ext_projectname$.application.CustomCommands;
using $ext_projectname$.application.DTOs;
using $ext_projectname$.business.commandHandlers;
using $ext_projectname$.core.customRepositories;
using $ext_projectname$.data.querying;
using $ext_projectname$.data.repositories;

namespace $safeprojectname$.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            container.RegisterType<ICommandProcessor, CommandProcessor>();

            container.RegisterType(typeof(IDapperRepository<>), typeof(GenericRepository<>));

            container.RegisterType(typeof(IQueryingService<>), typeof(GenericQueryingService<>));
            //container.RegisterType<IRepository<ICustomer>, CustomerRepository>();

            container.RegisterType(typeof(ICommandHandler<CreateEntityCommand<CustomerDTO>>), typeof(CreateEntityHandler<CreateEntityCommand<CustomerDTO>, CustomerDTO>));

            container.RegisterType(typeof(ICommandHandler<UpdateEntityCommand<CustomerDTO>>), typeof(UpdateEntityHandler<UpdateEntityCommand<CustomerDTO>, CustomerDTO>));

            container.RegisterType(typeof(ICommandHandler<DeleteEntityCommand<CustomerDTO>>), typeof(DeleteEntityHandler<DeleteEntityCommand<CustomerDTO>, CustomerDTO>));

            container.RegisterType(typeof(ICommandHandler<ActivateCustomerCommand>), typeof(ActivateCustomerHandler));

            container.RegisterType(typeof(ICustomerRepository), typeof(CustomerRepository));
        }
    }
}
