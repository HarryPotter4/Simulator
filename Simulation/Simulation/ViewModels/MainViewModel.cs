using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Simulation.ViewModels
{
    class MainViewModel : Screen
    {

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
        }
    }
}
