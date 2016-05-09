using Caliburn.Micro;
using Simulation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation.ViewModels
{
    class OperationViewModel : Caliburn.Micro.Screen
    {
        private List<M_FileListItem> _listItems;
        
        public OperationViewModel(List<M_FileListItem> _listItems)
        {
            this._listItems = _listItems;
            DataGrid_Operation = new BindableCollection<M_OperationList>();

            initOperationView();
        }

        private void initOperationView()
        {
            int line = 0;

            foreach (M_FileListItem item in _listItems)
            {
                DataGrid_Operation.Add(new M_OperationList
                {
                    Checkbox_IsSelected = false,
                    Text_Line = (line++).ToString(),
                    Text_Operation = item.OpCode,
                    Text_SourceCode = item.SourceCode,
                    Text_ProgramCounter = item.ProgramCounter
                });
            }

            SelectItem = DataGrid_Operation.ElementAt(0);
        }

        private IObservableCollection<M_OperationList> _dataGrid_Operation;
        public IObservableCollection<M_OperationList> DataGrid_Operation
        {
            get
            {
                return _dataGrid_Operation;
            }
            set
            {
                _dataGrid_Operation = value;
                NotifyOfPropertyChange(() => DataGrid_Operation);
            }
        }

        private M_OperationList _SelectItem;
        public M_OperationList SelectItem
        {
            get
            {
                return _SelectItem;
            }

            set
            {
                _SelectItem = value;
                NotifyOfPropertyChange(() => SelectItem);
            }
        }

        public OperationViewModel getOperationViewModel()
        {
            return this;
        }
        public IObservableCollection<M_OperationList> getOperationsList()
        {
            return DataGrid_Operation;
        }
  
        public void nextLine(int programCounter)
        {
            SelectItem = DataGrid_Operation.ElementAt(programCounter);                        
        } 
    }   
}
