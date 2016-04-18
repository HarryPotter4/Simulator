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
            operationViewModel.getOperationViewModel();

            OperationCode = new BindableCollection<OperationViewModel> { operationViewModel };
          //  OperationCode = new BindableCollection<OperationViewModel> { new OperationViewModel(_listItems) };
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


    }
}
