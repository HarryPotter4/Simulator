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
        public static IObservableCollection<M_SFRrow> sfrView;

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

        public Thread Thread
        {
            get
            {
                return _Thread;
            }

            set
            {
                _Thread = value;
            }
        }

        public StackViewModel StackView
        {
            get
            {
                return _stackView;
            }

            set
            {
                _stackView = value;
                NotifyOfPropertyChange(() => StackView);
            }
        }

        public QuarzfrequenzViewModel QuarzfrequenzView
        {
            get
            {
                return _quarzView;
            }

            set
            {
                _quarzView = value;
                NotifyOfPropertyChange(() => QuarzfrequenzView);
            }
        }

        public static programStates currentState;     
        public enum programStates {unstarted,execute,busy,wait,oneCycle,finish};

        public void btn_play()
        {
            Debug.WriteLine("Button läuft!");
            

            if(QuarzfrequenzView.CurrentFrequenz != null )
            {
                QuarzfrequenzView.IsEnabled = false;
                currentState = programStates.execute;
                return;
            }
            MessageBox.Show("Select Quarzfrequenz");

        }      
        public void btn_next()
        {
            Debug.WriteLine("Button läuft!");

            if (QuarzfrequenzView.CurrentFrequenz != null)
            {
                QuarzfrequenzView.IsEnabled = false;
                currentState = programStates.oneCycle;
                return;
            }
            MessageBox.Show("Select Quarzfrequenz");
        }
        public void btn_pause()
        {
            Debug.WriteLine("Button läuft!");
            currentState = programStates.wait;
        }
        public void btn_reset()
        {
            Debug.WriteLine("Button läuft!");
            if(programExecution != null)
            {
                Thread = programExecution.getThread();
                Thread.Abort();
            }
                        

            if (OperationView != null)
                programExecution.resetProgrammCounter();
            initializeView();
            
            currentState = programStates.wait;

        }

        public void menuItem_Open()
        {
            Debug.WriteLine("Open läuft!");
            _fileOpen = new L_FileExplorer();
            _listItems = _fileOpen.ListItems;
            if(programExecution != null)
            {
                Thread = programExecution.getThread();
                Thread.Abort();
            }
            initializeView();
        }
        private void initializeView()
        {
            OperationView = new OperationViewModel(_listItems);
            OperationView = OperationView.getOperationViewModel();

            SFRView = new SfrViewModel();
            SFRView = SFRView.getSfrViewModel();
            sfrView = SFRView.DataGrid_SFRView;

            RamView = new RamViewModel(SFRView);
            RamView = RamView.getRamViewModel();            

            IOPinsView = new IOPinsViewModel(RamView,SFRView);
            IOPinsView = IOPinsView.getiopinsviewmodel();

            QuarzfrequenzView = new QuarzfrequenzViewModel();
            QuarzfrequenzView = QuarzfrequenzView.getQuarzFrequenzModel();
            QuarzfrequenzView.IsEnabled = true;

            StackView = new StackViewModel();
            StackView = StackView.getStackViewModel();

            programExecution = new M_ProgramExecution(_listItems, RamView, OperationView,StackView,QuarzfrequenzView);
        }
        private QuarzfrequenzViewModel _quarzView;
        private StackViewModel _stackView;



        private RamViewModel _RamViewObject;
        private OperationViewModel _OperationViewModel;

        private Thread _Thread;


        private SfrViewModel _SFRView;
        private IOPinsViewModel _IOPinsView;     

    }
}
