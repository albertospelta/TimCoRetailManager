using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TRMDesktopUI.ViewModels;

namespace TRMDesktopUI
{
    public class Bootstrapper : BootstrapperBase
    {
        private readonly SimpleContainer _container = new SimpleContainer();

        public Bootstrapper() => Initialize();

        protected override void Configure()
        { 
            _container.Instance(_container);

            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>();

            var viewModelTypes = GetType().Assembly.GetTypes().Where((t) => t.IsClass && t.Name.EndsWith("ViewModel"));
            foreach (var viewModelType in viewModelTypes)
                _container.RegisterPerRequest(viewModelType, viewModelType.ToString(), viewModelType);
        }

        protected override void OnStartup(object sender, StartupEventArgs e) => DisplayRootViewFor<ShellViewModel>();

        protected override object GetInstance(Type service, string key) => _container.GetInstance(service, key);

        protected override IEnumerable<object> GetAllInstances(Type service) => _container.GetAllInstances(service);

        protected override void BuildUp(object instance) => _container.BuildUp(instance);
    }
}
