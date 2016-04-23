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
        private int _W_Register;

        /// <summary>
        /// Bank 0 SFR
        /// </summary>
        private int _TMR0;
        private int _PCL;
        private int _STATUS;
        private int _FSR;
        private int _PORTA;
        private int _PORTB;
        private int _EEDATA;
        private int _EEADR;
        private int _PCLATH;
        private int _INTCON;
        /// <summary>
        /// Bank 1 SFR 
        /// </summary>    
        private int _OPTION_REGISTER;
        private int _TRISA;
        private int _TRISB;
        private int _EECON1;
        private int _EECON2;


        public M_Operators(RamViewModel ramViewModel)
        {
            this.ramViewModel = ramViewModel;
            
        }

        private RamViewModel ramViewModel;

        public int W_Register
        {
            get
            {
                return _W_Register;
            }

            set
            {
                _W_Register = value;
            }
        }
        public int TMR0
        {
            get
            {
                return _TMR0;
            }

            set
            {
                _TMR0 = value;
                ramViewModel.setByte(0, 0, TMR0);
                _TMR0 = ramViewModel.getByte(0, 0);
            }
        }
        public int INTCON
        {
            get
            {
                return _INTCON;
            }

            set
            {
                _INTCON = value;
                ramViewModel.setByte(0, 11, _INTCON);                
                ramViewModel.setByte(8, 11, _INTCON);
                _INTCON = ramViewModel.getByte(0, 11);
            }
        }
        public int PCLATH
        {
            get
            {
                return _PCLATH;
            }

            set
            {
                _PCLATH = value;
                ramViewModel.setByte(0, 10, _PCLATH);
                ramViewModel.setByte(0, 10, _PCLATH);
                _PCLATH = ramViewModel.getByte(0, 10);
            }
        }
        public int EEADR
        {
            get
            {
                return _EEADR;
            }

            set
            {
                _EEADR = value;
                ramViewModel.setByte(0, 9, _EEADR);
                _EEADR = ramViewModel.getByte(0, 9);
            }
        }
        public int EEDATA
        {
            get
            {
                return _EEDATA;
            }

            set
            {
                _EEDATA = value;
                ramViewModel.setByte(0, 8, _EEDATA);
                _EEDATA = ramViewModel.getByte(0, 8);
            }
        }
        public int PORTB
        {
            get
            {
                return _PORTB;
            }

            set
            {
                _PORTB = value;
                ramViewModel.setByte(0, 6, _PORTB);
                _PORTB = ramViewModel.getByte(0, 6);
            }
        }
        public int PORTA
        {
            get
            {
                return _PORTA;
            }

            set
            {
                _PORTA = value;
                ramViewModel.setByte(0, 5, _PORTA);
                _PORTA = ramViewModel.getByte(0, 5);
            }
        }
        public int FSR
        {
            get
            {
                return _FSR;
            }

            set
            {
                _FSR = value;
                ramViewModel.setByte(0, 4, _FSR);
                ramViewModel.setByte(8, 4, _FSR);
                _FSR = ramViewModel.getByte(0, 4);
            }
        }
        public int STATUS
        {
            get
            {
                return _STATUS;
            }

            set
            {
                _STATUS = value;
                ramViewModel.setByte(0, 3, _STATUS);
                ramViewModel.setByte(8, 3, _STATUS);
                _STATUS = ramViewModel.getByte(0,3):
            }
        } 
        public int PCL
        {
            get
            {
                return _PCL;
            }

            set
            {
                _PCL = value;
                ramViewModel.setByte(0, 2, _PCL);
                ramViewModel.setByte(8, 2, _PCL);
                _PCL = ramViewModel.setByte(0, 2);
            }
        }
        public int EECON2
        {
            get
            {
                return _EECON2;
            }

            set
            {
                _EECON2 = value;
                ramViewModel.setByte(8, 9, _EECON2);
                _EECON2 = ramViewModel.getByte(8, 9);     
            }
        }
        public int EECON1
        {
            get
            {
                return _EECON1;
            }

            set
            {
                _EECON1 = value;
                ramViewModel.setByte(8, 8, _EECON1);
                _EECON1 = ramViewModel.getByte(8, 8);
            }
        }
        public int TRISB
        {
            get
            {
                return _TRISB;
            }

            set
            {
                _TRISB = value;
                ramViewModel.setByte(8, 6, _TRISB);
                _TRISB = ramViewModel.getByte(8, 6);
            }
        }
        public int TRISA
        {
            get
            {
                return _TRISA;
            }

            set
            {
                _TRISA = value;
                ramViewModel.setByte(8, 5, _TRISA);
                _TRISA = ramViewModel.getByte(8, 5);
            }
        }
        public int OPTION_REGISTER
        {
            get
            {
                return _OPTION_REGISTER;
            }

            set
            {
                _OPTION_REGISTER = value;
                ramViewModel.setByte(8, 1, _OPTION_REGISTER);
                _OPTION_REGISTER = ramViewModel.getByte(8, 1);
            }
        }






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
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;
            
            if ( destinationsBit == 1)
            {                
                ramViewModel.setByte(row, column, ramViewModel.getByte(row, column) - W_Register);
            }
            else if(destinationsBit == 0)
            {
                W_Register = W_Register - ramViewModel.getByte(row, column);
            }
            else
            {
                throw new NotImplementedException();
            }
            
        }

        internal void decf(int destinationsBit, int fileRegister)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;

            ramViewModel.setByte(row, column, ramViewModel.getByte(row, column) - 1);
            
        }

        internal void iOrWf(int destinationsBit, int fileRegister)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;
                       

            if (destinationsBit == 1)
            {
                ramViewModel.setByte(row, column, ramViewModel.getByte(row, column) | W_Register);
            }
            else if (destinationsBit == 0)
            {
                W_Register = W_Register | ramViewModel.getByte(row, column);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        internal void andWf(int destinationsBit, int fileRegister)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;


            if (destinationsBit == 1)
            {
                ramViewModel.setByte(row, column, ramViewModel.getByte(row, column) & W_Register);
            }
            else if (destinationsBit == 0)
            {
                W_Register = W_Register & ramViewModel.getByte(row, column);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        internal void xorWF(int destinationsBit, int fileRegister)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;


            if (destinationsBit == 1)
            {
                ramViewModel.setByte(row, column, ramViewModel.getByte(row, column) ^ W_Register);
            }
            else if (destinationsBit == 0)
            {
                W_Register = W_Register ^ ramViewModel.getByte(row, column);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        internal void addWf(int destinationsBit, int fileRegister)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;


            if (destinationsBit == 1)
            {
                ramViewModel.setByte(row, column, ramViewModel.getByte(row, column) + W_Register);
            }
            else if (destinationsBit == 0)
            {
                W_Register = W_Register + ramViewModel.getByte(row, column);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        internal void movF(int destinationsBit, int fileRegister)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;


            if (destinationsBit == 1)
            {
                ramViewModel.setByte(row, column, ramViewModel.getByte(row, column));
            }
            else if (destinationsBit == 0)
            {
                W_Register = ramViewModel.getByte(row, column);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        internal void compF(int destinationsBit, int fileRegister)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;


            if (destinationsBit == 1)
            {
                ramViewModel.setByte(row, column, ~ ramViewModel.getByte(row, column));
            }
            else if (destinationsBit == 0)
            {
                W_Register = ~ramViewModel.getByte(row, column);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        internal void clearF(int fileRegister)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;

            ramViewModel.setByte(row, column, 0);
        }

        internal void clearW()
        {
            W_Register = 0;
        }

        internal void incF(int destinationsBit, int fileRegister)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;

            ramViewModel.setByte(row, column, ramViewModel.getByte(row, column) + 1);
        }

        internal void decfsz(int destinationsBit, int fileRegister)
        {
            //throw new NotImplementedException();
        }

        internal void rrf(int destinationsBit, int fileRegister)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;


            ramViewModel.setByte(row, column, ramViewModel.getByte(row, column) / 2);
        }

        internal void rlf(int destinationsBit, int fileRegister)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;


            ramViewModel.setByte(row, column, ramViewModel.getByte(row, column) *2);
        }

        internal void swapf(int destinationsBit, int fileRegister)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;

            int temp = ramViewModel.getByte(row, column) / 16;
            int result= (ramViewModel.getByte(row,column) * 16) & temp;


            if (destinationsBit == 1)
            {
                ramViewModel.setByte(row, column, result);
            }
            else if (destinationsBit == 0)
            {
                W_Register = result;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        internal void incfsz(int destinationsBit, int fileRegister)
        {
            //throw new NotImplementedException();
        }

        internal void movWF(int v, int fileRegister)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;

            ramViewModel.setByte(row, column, W_Register);
        }

        internal void nop(int v, int fileRegister)
        {
            
        }

        internal void movLW(int constValue)
        {
            W_Register = constValue;
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
