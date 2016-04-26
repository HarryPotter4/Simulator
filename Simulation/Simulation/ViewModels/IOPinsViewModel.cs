using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Simulation.ViewModels
{
    class IOPinsViewModel : Screen
    {
        
        private RamViewModel ramViewModel;

        public IOPinsViewModel(RamViewModel ramViewModel)
        {
            this.ramViewModel = ramViewModel;
        }

        private bool _Checkbox_PortA_Pin0;

        public bool Checkbox_PortA_Pin0
        {
            get
            {
                return _Checkbox_PortA_Pin0;
            }

            set
            {
                _Checkbox_PortA_Pin0 = value;
                NotifyOfPropertyChange(() => Checkbox_PortA_Pin0);
            }
        }
        
        public void portA_pin0()
        {
            MessageBox.Show("Hallo, value" + Checkbox_PortA_Pin0);
        }

        public IOPinsViewModel getIOPinsViewModel()
        {
            return this;
        }

        public IOPinsViewModel getiopinsviewmodel()
        {
            return this;
        }
    }
}
