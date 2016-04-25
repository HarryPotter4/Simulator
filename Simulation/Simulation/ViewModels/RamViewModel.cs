

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
            //_ramArray = new string[16,16];
            //map_List_To_RamArray();


            for (int row = 0; row < 16; row++)
            {   
                DataGrid_RamView.Add(new M_RamRow
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
        
        /*   /// <summary>
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
           */


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
            int mask;
            int value;

            if(bitValue == 1)
            {
                value = getByte(row, column) | Convert.ToInt32(Math.Pow(2, bit));
            }
            else if (bitValue == 0)
            {
                mask = 255 / Convert.ToInt32(Math.Pow(2, bit));
                value = getByte(row,column) & mask;
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
            return -1;
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
/*
        private void map_List_To_RamArray()
        {
            for (int row = 0; row < 16; row++)
            {
                _ramArray[row, 0] = DataGrid_RamView.ElementAt(row).Column_0;
                _ramArray[row, 1] = DataGrid_RamView.ElementAt(row).Column_1;
                _ramArray[row, 2] = DataGrid_RamView.ElementAt(row).Column_2;
                _ramArray[row, 3] = DataGrid_RamView.ElementAt(row).Column_3;
                _ramArray[row, 4] = DataGrid_RamView.ElementAt(row).Column_4;
                _ramArray[row, 5] = DataGrid_RamView.ElementAt(row).Column_5;
                _ramArray[row, 6] = DataGrid_RamView.ElementAt(row).Column_6;
                _ramArray[row, 7] = DataGrid_RamView.ElementAt(row).Column_7;
                _ramArray[row, 8] = DataGrid_RamView.ElementAt(row).Column_8;
                _ramArray[row, 9] = DataGrid_RamView.ElementAt(row).Column_9;
                _ramArray[row, 10] = DataGrid_RamView.ElementAt(row).Column_10;
                _ramArray[row, 11] = DataGrid_RamView.ElementAt(row).Column_11;
                _ramArray[row, 12] = DataGrid_RamView.ElementAt(row).Column_12;
                _ramArray[row, 13] = DataGrid_RamView.ElementAt(row).Column_13;
                _ramArray[row, 14] = DataGrid_RamView.ElementAt(row).Column_14;
                _ramArray[row, 15] = DataGrid_RamView.ElementAt(row).Column_15;
            }
        }
        private string[,] _ramArray;
        public string RamArray
        {
            get
            {
                return _ramArray;
            }

            set
            {
                _ramArray = value;
            }
        }
        */
        public RamViewModel getRamViewModel()
        {
            return this;
        }
    }
}
