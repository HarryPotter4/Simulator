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
using System.Threading;

namespace Simulation.ViewModels
{
    class MainViewModel : Caliburn.Micro.Screen
    {
        private L_FileExplorer _fileOpen;
        private List<M_FileListItem> _listItems;
        private M_ProgramExecution programExecution;

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
        
        public RamViewModel RamView
        {
            get
            {
                return _RamViewObject;
            }

            set
            {
                _RamViewObject = value;
                NotifyOfPropertyChange(() => RamView);
            }
        }
        public OperationViewModel OperationView
        {
            get
            {
                return _OperationViewModel;
            }

            set
            {
                _OperationViewModel = value;
                NotifyOfPropertyChange(() => OperationView);
            }
        }
        public IOPinsViewModel IOPinsView
        {
            get
            {
                return _IOPinsView;
            }

            set
            {
                _IOPinsView = value;
                NotifyOfPropertyChange(() => IOPinsView);
            }
        }
        public SfrViewModel SFRView
        {
            get
            {
                return _SFRView;
            }

            set
            {
                _SFRView = value;
                NotifyOfPropertyChange(() => SFRView);
            }
        }
             

        public void btn_play()
        {
            Debug.WriteLine("Button läuft!");
            programExecution = new M_ProgramExecution(_listItems, RamView, OperationView, null);
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

            OperationView = new OperationViewModel(_listItems);
            OperationView = OperationView.getOperationViewModel();


            RamView = new RamViewModel();
            RamView = RamView.getRamViewModel();

            SFRView = new SfrViewModel();
            SFRView = SFRView.getSfrViewModel();


            IOPinsView = new IOPinsViewModel(RamView);
            IOPinsView = IOPinsView.getiopinsviewmodel();
        }

        private RamViewModel _RamViewObject;
        private OperationViewModel _OperationViewModel;

        private SfrViewModel _SFRView;
        private IOPinsViewModel _IOPinsView;     

    }
}
