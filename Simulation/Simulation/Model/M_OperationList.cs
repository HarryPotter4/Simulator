﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Model
{
    class M_OperationList : Screen

    {
        public M_OperationList()
        {

        }
        
        private bool _CheckboxIsSelected;
        private string _CheckBox_Breakpoint;
        private string _Text_Line;
        private string _Text_ProgramCounter;
        private string _Text_Operation;
        private string _Text_SourceCode;

        public bool CheckboxIsSelected
        {
            get
            {
                return _CheckboxIsSelected;
            }

            set
            {
                _CheckboxIsSelected = value;
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
                NotifyOfPropertyChange(() =>  CheckBox_Breakpoint);
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
            }
        }
        
    }
}
