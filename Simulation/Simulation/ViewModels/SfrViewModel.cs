using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.Model;

namespace Simulation.ViewModels
{
    class SfrViewModel : Screen
    {
        private string[] sfrNames = {"TRIS A","PORT A","TRIS B","PORT B","STATUS","OPTION","INTCON","W_Reg","FSR","PCL","PC LATH"};
        

        public SfrViewModel()
        {
            DataGrid_SFRView = new BindableCollection<M_SFRrow>();
            

            initalizeView();
        }

        private void initalizeView()
        {
            for (int index = 0; index < sfrNames.Length; index++)
            {
                DataGrid_SFRView.Add(new M_SFRrow()
                {
                    Column_Description = sfrNames[index],                    
                    Column_HEX = "0"
                });
            }
        }

        internal SfrViewModel getSfrViewModel()
        {
            return this;
        }

        private IObservableCollection<M_SFRrow> _DataGrid_SFRView;
        public IObservableCollection<M_SFRrow> DataGrid_SFRView
        {
            get
            {
                return _DataGrid_SFRView;
            }

            set
            {
                _DataGrid_SFRView = value;
                NotifyOfPropertyChange(() => DataGrid_SFRView);
            }
        }
    }
}
