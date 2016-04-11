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

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(fileDialog.FileName);

                //TODO: Export File to TextBlock
                



                MessageBox.Show(sr.ReadToEnd());
                sr.Close();
            }

            
        }

        


    }
}
