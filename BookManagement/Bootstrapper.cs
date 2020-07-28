using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BookManagement.ViewModel;


namespace BookManagement
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }
        /// <summary>
        /// The container.
        /// </summary>
        private SimpleContainer container;
        /// <summary>
        /// Configuration
        /// </summary>
        protected override void Configure()
        {
            container = new SimpleContainer();
            // Create singleton instance.
            container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>();
            // Register viewmodel for starting.
            container
                .PerRequest<LoginViewModel>()
                .PerRequest<StartMainViewModel>();
            ChangeMappingLocator();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<LoginViewModel>();
        }
        /// <summary>
        /// Get instance IoC.
        /// </summary>
        /// <param name="service">The service type</param>
        /// <param name="key">Add key</param>
        /// <returns>The instance of service type</returns>
        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }
        /// <summary>
        /// Get all instance of service type IoC.
        /// </summary>
        /// <param name="service">The service type</param>
        /// <returns>Collection of service type</returns>
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }
        /// <summary>
        /// Build up container.
        /// </summary>
        /// <param name="instance">The instance.</param>
        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }
        /// <summary>
        /// Change mapping locator between view & viewmodel.
        /// </summary>
        private void ChangeMappingLocator()
        {
            // configure view & viewmodel locator.
            var config = new TypeMappingConfiguration
            {
                DefaultSubNamespaceForViews = "BookManagement.View",
                DefaultSubNamespaceForViewModels = "BookManagement.ViewModel"
            };
            Caliburn.Micro.ViewLocator.ConfigureTypeMappings(config);
            ViewModelLocator.AddSubNamespaceMapping("BookManagement.ViewModel", "BookManagement.View");
        }
    }
}