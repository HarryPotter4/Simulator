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
        public void portA_pin7()
        {
            MessageBox.Show("Hallow ");
        }

        private bool _Checkbox_PortA_Pin7;
        private RamViewModel ramViewModel;

        public IOPinsViewModel(RamViewModel ramViewModel)
        {
            this.ramViewModel = ramViewModel;
        }

        public bool Checkbox_PortA_Pin7
        {
            get
            {
                return _Checkbox_PortA_Pin7;
            }

            set
            {
                _Checkbox_PortA_Pin7 = value;
                ramViewModel.setBit(0, 5, 4, getIntValue(Checkbox_PortA_Pin7));
                NotifyOfPropertyChange(() => Checkbox_PortA_Pin7);
            }
        }

        private int getIntValue(bool boolValue )
        {
            if (boolValue)
                return 1;
            else if (!boolValue)
                return 0;
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
