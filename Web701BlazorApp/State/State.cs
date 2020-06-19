using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB701BalzorApp.Auth;

namespace Web701BlazorApp.State
{
    public class StateControl
    {
        public StateOrderPlacement OrderPlacement = new StateOrderPlacement();
        public StateUserNameChange UserNameChange = new StateUserNameChange();
        public string Agent = "";
        public string RemoteIP = "";
    }
    public class StateOrderPlacement
    {
        public event Action OnChange;
        public void Inserted()
        {
            NotifyStateChanged();
        }
        private void NotifyStateChanged() => OnChange?.Invoke();
    }


    public class StateUserNameChange
    {
        public event Action OnChange;
        public void Changed()
        {
            NotifyStateChanged();
        }
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
