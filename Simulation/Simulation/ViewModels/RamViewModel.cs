

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
            DataGrid_RamView = new BindableCollection<M_RamRow>();    
            initializeFields();
        }

        private SfrViewModel _SfrView;

        public RamViewModel(SfrViewModel sFRView)
        {
            DataGrid_RamView = new BindableCollection<M_RamRow>();
            this.SfrView = sFRView;
            initializeFields();
        }

        public void initializeFields()
        {
            for (int row = 0; row < 16; row++)
            {
                RowHeaderValue = row.ToString();

                DataGrid_RamView.Add(new M_RamRow
                {

                    Column_Description = row.ToString(),
                    Column_0 = "0",
                    Column_1 = "0",
                    Column_2 = "0",
                    Column_3 = "0",
                    Column_4 = "0",
                    Column_5 = "0",
                    Column_6 = "0",
                    Column_7 = "0",
                    Column_8 = "0",
                    Column_9 = "0",
                    Column_10 = "0",
                    Column_11 = "0",
                    Column_12 = "0",
                    Column_13 = "0",
                    Column_14 = "0",
                    Column_15 = "0",
                });
            }
        }

        private string _RowHeaderValue;
        private int _W_Register;

        public void setByte(int row, int column, int value)
        {
            value = value & 255;


            switch (column)
            {
                case 0: DataGrid_RamView.ElementAt(row).Column_0 = value.ToString(); break;
                case 1: DataGrid_RamView.ElementAt(row).Column_1 = value.ToString(); break;
                case 2: DataGrid_RamView.ElementAt(row).Column_2 = value.ToString(); break;
                case 3: DataGrid_RamView.ElementAt(row).Column_3 = value.ToString(); break;
                case 4: DataGrid_RamView.ElementAt(row).Column_4 = value.ToString(); break;
                case 5: DataGrid_RamView.ElementAt(row).Column_5 = value.ToString(); break;
                case 6: DataGrid_RamView.ElementAt(row).Column_6 = value.ToString(); break;
                case 7: DataGrid_RamView.ElementAt(row).Column_7 = value.ToString(); break;
                case 8: DataGrid_RamView.ElementAt(row).Column_8 = value.ToString(); break;
                case 9: DataGrid_RamView.ElementAt(row).Column_9 = value.ToString(); break;
                case 10: DataGrid_RamView.ElementAt(row).Column_10 = value.ToString(); break;
                case 11: DataGrid_RamView.ElementAt(row).Column_11 = value.ToString(); break;
                case 12: DataGrid_RamView.ElementAt(row).Column_12 = value.ToString(); break;
                case 13: DataGrid_RamView.ElementAt(row).Column_13 = value.ToString(); break;
                case 14: DataGrid_RamView.ElementAt(row).Column_14 = value.ToString(); break;
                case 15: DataGrid_RamView.ElementAt(row).Column_15 = value.ToString(); break;
                default: Console.WriteLine("Error in getByte()"); break;
            }
        }
        public int getByte(int row, int column)
        {
            switch (column)
            {
                case 0: return Convert.ToByte(DataGrid_RamView.ElementAt(row).Column_0);
                case 1: return Convert.ToByte(DataGrid_RamView.ElementAt(row).Column_1);
                case 2: return Convert.ToByte(DataGrid_RamView.ElementAt(row).Column_2);
                case 3: return Convert.ToByte(DataGrid_RamView.ElementAt(row).Column_3);
                case 4: return Convert.ToByte(DataGrid_RamView.ElementAt(row).Column_4);
                case 5: return Convert.ToByte(DataGrid_RamView.ElementAt(row).Column_5);
                case 6: return Convert.ToByte(DataGrid_RamView.ElementAt(row).Column_6);
                case 7: return Convert.ToByte(DataGrid_RamView.ElementAt(row).Column_7);
                case 8: return Convert.ToByte(DataGrid_RamView.ElementAt(row).Column_8);
                case 9: return Convert.ToByte(DataGrid_RamView.ElementAt(row).Column_9);
                case 10: return Convert.ToByte(DataGrid_RamView.ElementAt(row).Column_10);
                case 11: return Convert.ToByte(DataGrid_RamView.ElementAt(row).Column_11);
                case 12: return Convert.ToByte(DataGrid_RamView.ElementAt(row).Column_12);
                case 13: return Convert.ToByte(DataGrid_RamView.ElementAt(row).Column_13);
                case 14: return Convert.ToByte(DataGrid_RamView.ElementAt(row).Column_14);
                case 15: return Convert.ToByte(DataGrid_RamView.ElementAt(row).Column_15);
                default:
                    Console.WriteLine("Error in getByte()");
                    return 0;
            }            
        }

        public void setBit(int row,int column, int bit, int bitValue)
        {            
            int value;

            if(bitValue == 1)
            {
                value = getByte(row, column) | Convert.ToInt32(Math.Pow(2, bit));
            }
            else if (bitValue == 0)
            {
                 
                value = getByte(row,column) ^ Convert.ToInt32(Math.Pow(2, bit)); 
            }
            else
            {
                throw new NotImplementedException();
            }


            
            

            switch (column)
            {
                case 0: DataGrid_RamView.ElementAt(row).Column_0 = value.ToString(); break;
                case 1: DataGrid_RamView.ElementAt(row).Column_1 = value.ToString(); break;
                case 2: DataGrid_RamView.ElementAt(row).Column_2 = value.ToString(); break;
                case 3: DataGrid_RamView.ElementAt(row).Column_3 = value.ToString(); break;
                case 4: DataGrid_RamView.ElementAt(row).Column_4 = value.ToString(); break;
                case 5: DataGrid_RamView.ElementAt(row).Column_5 = value.ToString(); break;
                case 6: DataGrid_RamView.ElementAt(row).Column_6 = value.ToString(); break;
                case 7: DataGrid_RamView.ElementAt(row).Column_7 = value.ToString(); break;
                case 8: DataGrid_RamView.ElementAt(row).Column_8 = value.ToString(); break;
                case 9: DataGrid_RamView.ElementAt(row).Column_9 = value.ToString(); break;
                case 10: DataGrid_RamView.ElementAt(row).Column_10 = value.ToString(); break;
                case 11: DataGrid_RamView.ElementAt(row).Column_11 = value.ToString(); break;
                case 12: DataGrid_RamView.ElementAt(row).Column_12 = value.ToString(); break;
                case 13: DataGrid_RamView.ElementAt(row).Column_13 = value.ToString(); break;
                case 14: DataGrid_RamView.ElementAt(row).Column_14 = value.ToString(); break;
                case 15: DataGrid_RamView.ElementAt(row).Column_15 = value.ToString(); break;
                default: Console.WriteLine("Error in getByte()"); break;
            }

        }
        public int getBit(int row, int column, int bit)
        {
            int byteValue = getByte(row, column);

            int result = Convert.ToInt32(Math.Pow(2, bit));
            result = byteValue & result;
            if (result > 0)
                return 1;
            else if (result == 0)
                return 0;
            else
                throw new NotFiniteNumberException();
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

        public string RowHeaderValue
        {
            get
            {
                return _RowHeaderValue;
            }

            set
            {
                _RowHeaderValue = value;
                NotifyOfPropertyChange(() => RowHeaderValue);
            }
        }

        public int W_Register
        {
            get
            {
                return _W_Register;
            }

            set
            {
                _W_Register = value;
            }
        }

        internal SfrViewModel SfrView
        {
            get
            {
                return _SfrView;
            }

            set
            {
                _SfrView = value;
            }
        }

        public RamViewModel getRamViewModel()
        {
            return this;
        }
    }
}
