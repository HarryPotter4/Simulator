using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Simulation.Model;

namespace Simulation.ViewModels
{
    class StackViewModel: Screen
    {
        private string[] stack = { "", "0007", "0006", "0005", "0004", "0003", "0002", "0001", "0000" };

        public StackViewModel()
        {
            DataGrid_StackView = new BindableCollection<M_Stack>();
            intializeView();
        }

        private void intializeView()
        {
            for (int index = 0; index < stack.Length; index++)
            {
                DataGrid_StackView.Add(new M_Stack()
                {
                    Column_Stacknumber = stack[index],
                    Column_Value = "0"
                });
            }
        }

        private IObservableCollection<M_Stack> _DataGrid_StackView;
        private string _Column_Stacknumber;
        private string _Column_Value;

        public IObservableCollection<M_Stack> DataGrid_StackView
        {
            get
            {
                return _DataGrid_StackView;
            }

            set
            {
                _DataGrid_StackView = value;
                NotifyOfPropertyChange(() => DataGrid_StackView);
            }
        }
        public string Column_Stacknumber
        {
            get
            {
                return _Column_Stacknumber;
            }

            set
            {
                _Column_Stacknumber = value;
                NotifyOfPropertyChange(() => Column_Stacknumber);
            }
        }
        public string Column_Value
        {
            get
            {
                return _Column_Value;
            }

            set
            {
                _Column_Value = value;
                NotifyOfPropertyChange(() => Column_Value);
            }
        }

        public StackViewModel getStackViewModel()
        {
            return this;
        }
    }
}
