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
            int index = 0;
            while (!file.EndOfStream)
            {
                string line = file.ReadLine();
               
                if(isUsedLine(line))
                {
                    operationList.addLine(index,argPC, argOPcode);
                   // MessageBox.Show(argPC + " " + argOPcode);
                   index++;
                }
            }


        }

        private bool isUsedLine(string line)
        {
            argPC = "";
            for (int index = 0; index < 5; index++)
            {
                try
                {
                    char charValue = Convert.ToChar(line[index]);
                    bool queryForNumbers = (charValue <= '9' && charValue >= '0');
                    bool queryForLetters = (charValue <= 'F' && charValue >= 'A');
                    bool queryForWhiteSpace = (charValue == ' ' && index ==4);

                    if ((queryForNumbers || queryForLetters) || queryForWhiteSpace)
                    {
                        if (index < 4)
                            argPC = argPC + charValue;

                        else if (index == 4 && charValue == ' ')
                        {
                            return isSuccessful(line);
                        }
                        else
                        {
                            MessageBox.Show("Unexpected Problem: Value of I is" + index + "");
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return true;
        }

        private bool isSuccessful(string line)
        {
            if (setOPcode(line))
                return true;
            else
                return false;
        }

        private bool setOPcode(string line)
        {
            argOPcode = "";

            for (int i = 5; i < 9; i++)
            {
                char charValue = Convert.ToChar(line[i]);
                bool queryForNumbers = (charValue <= '9' && charValue >= '0');
                bool queryForLetters = (charValue <= 'F' && charValue >= 'A');
                bool isInOpCodeArea = (i > 4 && i < 9);

                if ((queryForNumbers || queryForLetters) && isInOpCodeArea)
                {
                    if (i > 4 && i < 9)
                    {
                        argOPcode = argOPcode + charValue;
                    }
                    else if (i == 8)
                    {
                        MessageBox.Show("Ende erreicht");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Unexpected Problem: Value of I is" + i);
                    }
                    //MessageBox.Show("Das " + i + ". Zeichen ist:" + charValue);
                }
                else
                {
                    return false;
                }                
            }
            return true;
        }
    }
}
