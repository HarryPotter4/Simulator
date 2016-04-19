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
        int argument = 0;   // HIER hier kristalliere ich das argument herraus. 

        public M_Operators(RamViewModel ramViewModel)
        {
            this.ramViewModel = ramViewModel;
        }

        private RamViewModel ramViewModel;
        /*
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
            int adressA = argument/16;      // hier muss die adresse aus dem argument extrahiert werden
            int adressB = argument;
            if (destinationBit==0x0080)
                {
                    
                    byte value= wReg + (int)ramViewModel.getByte(adressA,adressB);
                Convert.ToInt32(value);
                    ramViewModel.setByte(adressA,adressB,value);
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
            fileReg= ~fileReg;
        }
        */

        internal void subwf(int destinationsBit, int fileRegister)
        {
            // throw new NotImplementedException();
        }

        internal void decf(int destinationsBit, int fileRegister)
        {
            // throw new NotImplementedException();
        }

        internal void iOrWf(int destinationsBit, int fileRegister)
        {
            // throw new NotImplementedException();
        }

        internal void andWf(int destinationsBit, int fileRegister)
        {
            // throw new NotImplementedException();
        }

        internal void xorWF(int destinationsBit, int fileRegister)
        {
            //  throw new NotImplementedException();
        }

        internal void addWf(int destinationsBit, int fileRegister)
        {
            // throw new NotImplementedException();
        }

        internal void movF(int destinationsBit, int fileRegister)
        {
            //  throw new NotImplementedException();
        }

        internal void compF(int destinationsBit, int fileRegister)
        {
            // throw new NotImplementedException();
        }

        internal void clearF(int fileRegister)
        {
            // throw new NotImplementedException();
        }

        internal void clearW()
        {
            //throw new NotImplementedException();
        }

        internal void incF(int destinationsBit, int fileRegister)
        {
            //throw new NotImplementedException();
        }

        internal void decfsz(int destinationsBit, int fileRegister)
        {
            //throw new NotImplementedException();
        }

        internal void rrf(int destinationsBit, int fileRegister)
        {
            //throw new NotImplementedException();
        }

        internal void rlf(int destinationsBit, int fileRegister)
        {
            //throw new NotImplementedException();
        }

        internal void swapf(int destinationsBit, int fileRegister)
        {
            //throw new NotImplementedException();
        }

        internal void incfsz(int destinationsBit, int fileRegister)
        {
            //throw new NotImplementedException();
        }

        internal void movWF(int v, int fileRegister)
        {
            //throw new NotImplementedException();
        }

        internal void nop(int v, int fileRegister)
        {
            //throw new NotImplementedException();
        }

        internal void movLW(int constValue)
        {
            //throw new NotImplementedException();
        }

        internal void goTo(int constValue)
        {
            //throw new NotImplementedException();
        }

        internal void call(int constValue)
        {
            //throw new NotImplementedException();
        }

        internal void retLW(int constValue)
        {
            //throw new NotImplementedException();
        }

        internal void iorLW(int constValue)
        {
            //throw new NotImplementedException();
        }

        internal void andLW(int constValue)
        {
            // throw new NotImplementedException();
        }

        internal void xorLW(int constValue)
        {
            //throw new NotImplementedException();
        }

        internal void subLW(int constValue)
        {
            //throw new NotImplementedException();
        }

        internal void addLW(int constValue)
        {
            //throw new NotImplementedException();
        }

        internal void subwf(int constValue)
        {
            // throw new NotImplementedException();
        }

        internal void bcf(int fileRegister, int selectedBit)
        {
            //throw new NotImplementedException();
        }

        internal void clrwdt()
        {
            //throw new NotImplementedException();
        }

        internal void bsf(int fileRegister, int selectedBit)
        {
            //throw new NotImplementedException();
        }

        internal void retIEF()
        {
            // throw new NotImplementedException();
        }

        internal void btfsc(int fileRegister, int selectedBit)
        {
            // throw new NotImplementedException();
        }

        internal void reTurn()
        {
            //throw new NotImplementedException();
        }

        internal void btfss(int fileRegister, int selectedBit)
        {
            //throw new NotImplementedException();
        }

        internal void sleep()
        {
            //  throw new NotImplementedException();
        }
    }
}
