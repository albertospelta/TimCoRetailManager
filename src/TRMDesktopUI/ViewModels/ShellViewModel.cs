using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRMDesktopUI.EventModels;

namespace TRMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEventModel>
    {
        private readonly IEventAggregator _events;
        private readonly SimpleContainer _container;
        private readonly SalesViewModel _salesViewModel;

        public ShellViewModel(IEventAggregator events, SimpleContainer container, SalesViewModel salesViewModel)
        {
            _events = events;
            _container = container;
            _salesViewModel = salesViewModel;

            _events.Subscribe(this);

            var loginViewModel = _container.GetInstance<LoginViewModel>();
            ActivateItem(loginViewModel);
        }

        public void Handle(LogOnEventModel message)
        {
            ActivateItem(_salesViewModel);
        }
    }
}
