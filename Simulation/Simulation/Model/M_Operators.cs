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
        private int _W_Register;
        private List<int> stackProgramCounter;
              
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
          
        private int _OPTION_REGISTER;
        private int _TRISA;
        private int _TRISB;
        private int _EECON1;
        private int _EECON2;
       
        
        private int _ProgramCounter;
        private int _CarryBit;
        private int _DigitCarryBit;
        private int _ZeroFlag;
        private int _TimeOutBit;
        private int _PowerDownBit;
        private int _RP0;

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

        internal int getProgramCounter()
        {
            return ProgramCounter;
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
                _STATUS = ramViewModel.getByte(0, 3);
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
                _PCL = ramViewModel.getByte(0, 2);
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
        public int ProgramCounter
        {
            get
            {
                return _ProgramCounter;
            }

            set
            {
                _ProgramCounter = value;
            }
        }
        public int CarryBit
        {
            get
            {
                return _CarryBit;
            }

            set
            {
                _CarryBit = value;
                ramViewModel.setBit(0, 3, 0, _CarryBit);
                ramViewModel.setBit(8, 3, 0, _CarryBit);
            }
        }
        public int DigitCarryBit
        {
            get
            {
                return _DigitCarryBit;
            }

            set
            {
                _DigitCarryBit = value;
                ramViewModel.setBit(0, 3, 1,_DigitCarryBit);
                ramViewModel.setBit(8, 3, 1, _DigitCarryBit);
            }
        }
        public int ZeroFlag
        {
            get
            {
                return _ZeroFlag;
            }

            set
            {
                _ZeroFlag = value;
                ramViewModel.setBit(0, 3, 2, _ZeroFlag);
                ramViewModel.setBit(8, 3, 2, _ZeroFlag);
            }
        }
        public int TimeOutBit
        {
            get
            {
                return _TimeOutBit;
            }

            set
            {
                _TimeOutBit = value;
                ramViewModel.setBit(0, 3, 4, _TimeOutBit);
                ramViewModel.setBit(8, 3, 4, _TimeOutBit);
            }
        }
        public int PowerDownBit
        {
            get
            {
                return _PowerDownBit;
            }

            set
            {
                _PowerDownBit = value;
                ramViewModel.setBit(0, 3, 3, _PowerDownBit);
                ramViewModel.setBit(8, 3, 3, _PowerDownBit);
            }
        }
        public int RP0
        {
            get
            {
                return _RP0;
            }

            set
            {
                _RP0 = value;
                ramViewModel.setBit(0, 3, 5, _RP0);
                ramViewModel.setBit(8, 3, 5, _RP0);
            }
        }


        public M_Operators(RamViewModel ramViewModel)
        {
            this.ramViewModel = ramViewModel;
            stackProgramCounter = new List<int>();
            initRam();
        }

        private void initRam()
        {
            ramViewModel.setByte(0, 3, 24);
            ramViewModel.setByte(8, 1, 255);
            ramViewModel.setByte(8, 3, 24);
            ramViewModel.setByte(8, 5, 32);
            ramViewModel.setByte(8, 6, 255);

        }

        private void isZero(int currentValue, int result)
        {
            if (currentValue > 0 && result == 0)
            {
                ZeroFlag = 1;
            }
        }
        private void isCarryBorrow(int currentValue, int result)
        {
            if (result > 255)
            {
                CarryBit = 1;
            }
        }
        private void isDigitCarryBorrow(int currentValue, int result)
        {
            if (currentValue < 16 && result > 16)
            {
                DigitCarryBit = 1;
            }
        }
        

        internal void subwf(int destinationsBit, int fileRegister)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;            

            int  ramValue = ramViewModel.getByte(row, column);

            int result = ramValue - W_Register;
            
            isZero(ramValue, result);

            if ( destinationsBit == 1)
            {               
                ramViewModel.setByte(row, column, result );
            }
            else if(destinationsBit == 0)
            {
                W_Register =  result;
            }
            else
            {
                throw new NotImplementedException();
            }
            ProgramCounter++;
            
        }        

        internal void decf(int destinationsBit, int fileRegister)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;
            int currentValue = ramViewModel.getByte(row, column);

            isZero(currentValue, currentValue - 1);

            
            ramViewModel.setByte(row, column, currentValue - 1);

            ProgramCounter++;
        }

        internal void iOrWf(int destinationsBit, int fileRegister)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;
            var currentValue = ramViewModel.getByte(row, column);
            int result = currentValue | W_Register;

            isZero(currentValue, result);

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
            ProgramCounter++;
        }

        internal void andWf(int destinationsBit, int fileRegister)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;


            int currentValue = ramViewModel.getByte(row, column);
            int result = W_Register & currentValue;

            isZero(currentValue, result);
            isDigitCarryBorrow(currentValue, result);
            isCarryBorrow(currentValue, result);


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
            ProgramCounter++;
        }

        internal void xorWF(int destinationsBit, int fileRegister)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;

            int currentValue = ramViewModel.getByte(row, column);
            int result = W_Register ^ currentValue;

            isZero(currentValue, result);

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
            ProgramCounter++;


        }

        internal void addWf(int destinationsBit, int fileRegister)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;

            int currentValue = ramViewModel.getByte(row, column);
            int result = W_Register + currentValue;

            isZero(currentValue, result);
            isCarryBorrow(currentValue, result);
            isDigitCarryBorrow(currentValue, result);

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
            ProgramCounter++;
        }

        internal void movF(int destinationsBit, int fileRegister)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;

            int currentValue = ramViewModel.getByte(row, column);
            int result = currentValue;

            isZero(currentValue, result);

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
            ProgramCounter++;
        }

        internal void compF(int destinationsBit, int fileRegister)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;

            int currentValue = ramViewModel.getByte(row, column);
            int result = ~currentValue;

            isZero(currentValue, result);

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
            ProgramCounter++;
        }

        internal void clearF(int fileRegister)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;

            int currentValue = ramViewModel.getByte(row, column);
            int result = 0;

            isZero(currentValue, result);

            ramViewModel.setByte(row, column, result);
            ProgramCounter++;
        }

        internal void clearW()
        {    
            int currentValue = W_Register;
            int result = 0;

            isZero(currentValue, result);

            ProgramCounter++;
        }

        internal void incF(int destinationsBit, int fileRegister)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;

            int currentValue = ramViewModel.getByte(row, column);
            int result = currentValue + 1;

            isZero(currentValue, result);

            ramViewModel.setByte(row, column, result);

            ProgramCounter++;
        }

        internal void decfsz(int destinationsBit, int fileRegister)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;

            int currentValue = ramViewModel.getByte(row, column);
            int result = currentValue - 1;

            if (currentValue == 0)
            {
                ProgramCounter++;
                ProgramCounter++;
            }
            else if (destinationsBit == 1)
            {
                ramViewModel.setByte(row, column, result);
                ProgramCounter++;

            }
            else if (destinationsBit == 0)
            {
                W_Register = result;
                ProgramCounter++;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        internal void rrf(int destinationsBit, int fileRegister)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;

            int currentValue = ramViewModel.getByte(row, column);
            int result = currentValue / 2;

            isZero(currentValue, result);

            ramViewModel.setByte(row, column, result);

            ProgramCounter++;
        }

        internal void rlf(int destinationsBit, int fileRegister)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;

            int currentValue = ramViewModel.getByte(row, column);
            int result = currentValue * 2;

            isZero(currentValue, result);

            ramViewModel.setByte(row, column, result);

            ProgramCounter++;
        }

        internal void swapf(int destinationsBit, int fileRegister)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;

            int currentValue = ramViewModel.getByte(row, column);

            int temp = currentValue / 16;           //Bitstelle  4-7 um 2^4 (4.Stellen) nach rechts schieben
            int result= currentValue * 16 | temp;   // Bitstelle 0-3 um 2^4 (4.Stellen) nach links verschieben und verknüpfen


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

            ProgramCounter++;
        }

        internal void incfsz(int destinationsBit, int fileRegister)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;

            int currentValue = ramViewModel.getByte(row, column);
            int result = currentValue + 1;
           
            if(currentValue == 0)
            {
                ProgramCounter++;
                ProgramCounter++;
            }                         
            else if (destinationsBit == 1)
            {
                ramViewModel.setByte(row, column, result);
                ProgramCounter++;

            }
            else if (destinationsBit == 0)
            {
                W_Register = result;
                ProgramCounter++;
            }
            else
            {
                throw new NotImplementedException();
            }         

        }

        internal void movWF(int v, int fileRegister)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;

            ramViewModel.setByte(row, column, W_Register);

            ProgramCounter++;
        }

        internal void nop(int v, int fileRegister)
        {
            ProgramCounter++;
        }

        internal void movLW(int constValue)
        {
            W_Register = constValue;

            ProgramCounter++;
        }

        internal void goTo(int constValue)
        {
            //throw new NotImplementedException();

            ProgramCounter = constValue;
        }

        internal void call(int constValue)
        {
            //throw new NotImplementedException();

            stackProgramCounter.Add(ProgramCounter);
            ProgramCounter = constValue;
        }

        internal void retLW(int constValue)
        {
            

            W_Register = constValue;
            ProgramCounter = stackProgramCounter.Last();
            stackProgramCounter.Remove(stackProgramCounter.Last());

        }

        internal void iorLW(int constValue)
        {
            
            int result = W_Register | constValue;
            isZero(W_Register, result);

            W_Register = result;


            ProgramCounter++;
        }

        internal void andLW(int constValue)
        {
            int result = W_Register & constValue;

            isZero(W_Register, result);

            W_Register = result;

            ProgramCounter++;
        }

        internal void xorLW(int constValue)
        {
            int result = W_Register ^ constValue;

            isZero(W_Register, result);

            W_Register = result;

            ProgramCounter++;
        }

        internal void subLW(int constValue)
        {
            int result = constValue - W_Register;

            isZero(W_Register, result);
            isCarryBorrow(W_Register, result);
            isDigitCarryBorrow(W_Register, result);

            W_Register = result;

            ProgramCounter++;
        }

        internal void addLW(int constValue)
        {
            int result = W_Register + constValue;

            isZero(W_Register, result);
            isDigitCarryBorrow(W_Register, result);
            isCarryBorrow(W_Register, result);

            W_Register = result;

            ProgramCounter++;
        }              

        internal void bcf(int fileRegister, int selectedBit)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;

            int mask = 0;

            for(int i = 0; i < 8; i++ )
            {
                if(i != selectedBit)
                {
                    mask = mask + Convert.ToInt32((Math.Pow(2,i)));
                }                
            }


            int result = ramViewModel.getByte(row, column) & mask;
            ramViewModel.setByte(row, column, result);

            ProgramCounter++;
        }

        internal void clrwdt()
        {
            throw new NotImplementedException();

            ProgramCounter++;
        }

        internal void bsf(int fileRegister, int selectedBit)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;

            int mask = Convert.ToInt32(Math.Pow(2,selectedBit));
                      
            int result = ramViewModel.getByte(row, column) | mask;
            ramViewModel.setByte(row, column, result);

            ProgramCounter++;
        }

        internal void retIEF()
        {
            
            ProgramCounter = stackProgramCounter.Last();
            stackProgramCounter.Remove(stackProgramCounter.Last());
        }

        internal void btfsc(int fileRegister, int selectedBit)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;

            int result = ramViewModel.getByte(row, column) & Convert.ToInt32(Math.Pow(2, selectedBit));

            if(result > 0)
            {
                ProgramCounter++;

            }
            else if (result == 0)
            {
                ProgramCounter++;
                ProgramCounter++;
            }
            else
            {
                throw new NotImplementedException();
            }
            
        }

        internal void reTurn()
        {
            //throw new NotImplementedException();
            ProgramCounter = stackProgramCounter.Last();
            stackProgramCounter.Remove(stackProgramCounter.Last());
        }

        internal void btfss(int fileRegister, int selectedBit)
        {
            int row = Convert.ToInt32(fileRegister / 16);
            int column = fileRegister % 16;

            int result = (ramViewModel.getByte(row, column) & Convert.ToInt32(Math.Pow(2, selectedBit))) / Convert.ToInt32(Math.Pow(2, selectedBit));

            if (result == 0 )
            {
                ProgramCounter++;

            }
            else if (result == 1)       // Skip if set
            {
                ProgramCounter++;
                ProgramCounter++;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        internal void sleep()
        {
            //  throw new NotImplementedException();
            ProgramCounter++;
        }
    }
}
