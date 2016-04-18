using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.Windows.Forms;
using Simulation.Views;
using Simulation.Model;

namespace Simulation.ViewModels
{
    class MainViewModel : Caliburn.Micro.Screen
    {
        private L_FileExplorer _fileOpen;
        private List<M_FileListItem> _listItems;
        private OperationViewModel operationViewModel;
        private RamViewModel ramViewModel;
        private SfrViewModel sfrViewModel;
        

        private string _windowTitle;
        public string Windowtitle
        {
            get
            {
                return _windowTitle;
            }

            set
            {
                _windowTitle = value;
                NotifyOfPropertyChange(() => Windowtitle);
            }
        }

        private string _Listview_programStepper;
        public string Listview_programStepper
        {
            get{ return _Listview_programStepper; }
            set{ _Listview_programStepper = value;
                NotifyOfPropertyChange(() => Windowtitle);
            }
        }   

      
        public void btn_play()
        {
            Debug.WriteLine("Button läuft!");

        }
        public void btn_next()
        {
            Debug.WriteLine("Button läuft!");
        }
        public void btn_pause()
        {
            Debug.WriteLine("Button läuft!");
        }
        public void btn_back()
        {
            Debug.WriteLine("Button läuft!");
            
        }
        public void menuItem_Open()
        {
            Debug.WriteLine("Open läuft!");
            _fileOpen = new L_FileExplorer();
            _listItems = _fileOpen.ListItems;

            operationViewModel = new OperationViewModel(_listItems);
            operationViewModel = operationViewModel.getOperationViewModel();

            OperationCode = new BindableCollection<OperationViewModel> { operationViewModel };
            //  OperationCode = new BindableCollection<OperationViewModel> { new OperationViewModel(_listItems) };

            ramViewModel = new RamViewModel();
            ramViewModel = ramViewModel.getRamViewModel();
            RamDisplay = new BindableCollection<RamViewModel> { ramViewModel };

            sfrViewModel = new SfrViewModel();
            sfrViewModel = sfrViewModel.getsfrViewModel();
            SFRDisplay = new BindableCollection<SfrViewModel> { sfrViewModel };
        }

        private BindableCollection<OperationViewModel> _operationCode;
        public BindableCollection<OperationViewModel> OperationCode
        {
            get
            {
                return _operationCode;
            }

            set
            {
                _operationCode = value;
                NotifyOfPropertyChange(() => OperationCode);
            }
        }

        private BindableCollection<RamViewModel> _ramDisplay;
        public BindableCollection<RamViewModel> RamDisplay
        {
            get
            {
                return _ramDisplay;
            }

            set
            {
                _ramDisplay = value;
                NotifyOfPropertyChange(() => RamDisplay);
            }
        }

        public BindableCollection<SfrViewModel> SFRDisplay
        {
            get
            {
                return _sFRDisplay;
            }

            set
            {
                _sFRDisplay = value;
                NotifyOfPropertyChange(() => SFRDisplay);
            }
        }  
        private BindableCollection<SfrViewModel> _sFRDisplay;

        
    }
}
