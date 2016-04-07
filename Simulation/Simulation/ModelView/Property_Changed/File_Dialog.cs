using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Simulation.ModelView
{
    public class File_Dialog : INotifyPropertyChanged
    {
        private File _file;
        public File_Dialog(File file)
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
