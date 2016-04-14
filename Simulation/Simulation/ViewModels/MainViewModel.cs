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
        private string _listView;
        private string _listView_Line;
        private string _listView_ProgramCounter;
        private string _listView_OpCode;
        private string _listView_SourceCode;
        private string _listView_Items

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

        public string ListView_Line
        {
            get
            {
                return _listView_Line;
            }

            set
            {
                _listView_Line = value;
                NotifyOfPropertyChange(() => ListView_Line);
            }
        }
        public string ListView_ProgramCounter
        {
            get
            {
                return _listView_ProgramCounter;
            }

            set
            {
                _listView_ProgramCounter = value;
                NotifyOfPropertyChange(() => ListView_ProgramCounter);
            }
        }
        public string ListView_OpCode
        {
            get
            {
                return _listView_OpCode;
            }

            set
            {
                _listView_OpCode = value;
                NotifyOfPropertyChange(() => ListView_OpCode);
            }
        }
        public string ListView_SourceCode
        {
            get
            {
                return _listView_SourceCode;
            }

            set
            {
                _listView_SourceCode = value;
                NotifyOfPropertyChange(() => ListView_SourceCode);
            }
        }

        public string ListView
        {
            get
            {
                return _listView;
            }

            set
            {
                _listView = value;
                NotifyOfPropertyChange(() => ListView);
            }
        }

        public string ListView_Items
        {
            get
            {
                return _listView_Items;
            }

            set
            {
                _listView_Items = value;
                NotifyOfPropertyChange(() => ListView);
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

         


            foreach(M_FileListItem item in _listItems)
            {       
                MessageBox.Show(item.ProgramCounter + "  " + item.OpCode );
                
            }
            //-- Update view -> list view
        }
              
         
    }
}
