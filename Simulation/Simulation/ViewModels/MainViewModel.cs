using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.Windows.Forms;


namespace Simulation.ViewModels
{
    class MainViewModel : Caliburn.Micro.Screen
    {
        private string _windowTitle;
        public VM_FileHandler loadedFile;

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
                System.IO.StreamReader sr = new System.IO.StreamReader(fileDialog.FileName);
                loadedFile =new VM_FileHandler(fileDialog.FileName);        

                sr.Close();
            }

            
        }

        


    }
}
