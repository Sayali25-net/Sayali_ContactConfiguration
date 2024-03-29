using ContactConfiguration.Models;
using ContactConfiguration.Repositories;
using System;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace ContactConfiguration
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        //#region Unity Container
        //private static Lazy<IUnityContainer> container =
        //  new Lazy<IUnityContainer>(() =>
        //  {

        //      RegisterTypes(container);
        //      return container;
        //  });
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IContactPersonRepository, ContactRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        //public static IUnityContainer Container => container.Value;
      

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        //public static void RegisterTypes(IUnityContainer container)
        //{
        //    // NOTE: To load from web.config uncomment the line below.
        //    // Make sure to add a Unity.Configuration to the using statements.
        //    // container.LoadConfiguration();

        //    // TODO: Register your type's mappings here.
        //    // container.RegisterType<IProductRepository, ProductRepository>();
        //}
    }
    //#endregion
}
