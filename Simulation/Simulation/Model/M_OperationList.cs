using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Simulation.Model
{
    class M_OperationList : Screen

    {                
        private bool _Checkbox_IsSelected;
        private string _CheckBox_Breakpoint;
        private string _Text_Line;
        private string _Text_ProgramCounter;
        private string _Text_Operation;
        private string _Text_SourceCode;

        public bool Checkbox_IsSelected
        {
            get
            {
                return _Checkbox_IsSelected;
            }

            set
            {
                _Checkbox_IsSelected = value;
                NotifyOfPropertyChange(() => Checkbox_IsSelected);
                if(Checkbox_IsSelected == true)
                    MessageBox.Show("Hallo Welt");
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
                NotifyOfPropertyChange(() => Text_Line);
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
                NotifyOfPropertyChange(() => Text_ProgramCounter);
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
                NotifyOfPropertyChange(() => Text_Operation);
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
                NotifyOfPropertyChange(() => Text_SourceCode);
            }
        }
        
    }
}
