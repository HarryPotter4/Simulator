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
        private byte[,] ramArray;

        public RamViewModel()
        {
            _dataGrid_RamView = new BindableCollection<M_RamRow>();
            ramArray = new byte[16, 16];
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
            switch (column)
            {
                case 0:
                    _dataGrid_RamView.ElementAt(row).Column_0 = value.ToString();
                    break;
                case 1:
                    _dataGrid_RamView.ElementAt(row).Column_1 = value.ToString();
                    break;
                case 2:
                    _dataGrid_RamView.ElementAt(row).Column_2 = value.ToString();
                    break;
                case 3:
                    _dataGrid_RamView.ElementAt(row).Column_3 = value.ToString();
                    break;
                case 4:
                    _dataGrid_RamView.ElementAt(row).Column_4 = value.ToString();
                    break;
                case 5:
                    _dataGrid_RamView.ElementAt(row).Column_5 = value.ToString();
                    break;
                case 6:
                    _dataGrid_RamView.ElementAt(row).Column_6 = value.ToString();
                    break;
                case 7:
                    _dataGrid_RamView.ElementAt(row).Column_7 = value.ToString();
                    break;
                case 8:
                    _dataGrid_RamView.ElementAt(row).Column_8 = value.ToString();
                    break;
                case 9:
                    _dataGrid_RamView.ElementAt(row).Column_9 = value.ToString();
                    break;
                case 10:
                    _dataGrid_RamView.ElementAt(row).Column_10 = value.ToString();
                    break;
                case 11:
                    _dataGrid_RamView.ElementAt(row).Column_11 = value.ToString();
                    break;
                case 12:
                    _dataGrid_RamView.ElementAt(row).Column_12 = value.ToString();
                    break;
                case 13:
                    _dataGrid_RamView.ElementAt(row).Column_13 = value.ToString();
                    break;
                case 14:
                    _dataGrid_RamView.ElementAt(row).Column_14 = value.ToString();
                    break;
                case 15:
                    _dataGrid_RamView.ElementAt(row).Column_15 = value.ToString();
                    break;

                default:
                    Console.WriteLine("Wrong Parameter " + column);
                    break;
            }
                    
        }
        /// <summary>
        /// Attention! It starts with Column = 0 and not with Column = 1!!
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public byte getByte(int row, int column)
        {
            switch (column)
            {
                case 0:
                    return Convert.ToByte(_dataGrid_RamView.ElementAt(row).Column_0); break;
                case 1:
                    return Convert.ToByte(_dataGrid_RamView.ElementAt(row).Column_1); break;
                case 2:
                    return Convert.ToByte(_dataGrid_RamView.ElementAt(row).Column_2); break;
                case 3:
                    return Convert.ToByte(_dataGrid_RamView.ElementAt(row).Column_3); break;
                case 4:
                    return Convert.ToByte(_dataGrid_RamView.ElementAt(row).Column_4); break;
                case 5:
                    return Convert.ToByte(_dataGrid_RamView.ElementAt(row).Column_5); break;
                case 6:
                    return Convert.ToByte(_dataGrid_RamView.ElementAt(row).Column_6); break;
                case 7:
                    return Convert.ToByte(_dataGrid_RamView.ElementAt(row).Column_7); break;
                case 8:
                    return Convert.ToByte(_dataGrid_RamView.ElementAt(row).Column_8); break;
                case 9:
                    return Convert.ToByte(_dataGrid_RamView.ElementAt(row).Column_9); break;
                case 10:
                    return Convert.ToByte(_dataGrid_RamView.ElementAt(row).Column_10); break;
                case 11:
                    return Convert.ToByte(_dataGrid_RamView.ElementAt(row).Column_11); break;
                case 12:
                    return Convert.ToByte(_dataGrid_RamView.ElementAt(row).Column_12); break;
                case 13:
                    return Convert.ToByte(_dataGrid_RamView.ElementAt(row).Column_13); break;
                case 14:
                    return Convert.ToByte(_dataGrid_RamView.ElementAt(row).Column_14); break;
                case 15:
                    return Convert.ToByte(_dataGrid_RamView.ElementAt(row).Column_15); break;
                default:
                    Console.WriteLine("Wrong Parameter " + column);
                    break;
            }
                    return (byte) 0;
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
