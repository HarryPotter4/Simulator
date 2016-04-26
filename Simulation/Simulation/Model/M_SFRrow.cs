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
        private string _Column_0;
        private string _Column_1;
        private string _Column_2;
        private string _Column_3;
        private string _Column_4;
        private string _Column_5;
        private string _Column_6;
        private string _Column_7;
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

        public string Column_0
        {
            get
            {
                return _Column_0;
            }

            set
            {
                _Column_0 = value;
                NotifyOfPropertyChange(() => Column_0);
            }
        }

        public string Column_1
        {
            get
            {
                return _Column_1;
            }

            set
            {
                _Column_1 = value;
                NotifyOfPropertyChange(() => Column_1);
            }
        }

        public string Column_2
        {
            get
            {
                return _Column_2;
            }

            set
            {
                _Column_2 = value;
                NotifyOfPropertyChange(() => Column_2);
            }
        }

        public string Column_3
        {
            get
            {
                return _Column_3;
            }

            set
            {
                _Column_3 = value;
                NotifyOfPropertyChange(() => Column_3);
            }
        }

        public string Column_4
        {
            get
            {
                return _Column_4;
            }

            set
            {
                _Column_4 = value;
                NotifyOfPropertyChange(() => Column_4);
            }
        }

        public string Column_5
        {
            get
            {
                return _Column_5;
            }

            set
            {
                _Column_5 = value;
                NotifyOfPropertyChange(() => Column_5);
            }
        }

        public string Column_6
        {
            get
            {
                return _Column_6;
            }

            set
            {
                _Column_6 = value;
                NotifyOfPropertyChange(() => Column_6);
            }
        }

        public string Column_7
        {
            get
            {
                return _Column_7;
            }

            set
            {
                _Column_7 = value;
                NotifyOfPropertyChange(() => Column_7);
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
