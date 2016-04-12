using Simulation.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Simulation.ViewModels
{

    class VM_FileHandler
    {
        private M_FileList operationList;
        private string argPC;
        private string argOPcode;

        public VM_FileHandler(string pathName)
        {
            StreamReader file = new StreamReader(pathName);
            operationList = new M_FileList();
            ParseDocument(file);

        }

        private void ParseDocument(StreamReader file)
        {
            int index = 0;
            while (!file.EndOfStream)
            {
                string line = file.ReadLine();

                if (isOpCodeLine(line))
                {
                    operationList.addLine(index, argPC, argOPcode);
                    index++;
                }
            }
        }

        private bool isOpCodeLine(string line)
        {
            argPC = "";
            for (int element = 0; element < 5; element++)
            {
                char rowElement;

                try { rowElement = Convert.ToChar(line[element]); }
                catch (Exception) { throw; }

                bool queryForNumbers = (rowElement <= '9' && rowElement >= '0');
                bool queryForLetters = (rowElement <= 'F' && rowElement >= 'A');
                bool queryForWhiteSpace = (rowElement == ' ' && element == 4);

                if (isHexNumber(queryForNumbers, queryForLetters) || queryForWhiteSpace)
                {
                    bool isPCElement = element < 4;

                    if (isPCElement)
                        argPC = argPC + rowElement;
                    else if (queryForWhiteSpace)
                        return parseOperationCode(line);
                    else
                        MessageBox.Show("Unexpected Problem: Value of I is" + element + "");
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private static bool isHexNumber(bool queryForNumbers, bool queryForLetters)
        {
            return (queryForNumbers || queryForLetters);
        }

        private bool parseOperationCode(string line)
        {
            if (isParseOpSuccessful(line))
                return true;
            else
                return false;
        }

        private bool isParseOpSuccessful(string line)
        {
            argOPcode = "";

            for (int elementIndex = 5; elementIndex < 9; elementIndex++)
            {
                char charValue = Convert.ToChar(line[elementIndex]);
                bool queryForNumbers = (charValue <= '9' && charValue >= '0');
                bool queryForLetters = (charValue <= 'F' && charValue >= 'A');
                bool isInOpCodeArea = (elementIndex > 4 && elementIndex < 9);
                bool isLineFinished = elementIndex == 8;
                bool isOpCode = elementIndex > 4 && elementIndex < 9;

                if (isHexNumber(queryForNumbers, queryForLetters) && isInOpCodeArea)
                {                   
                    if (isOpCode)
                        argOPcode = argOPcode + charValue;
                    else if (isLineFinished)
                        return true;                    
                    else
                        MessageBox.Show("Unexpected Problem: Value of I is" + elementIndex);                    
                }
                else
                    return false;                                
            }
            return false;
        }
    }
}
