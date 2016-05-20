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
        private SfrViewModel sfrData;

        public IOPinsViewModel(RamViewModel ramViewModel,SfrViewModel sfr)
        {
            this.ramViewModel = ramViewModel;
            this.sfrData = sfr;
        }

        private bool _Checkbox_PortA_Pin0;
        private bool _Checkbox_PortA_Pin1;
        private bool _Checkbox_PortA_Pin2;
        private bool _Checkbox_PortA_Pin3;
        private bool _Checkbox_PortA_Pin4;

        private bool _Checkbox_PortB_Pin7;
        private bool _Checkbox_PortB_Pin6;
        private bool _Checkbox_PortB_Pin5;
        private bool _Checkbox_PortB_Pin4;
        private bool _Checkbox_PortB_Pin3;
        private bool _Checkbox_PortB_Pin2;
        private bool _Checkbox_PortB_Pin1;
        private bool _Checkbox_PortB_Pin0;
        

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
                if(Checkbox_PortA_Pin0)
                {
                    ramViewModel.setBit(0, 5, 0, 1);
                   
                }                
                else if(!Checkbox_PortA_Pin0)
                {
                    ramViewModel.setBit(0, 5, 0, 0);
                }
                sfrData.DataGrid_SFRView.ElementAt(1).Column_HEX = ramViewModel.getByte(0, 5).ToString();
            }
        }
        public bool Checkbox_PortA_Pin1
        {
            get
            {
                return _Checkbox_PortA_Pin1;
            }

            set
            {
                _Checkbox_PortA_Pin1 = value;
                NotifyOfPropertyChange(() => Checkbox_PortA_Pin1);
                if (Checkbox_PortA_Pin1)
                {
                    ramViewModel.setBit(0, 5, 1, 1);                   
                }
                else if (!Checkbox_PortA_Pin1)
                {
                    ramViewModel.setBit(0, 5, 1, 0);
                }
                sfrData.DataGrid_SFRView.ElementAt(1).Column_HEX = ramViewModel.getByte(0, 5).ToString();
            }
        }
        public bool Checkbox_PortA_Pin2
        {
            get
            {
                return _Checkbox_PortA_Pin2;
            }

            set
            {
                _Checkbox_PortA_Pin2 = value;
                NotifyOfPropertyChange(() => Checkbox_PortA_Pin2 );
                if (Checkbox_PortA_Pin2)
                {
                    ramViewModel.setBit(0, 5, 2, 1);
                }
                else if (!Checkbox_PortA_Pin2)
                {
                    ramViewModel.setBit(0, 5, 2, 0);
                }
                sfrData.DataGrid_SFRView.ElementAt(1).Column_HEX = ramViewModel.getByte(0, 5).ToString();
            }
        }
        public bool Checkbox_PortA_Pin3
        {
            get
            {
                return _Checkbox_PortA_Pin3;
            }

            set
            {
                _Checkbox_PortA_Pin3 = value;
                NotifyOfPropertyChange(() => Checkbox_PortA_Pin3);
                if (Checkbox_PortA_Pin3)
                {
                    ramViewModel.setBit(0, 5, 3, 1);
                }
                else if (!Checkbox_PortA_Pin3)
                {
                    ramViewModel.setBit(0, 5, 3, 0);
                }
                sfrData.DataGrid_SFRView.ElementAt(1).Column_HEX = ramViewModel.getByte(0, 5).ToString();
            }
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
                NotifyOfPropertyChange(() => Checkbox_PortA_Pin4);
                
                if (Checkbox_PortA_Pin4)
                {
                    ramViewModel.setBit(0, 5, 4, 1);
                }
                else if (!Checkbox_PortA_Pin4)
                {
                    ramViewModel.setBit(0, 5, 4, 0);
                }
                sfrData.DataGrid_SFRView.ElementAt(1).Column_HEX = ramViewModel.getByte(0, 5).ToString();
            }
        }

        public bool Checkbox_PortB_Pin0
        {
            get
            {
                return _Checkbox_PortB_Pin0;
            }

            set
            {
                _Checkbox_PortB_Pin0 = value;
                NotifyOfPropertyChange(() => Checkbox_PortB_Pin0);
                if (Checkbox_PortB_Pin0)
                {
                    ramViewModel.setBit(0, 6, 0, 1);
                }
                else if (!Checkbox_PortB_Pin0)
                {
                    ramViewModel.setBit(0, 6, 0, 0);
                }
                sfrData.DataGrid_SFRView.ElementAt(3).Column_HEX = ramViewModel.getByte(0, 6).ToString();
            }
        }
        public bool Checkbox_PortB_Pin1
        {
            get
            {
                return _Checkbox_PortB_Pin1;
            }

            set
            {
                _Checkbox_PortB_Pin1 = value;
                NotifyOfPropertyChange(() => Checkbox_PortB_Pin1);
                if (Checkbox_PortB_Pin1)
                {
                    ramViewModel.setBit(0, 6, 1, 1);
                }
                else if (!Checkbox_PortB_Pin1)
                {
                    ramViewModel.setBit(0, 6, 1, 0);
                }
                sfrData.DataGrid_SFRView.ElementAt(3).Column_HEX = ramViewModel.getByte(0, 6).ToString();
            }
        }
        public bool Checkbox_PortB_Pin2
        {
            get
            {
                return _Checkbox_PortB_Pin2;
            }

            set
            {
                _Checkbox_PortB_Pin2 = value;
                NotifyOfPropertyChange(() => Checkbox_PortB_Pin2);
                if (Checkbox_PortB_Pin2)
                {
                    ramViewModel.setBit(0, 6, 2, 1);
                }
                else if (!Checkbox_PortB_Pin2)
                {
                    ramViewModel.setBit(0, 6, 2, 0);
                }
                sfrData.DataGrid_SFRView.ElementAt(3).Column_HEX = ramViewModel.getByte(0, 6).ToString();
            }
        }
        public bool Checkbox_PortB_Pin3
        {
            get
            {
                return _Checkbox_PortB_Pin3;
            }

            set
            {
                _Checkbox_PortB_Pin3 = value;
                NotifyOfPropertyChange(() => Checkbox_PortB_Pin3);
                if (Checkbox_PortB_Pin3)
                {
                    ramViewModel.setBit(0, 6, 3, 1);
                }
                else if (!Checkbox_PortB_Pin3)
                {
                    ramViewModel.setBit(0, 6, 3, 0);
                }
                sfrData.DataGrid_SFRView.ElementAt(3).Column_HEX = ramViewModel.getByte(0, 6).ToString();
            }
        }
        public bool Checkbox_PortB_Pin4
        {
            get
            {
                return _Checkbox_PortB_Pin4;
            }

            set
            {
                _Checkbox_PortB_Pin4 = value;
                NotifyOfPropertyChange(() => Checkbox_PortB_Pin4);
                if (Checkbox_PortB_Pin4)
                {
                    ramViewModel.setBit(0, 6, 4, 1);
                }
                else if (!Checkbox_PortB_Pin4)
                {
                    ramViewModel.setBit(0, 6, 4, 0);
                }
                sfrData.DataGrid_SFRView.ElementAt(3).Column_HEX = ramViewModel.getByte(0, 6).ToString();
            }
        }
        public bool Checkbox_PortB_Pin5
        {
            get
            {
                return _Checkbox_PortB_Pin5;
            }

            set
            {
                _Checkbox_PortB_Pin5 = value;
                NotifyOfPropertyChange(() => Checkbox_PortB_Pin5);
                if (Checkbox_PortB_Pin5)
                {
                    ramViewModel.setBit(0, 6, 5, 1);
                }
                else if (!Checkbox_PortB_Pin5)
                {
                    ramViewModel.setBit(0, 6, 5, 0);
                }
                sfrData.DataGrid_SFRView.ElementAt(3).Column_HEX = ramViewModel.getByte(0, 6).ToString();
            }
        }
        public bool Checkbox_PortB_Pin6
        {
            get
            {
                return _Checkbox_PortB_Pin6;
                

            }

            set
            {
                _Checkbox_PortB_Pin6 = value;
                NotifyOfPropertyChange(() => Checkbox_PortB_Pin6);
                if (Checkbox_PortB_Pin6)
                {
                    ramViewModel.setBit(0, 6, 6, 1);
                }
                else if (!Checkbox_PortB_Pin6)
                {
                    ramViewModel.setBit(0, 6, 6, 0);
                }
                sfrData.DataGrid_SFRView.ElementAt(3).Column_HEX = ramViewModel.getByte(0, 6).ToString();
            }
        }
        public bool Checkbox_PortB_Pin7
        {
            get
            {
                return _Checkbox_PortB_Pin7;
            }

            set
            {
                _Checkbox_PortB_Pin7 = value;
                NotifyOfPropertyChange(() => Checkbox_PortB_Pin7);

                if (Checkbox_PortB_Pin7)
                {
                    ramViewModel.setBit(0, 6, 7, 1);
                }
                else if (!Checkbox_PortB_Pin7)
                {
                    ramViewModel.setBit(0, 6, 7, 0);
                }
                sfrData.DataGrid_SFRView.ElementAt(3).Column_HEX = ramViewModel.getByte(0, 6).ToString();
            }
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
