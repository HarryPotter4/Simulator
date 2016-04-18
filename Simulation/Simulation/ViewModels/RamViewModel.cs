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
        private string[,] _ramArray;

        public RamViewModel()
        {
            _dataGrid_RamView = new BindableCollection<M_RamRow>();
            _ramArray = new string[16, 16];
            map_List_To_RamArray();


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

        private void map_List_To_RamArray()
        {
            for(int row=0; row < 16; row++)
            {                
                _ramArray[row, 0] = _dataGrid_RamView.ElementAt(row).Column_0;
                _ramArray[row, 1] = _dataGrid_RamView.ElementAt(row).Column_1;
                _ramArray[row, 2] = _dataGrid_RamView.ElementAt(row).Column_2;
                _ramArray[row, 3] = _dataGrid_RamView.ElementAt(row).Column_3;
                _ramArray[row, 4] = _dataGrid_RamView.ElementAt(row).Column_4;
                _ramArray[row, 5] = _dataGrid_RamView.ElementAt(row).Column_5;
                _ramArray[row, 6] = _dataGrid_RamView.ElementAt(row).Column_6;
                _ramArray[row, 7] = _dataGrid_RamView.ElementAt(row).Column_7;
                _ramArray[row, 8] = _dataGrid_RamView.ElementAt(row).Column_8;
                _ramArray[row, 9] = _dataGrid_RamView.ElementAt(row).Column_9;
                _ramArray[row, 10] = _dataGrid_RamView.ElementAt(row).Column_10;
                _ramArray[row, 11] = _dataGrid_RamView.ElementAt(row).Column_11;
                _ramArray[row, 12] = _dataGrid_RamView.ElementAt(row).Column_12;
                _ramArray[row, 13] = _dataGrid_RamView.ElementAt(row).Column_13;
                _ramArray[row, 14] = _dataGrid_RamView.ElementAt(row).Column_14;
                _ramArray[row, 15] = _dataGrid_RamView.ElementAt(row).Column_15;
            }
        }

        /// <summary>
        /// Set Byte in Ram! Column and Row starts with 0!
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        public void setByte(int row, int column , byte value)
        {
            RamArray[row, column] = value.ToString();                    
        }
        /// <summary>
        /// Attention! It starts with Column = 0 and not with Column = 1!!
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public byte getByte(int row, int column)
        {
            return Convert.ToByte(RamArray[row,column]);
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

        public string[,] RamArray
        {
            get
            {
                return _ramArray;
            }

            set
            {
                _ramArray = value;
                NotifyOfPropertyChange(() => RamArray);
            }
        }        
        public RamViewModel getRamViewModel()
        {
            return this;
        }


    }
}
