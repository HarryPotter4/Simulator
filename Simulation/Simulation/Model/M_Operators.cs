using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.ViewModels;

namespace Simulation.Model

    
{
    class M_Operators
    {
        public M_Operators(RamViewModel ramViewModel)
        {
            this.ramViewModel = ramViewModel;
        }

        private RamViewModel ramViewModel;

        int wReg = 0;       // vorübergehend
        int fileReg = 0;    // vorübergehend
        int OPCODE;         // hier kommt der Opcode von Marius
        int destinationBit = 0;

        public const int destiMask = 0x0080; // constant destination bit mask

        

        public int getDestinationBit(int opcode)
        {
            destinationBit = destiMask & opcode;
            return destinationBit;
        }

   
        

        public void addWf(int opcode)
        {
            int addWfMask = 0x0780;
            int argument = mask & opcode;
            if (destinationBit==0x0080)
                {
                    
                    fileReg = wReg + fileReg;
                }
             else{
                wReg = wReg + fileReg;
            }               



        }

        public void andWf(int argument)
        {
            int andWfMask = 0; // TODO
            argument = fileReg;
            if(0==destinationBit)
            {
                fileReg = wReg && fileReg;     
            }
            else
            {
                wReg = wReg && fileReg;
            }
        }

        public void clearF(int argument)
        {
            
            argument = fileReg;
            fileReg = 0;
        }

        public void clearW()
        {
            wReg = 0;
        }

        public void compF(int argument)
        {
            argument = fileReg;
            fileReg=~fileReg;
        }

        internal void subwf(int destinationsBit, int fileRegister)
        {
            throw new NotImplementedException();
        }

        internal void decf(int destinationsBit, int fileRegister)
        {
            throw new NotImplementedException();
        }

        internal void iOrWf(int destinationsBit, int fileRegister)
        {
            throw new NotImplementedException();
        }
    }
}
