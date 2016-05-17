using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Simulation.Model
{
    class L_Parser
    {
        
        public List<M_FileListItem> listItems;
        private string argPC;
        private string argOPcode;
        private string sourceCode;

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

        public L_Parser(string pathName)
        {
            StreamReader file = new StreamReader(pathName);
            listItems = new List<M_FileListItem>();      
            ParseDocument(file);             
        }
        
        private void ParseDocument(StreamReader file)
        {
            string line;
            while (!file.EndOfStream)
            {
                line = file.ReadLine();

                if (isRelevantLine(line))
                {
                    listItems.Add(new M_FileListItem(argPC, argOPcode, sourceCode));                    
                }
            }
        }

        private bool isRelevantLine(string line)
        {
            if (isProgramCounterArg(line) && isOpCode(line) && isSourccode(line))
                return true;
            else
                return false;
        }

        private bool isSourccode(string line)
        {
            sourceCode = "";
            int elementIndex;
            for(elementIndex = 33;  elementIndex < line.Length - 1; elementIndex++)
            {
                sourceCode = sourceCode + line[elementIndex];
                Convert.ToChar(line[elementIndex + 1]);                
            }
            sourceCode = sourceCode + line[elementIndex];

            return true;
        }

        private bool isProgramCounterArg(string line)
        {
            argPC = "";
            for (int element = 0; element < 4; element++)
            {
                char rowElement = isCharConvertable(line[element]);

                if (isHexNumber(rowElement) && isPCArg(element))
                { argPC = argPC + rowElement; }
                else
                {
                 //   MessageBox.Show("Unexpected Problem: Value of I is" + element + "");
                    return false;
                }
            }
            return true;            
        }

        private static char isCharConvertable(char element)
        {
            char rowElement;
            try { rowElement = Convert.ToChar(element); }
            catch (Exception) { throw; }

            return rowElement;
        }

        private static bool isPCArg(int element)
        {
            return element < 4;
        }

        private static bool isHexNumber(char rowElement)
        {
            bool queryForNumbers = (rowElement <= '9' && rowElement >= '0');
            bool queryForLetters = (rowElement <= 'F' && rowElement >= 'A');
            return (queryForNumbers || queryForLetters);
        }

        private bool isOpCode(string line)
        {
            argOPcode = "";
            for (int elementIndex = 5; elementIndex < 9; elementIndex++)
            {
                char rowElement = Convert.ToChar(line[elementIndex]);
                if (isHexNumber(rowElement))
                {argOPcode = argOPcode + rowElement;}
                else
                {
                  //  MessageBox.Show("Unexpected Problem: Value of I is" + elementIndex);
                    return false;
                }
            }
            return true;
        }
    }
}
