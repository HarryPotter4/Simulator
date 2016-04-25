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

        private bool _Checkbox_Pin7;

        public bool Checkbox_Pin7
        {
            get
            {
                return _Checkbox_Pin7;
            }

            set
            {
                _Checkbox_Pin7 = value;
                NotifyOfPropertyChange(() => Checkbox_Pin7);
            }
        }
    }
}
