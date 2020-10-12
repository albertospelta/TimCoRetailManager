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
        private readonly SalesViewModel _salesViewModel;

        public ShellViewModel(IEventAggregator events, SalesViewModel salesViewModel)
        {
            _events = events;
            _salesViewModel = salesViewModel;

            _events.Subscribe(this);

            var loginViewModel = IoC.Get<LoginViewModel>();
            ActivateItem(loginViewModel);
        }

        public void Handle(LogOnEventModel message)
        {
            ActivateItem(_salesViewModel);
        }
    }
}
