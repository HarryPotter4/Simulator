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
        private VM_FileHandler loadedFile;
        public List<M_FileListItem> listItems;

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

        public MainViewModel()
        {

        }

        public MainViewModel(List<M_FileListItem> listItems)
        {
            this.listItems = listItems;
        }

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

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = ".LST";
            fileDialog.InitialDirectory = "C:/Users/Marius Becherer/Documents/Rechnertechnik/assembler/Testprogramm";
               
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(fileDialog.FileName);
                loadedFile = new VM_FileHandler(this,fileDialog.FileName);   
                reader.Close();
                //TODO: After parsing object listItems is null before it has all objects.
            }
            int index = 0;

            foreach (M_FileListItem item in listItems)
            {
                MessageBox.Show((index++) + ". Row is:" + item.ToString());                
            }
          

        }
       




    }
}
