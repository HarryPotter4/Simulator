﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation.Model
{
    class M_FileList
    {
        private List<M_FileListItem> listItem;

        public M_FileList()
        {
            listItem = new List<M_FileListItem>();
        }

        /// <summary>
        /// Add argument 1 to object which is about program counter
        /// Add argument 2 to object which is about the operation with parameters.
        /// </summary>

        public void addLine(int index, string arg1, string arg2)
        {
            listItem.Add(new M_FileListItem(arg1,arg2));                   
        }
    }
}
