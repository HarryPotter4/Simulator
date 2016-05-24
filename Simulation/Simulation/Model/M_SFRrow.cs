using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Model
{
    class M_SFRrow : Screen
    {
        private string _Column_Description;       
        private string _Column_HEX;
        public string Column_Description
        {
            get
            {
                return _Column_Description;
            }

            set
            {
                _Column_Description = value;
                NotifyOfPropertyChange(() => Column_Description );                
            }
        }
        public string Column_HEX
        {
            get
            {
                return _Column_HEX;
            }

            set
            {
                _Column_HEX = value;
                NotifyOfPropertyChange(() => Column_HEX);                
            }
        }
    }
}
