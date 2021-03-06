﻿using Caliburn.Micro;
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
        private int index = 0;

        public OperationViewModel(List<M_FileListItem> _listItems)
        {
            this._listItems = _listItems;

            _dataGrid_Operation = new BindableCollection<M_OperationList>();
            int line = 0;

            foreach (M_FileListItem item in _listItems)
            {                 
                _dataGrid_Operation.Add(new M_OperationList
                {
                    CheckBox_Breakpoint = "",
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
            return _dataGrid_Operation;
        }

  
        public void nextLine(int programCounter)
        {
            SelectItem = DataGrid_Operation.ElementAt(programCounter);                        
        }        


        /*
                public bool CheckboxIsSelected
                {
                    get
                    {
                        return _CheckboxIsSelected;
                    }

                    set
                    {
                        _CheckboxIsSelected = value;
                        NotifyOfPropertyChange(() => value);
                    }
                }
                public string CheckBox_Breakpoint
                {
                    get
                    {
                        return _CheckBox_Breakpoint;
                    }

                    set
                    {
                        _CheckBox_Breakpoint = value;
                        NotifyOfPropertyChange(() => value);
                    }
                }
                public string Text_Line
                {
                    get
                    {
                        return _Text_Line;
                    }

                    set
                    {
                        _Text_Line = value;
                        NotifyOfPropertyChange(() => value);
                    }
                }
                public string Text_ProgramCounter
                {
                    get
                    {
                        return _Text_ProgramCounter;
                    }

                    set
                    {
                        _Text_ProgramCounter = value;
                        NotifyOfPropertyChange(() => value);
                    }
                }
                public string Text_Operation
                {
                    get
                    {
                        return _Text_Operation;
                    }

                    set
                    {
                        _Text_Operation = value;
                        NotifyOfPropertyChange(() => value);
                    }
                }
                public string Text_SourceCode
                {
                    get
                    {
                        return _Text_SourceCode;
                    }

                    set
                    {
                        _Text_SourceCode = value;
                        NotifyOfPropertyChange(() => value);
                    }
                }

                private bool _CheckboxIsSelected;
                private string _CheckBox_Breakpoint;
                private string _Text_Line;
                private string _Text_ProgramCounter;
                private string _Text_Operation;
                private string _Text_SourceCode;

             */
    }   
}
