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
        private bool _Checkbox_PortA_Pin4;
        private RamViewModel ramViewModel;

        public IOPinsViewModel(RamViewModel ramViewModel)
        {
            this.ramViewModel = ramViewModel;
        }

        public bool Checkbox_PortA_Pin4
        {
            get
            {
                return _Checkbox_PortA_Pin4;
            }

            set
            {
                _Checkbox_PortA_Pin4 = value;
                ramViewModel.setBit(0, 5, 4, getIntValue(Checkbox_PortA_Pin4)); 
                NotifyOfPropertyChange(() => Checkbox_PortA_Pin4);
                MessageBox.Show("portA_pin4 property");
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


        public void isChecked_A_0()
        {
            MessageBox.Show("portA_pin0 function");
            
        }

        public void isUnchecked_A_0()
        {
            MessageBox.Show("Unchecked");
        }
    }
}
