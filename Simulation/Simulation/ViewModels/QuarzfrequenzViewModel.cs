using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.ViewModels
{
    class QuarzfrequenzViewModel : Screen
    {
        public QuarzfrequenzViewModel()
        {
            InitSelection = true;
            Laufzeit = "0".ToString();            
        }

        private string _Laufzeit;        
        private string _CurrentFrequenz;
        private bool _IsEnabled;
        private string _QuarzfrequenzView;
        private bool _InitSelection;


        public string CurrentFrequenz
        {
            get
            {
                return _CurrentFrequenz;
            }

            set
            {
                _CurrentFrequenz = value;
                NotifyOfPropertyChange(() => CurrentFrequenz);
            }
        }
        public bool IsEnabled
        {
            get
            {
                return _IsEnabled;
            }

            set
            {
                _IsEnabled = value;
                NotifyOfPropertyChange(() => IsEnabled);
            }
        }
        public string Laufzeit
        {
            get
            {
                return _Laufzeit;
            }

            set
            {
                _Laufzeit = value;
                NotifyOfPropertyChange(() => Laufzeit);
            }
        }

        public string QuarzfrequenzView
        {
            get
            {
                return _QuarzfrequenzView;
            }

            set
            {
                _QuarzfrequenzView = value;
                NotifyOfPropertyChange(() => QuarzfrequenzView);
            }
        }

        public bool InitSelection
        {
            get
            {
                return _InitSelection;
            }

            set
            {
                _InitSelection = value;
                NotifyOfPropertyChange(() => InitSelection);
            }
        }

        public QuarzfrequenzViewModel getQuarzFrequenzModel()
        {
            return this;
        }
    }
}
