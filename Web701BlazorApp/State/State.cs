using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web701BlazorApp.State
{
    public class StateControl
    {
        public StateOrderPlacement OrderPlacement = new StateOrderPlacement();
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
}
