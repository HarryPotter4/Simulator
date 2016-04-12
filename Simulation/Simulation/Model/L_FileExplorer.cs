using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation.Model
{
    class L_FileExplorer
    {
        private OpenFileDialog fileDialog;
        private L_Parser myParser;
        private List<M_FileListItem> listItems;

        internal List<M_FileListItem> ListItems
        {
            get
            {
                return listItems;
            }

            set
            {
                listItems = value;
            }
        }

        public L_FileExplorer()
        {
            fileDialog = new OpenFileDialog();
            InitFileDialog();
            OpenFileExplorer();
        }

        private void OpenFileExplorer()
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {         
                myParser = new L_Parser(fileDialog.FileName);
                this.ListItems = myParser.listItems;
                //TODO: After parsing object listItems is null before it has all objects.
            }
        }

        private void InitFileDialog()
        {
            fileDialog.Filter = "LST files (*.LST)|*.LST";
            fileDialog.FilterIndex = 1;
            fileDialog.DefaultExt = ".LST";
            fileDialog.InitialDirectory = "C:/Users/Marius Becherer/Documents/Rechnertechnik/assembler/Testprogramm";
        }
    }
}
