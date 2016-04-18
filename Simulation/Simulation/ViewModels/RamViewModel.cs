using Caliburn.Micro;
using Simulation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.ViewModels
{
    class RamViewModel : Screen
    {
        public RamViewModel()
        {
            _dataGrid_RamView = new BindableCollection<M_RamRow>();

            for (int row = 0; row < 16; row++)
            {
                _dataGrid_RamView.Add(new M_RamRow
                {
                    Column_Description = row.ToString(),
                    Column_0 = "00",
                    Column_1 = "00",
                    Column_2 = "00",
                    Column_3 = "00",
                    Column_4 = "00",
                    Column_5 = "00",
                    Column_6 = "00",
                    Column_7 = "00",
                    Column_8 = "00",
                    Column_9 = "00",
                    Column_10 = "00",
                    Column_11 = "00",
                    Column_12 = "00",
                    Column_13 = "00",
                    Column_14 = "00",
                    Column_15 = "00",
                });
            }
        }
        

        private IObservableCollection<M_RamRow> _dataGrid_RamView;
        public IObservableCollection<M_RamRow> DataGrid_RamView
        {
            get
            {
                return _dataGrid_RamView;
            }

            set
            {
                _dataGrid_RamView = value;
                NotifyOfPropertyChange(() => DataGrid_RamView);
            }
        }

        public RamViewModel getRamViewModel()
        {
            return this;
        }
    }
}
