using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.ViewModels;
using Caliburn.Micro;

namespace Simulation.Model

    
{
    class M_Operators : Screen
    {       
        private int _W_Register;
        private List<int> _stackProgramCounter;
        private bool _IsBank0selected = true;
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

        #region Status Register

        
        private int _CarryBit;
        private int _DigitCarryBit;
        private int _ZeroFlag;
        private int _TimeOutBit;
        private int _PowerDownBit;
        private int _RP0;
        #endregion
        #region Option Register bits
        private int _Prescaler;
        private int _PrescallerAssignmentBit;
        private int _ClockSource;
        private int _INTEDG;
        private int _RBPU;
        #endregion
        #region Interrupt Configuratio Register
        private int _GIE;
        private int _T0IE;
        private int _T0IF;
        private int _INTE;
        private int _RBIE;
        private int _INTF;
        private int _RBIF;
        #endregion



        private int _oldPortB;
        private int _machineCycle;
        private int _relativWatchdogCycle;
        private int _WatchdogTimer;


        private RamViewModel ramViewModel;

        private int prescalerTemp;

        public int W_Register
        {
            get
            {
                return _W_Register;
            }

            set
            {
                _W_Register = value;
                NotifyOfPropertyChange(() => W_Register);

                if (_W_Register < 0 && _W_Register > -256)
                    _W_Register = _W_Register + 256;
                else if (_W_Register > 255 && _W_Register < 512)
                    _W_Register = _W_Register - 256;
                ramViewModel.W_Register = W_Register;
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
                    
                if (T0IE == 1 && GIE == 1 && _TMR0 == 256)
                {
                    INTCON = INTCON | 4;
                    StackProgramCounter.Add(ProgramCounter);
                    ProgramCounter = 4;
                }
                             
                ramViewModel.setByte(0, 1, _TMR0);
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
                NotifyOfPropertyChange(() => INTCON);

                ramViewModel.setByte(0, 11, _INTCON);                
                ramViewModel.setByte(8, 11, _INTCON);
                _INTCON = ramViewModel.getByte(0, 11);

                GIE = INTCON & 128;
                T0IE = INTCON & 32;
                INTE = INTCON & 16;
                RBIE = INTCON & 8;
                T0IF = INTCON & 4;
                INTF = INTCON & 2;
                RBIF = INTCON & 1;
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
                NotifyOfPropertyChange(() => PCLATH);
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
                NotifyOfPropertyChange(() => PORTB);
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
                NotifyOfPropertyChange(() => PORTA);
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
                NotifyOfPropertyChange(() => FSR);
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
                NotifyOfPropertyChange(() => STATUS);
                ramViewModel.setByte(0, 3, _STATUS);
                ramViewModel.setByte(8, 3, _STATUS);
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
                NotifyOfPropertyChange(() => PCL);
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
                NotifyOfPropertyChange(() => TRISB);
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
                NotifyOfPropertyChange(() => TRISA);
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
                NotifyOfPropertyChange(() => OPTION_REGISTER);
                ramViewModel.setByte(8, 1, _OPTION_REGISTER);
                

                Prescaler =Convert.ToInt32(Math.Pow(2,( OPTION_REGISTER & 7) +1 ));
                PrescallerAssignmentBit = OPTION_REGISTER & 8;
                ClockSource             = OPTION_REGISTER & 16;
                INTEDG = OPTION_REGISTER & 64;
                RBPU = OPTION_REGISTER & 128;
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
                NotifyOfPropertyChange(() => RP0); 
                ramViewModel.setBit(0, 3, 5, _RP0);
                ramViewModel.setBit(8, 3, 5, _RP0);
            }
        }

        public bool IsBank0selected
        {
            get
            {
                return _IsBank0selected;
            }

            set
            {
                _IsBank0selected = value;
            }
        }
        public int Prescaler
        {
            get
            {
                return _Prescaler;
            }

            set
            {
                _Prescaler = value;
            }
        }
        public int PrescallerAssignmentBit
        {
            get
            {
                return _PrescallerAssignmentBit;
            }

            set
            {
                _PrescallerAssignmentBit = value;
                if (_PrescallerAssignmentBit > 0)
                    _PrescallerAssignmentBit = 1;
                else if (_PrescallerAssignmentBit == 0)
                    return;
                else { throw new NotImplementedException(); }
            }
        }
        public int ClockSource
        {
            get
            {
                return _ClockSource;
            }

            set
            {
                _ClockSource = value;
                if (_ClockSource > 0)
                    _ClockSource = 1;
                else if (_ClockSource == 0)
                    return;
                else { throw new NotImplementedException(); }
            }
        }
        public int INTEDG
        {
            get
            {
                return _INTEDG;
            }

            set
            {
                _INTEDG = value;
                if (_INTEDG > 0) { _INTEDG = 1; }
                else if (_INTEDG == 0) { _INTEDG = 0; }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }
        public int RBPU
        {
            get
            {
                return _RBPU;
            }

            set
            {
                _RBPU = value;
                if (_RBPU > 0) { _RBPU = 1; }
                else if (_RBPU == 0) { _RBPU = 0; }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public int GIE
        {
            get
            {
                return _GIE;
            }

            set
            {
                _GIE = value;
                if      (_GIE > 0)  { _GIE = 1; }                    
                else if (_GIE == 0) { _GIE = 0; }                    
                else { throw new NotImplementedException(); }
            }
        }
        public int T0IE
        {
            get
            {
                return _T0IE;
            }

            set
            {
                _T0IE = value;
                if      (_T0IE > 0)  { _T0IE = 1; }
                else if (_T0IE == 0) { _T0IE = 0; }
                else { throw new NotImplementedException(); }
            }
        }
        public int T0IF
        {
            get
            {
                return _T0IF;
            }

            set
            {
                _T0IF = value;
                if      (_T0IF > 0)     { _T0IF = 1; }                    
                else if (_T0IF == 0)    { _T0IF = 0; }                    
                else                    { throw new NotImplementedException(); }

                

            }
        }
        public int RBIF
        {
            get
            {
                return _RBIF;
            }

            set
            {
                _RBIF = value;
                if (_RBIF > 0) { _RBIF = 1; }
                else if (_RBIF == 0) { _RBIF = 0; }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public int INTF
        {
            get
            {
                return _INTF;
            }

            set
            {
                _INTF = value;
                if (_INTF > 0) { _INTF = 1; }
                else if (_INTF == 0) { _INTF = 0; }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public int RBIE
        {
            get
            {
                return _RBIE;
            }

            set
            {
                _RBIE = value;
                if (_RBIE > 0) { _RBIE = 1; }
                else if (_RBIE == 0) { _RBIE = 0; }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public int INTE
        {
            get
            {
                return _INTE;
            }

            set
            {
                _INTE = value;
                if (_INTE > 0) { _INTE = 1; }
                else if (_INTE == 0) { _INTE = 0; }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<int> StackProgramCounter
        {
            get
            {
                return _stackProgramCounter;
            }

            set
            {
                _stackProgramCounter = value;
            }
        }

        public int PrescalerTemp
        {
            get
            {
                return prescalerTemp;
            }

            set
            {
                prescalerTemp = value;
            }
        }

        public int OldPortB
        {
            get
            {
                return _oldPortB;
            }

            set
            {
                _oldPortB = value;
            }
        }

        public int MachineCycle
        {
            get
            {
                return MachineCycle1;
            }

            set
            {
                MachineCycle1 = value;
            }
        }
        public int WatchdogTimer
        {
            get
            {
                return _WatchdogTimer;
            }

            set
            {
                _WatchdogTimer = value;
            }
        }
        public int RelativWatchdogCycle
        {
            get
            {
                return _relativWatchdogCycle;
            }

            set
            {
                _relativWatchdogCycle = value;
            }
        }
        public int MachineCycle1
        {
            get
            {
                return _machineCycle;
            }

            set
            {
                _machineCycle = value;
            }
        }

        public M_Operators(RamViewModel ramViewModel)
        {
            this.ramViewModel = ramViewModel;
            StackProgramCounter = new List<int>();                  
            initRam();
            OldPortB = PORTB;
        }

        private void initRam()
        {
            STATUS = 24;
            OPTION_REGISTER = 255;
            TRISA = 32;
            TRISB = 255;
            
        }

        private void isZero(int ramValue, int result)
        {
            if (ramValue > 0 && result == 0)
            {
                ZeroFlag = 1;
            }
        }
        private void isCarryBorrow(int ramValue, int result)
        {
            if (result > 255)
            {
                CarryBit = 1;
            }
        }
        private void isDigitCarryBorrow(int ramValue, int result)
        {
            if (ramValue < 16 && result > 16)
            {
                DigitCarryBit = 1;
            }
        }
        
        

        internal void subwf(int destinationsBit, int fileRegister)
        {
            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);

            int result = ramValue - W_Register;

            isZero(ramValue, result);
            isCarryBorrow(ramValue, result);
            isDigitCarryBorrow(ramValue, result);

            SaveInDestination(destinationsBit, row, column, result);
            ProgramCounter++;

        }

        private void getRowColumn(int fileRegister, out int row, out int column, out int ramValue)
        {
            row = Convert.ToInt32(fileRegister / 16);
            column = fileRegister % 16;
            ramValue = ramViewModel.getByte(row, column);
        }

        private void SaveInDestination(int destinationsBit, int row, int column, int result)
        {
            if (destinationsBit == 1)
            {
                if(RP0 == 0)
                    ramViewModel.setByte(row, column, result);
                if(RP0 == 1)
                    ramViewModel.setByte(row + 8, column, result);
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

        internal void decf(int destinationsBit, int fileRegister)
        {
            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);

            isZero(ramValue, ramValue - 1);

            SaveInDestination(destinationsBit, row, column, ramValue - 1);
            
            ProgramCounter++;
        }

        internal void iOrWf(int destinationsBit, int fileRegister)
        {
            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);

            int result = ramValue | W_Register;

            isZero(ramValue, result);

            SaveInDestination(destinationsBit, row, column, result);
            ProgramCounter++;
        }

        internal void andWf(int destinationsBit, int fileRegister)
        {
            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);

            
            int result = W_Register & ramValue;

            isZero(ramValue, result);
            isDigitCarryBorrow(ramValue, result);
            isCarryBorrow(ramValue, result);

            SaveInDestination(destinationsBit, row, column, result);
            ProgramCounter++;
        }

        internal void xorWF(int destinationsBit, int fileRegister)
        {
            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);

            int result = W_Register ^ ramValue;

            isZero(ramValue, result);
            SaveInDestination(destinationsBit, row, column, result);
            ProgramCounter++;


        }

        internal void addWf(int destinationsBit, int fileRegister)
        {
            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);

            int result = W_Register + ramValue;

            isZero(ramValue, result);
            isCarryBorrow(ramValue, result);
            isDigitCarryBorrow(ramValue, result);
            SaveInDestination(destinationsBit, row, column, result);
            ProgramCounter++;
        }

        internal void movF(int destinationsBit, int fileRegister)
        {
            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);

            int result = ramValue;

            isZero(ramValue, result);

            SaveInDestination(destinationsBit, row, column, result);
            ProgramCounter++;
        }

        internal void compF(int destinationsBit, int fileRegister)
        {
            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);


            int result = ~ramValue;

            isZero(ramValue, result);

            SaveInDestination(destinationsBit, row, column, result);
            ProgramCounter++;
        }

        internal void clearF(int fileRegister)
        {
            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);

            int result = 0;

            isZero(1,0);

            ramViewModel.setByte(row, column, result);
            ProgramCounter++;
        }

        internal void clearW()
        {    
            int ramValue = W_Register;
            int result = 0;

            isZero(ramValue, result);

            W_Register = 0;

            ProgramCounter++;
        }

        internal void incF(int destinationsBit, int fileRegister)
        {
            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);

            int result = ramValue + 1;

            isZero(ramValue, result);

            ramViewModel.setByte(row, column, result);

            ProgramCounter++;
        }

        internal void decfsz(int destinationsBit, int fileRegister)
        {
            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);

            int result = ramValue - 1;

            if (ramValue == 0)
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
            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);

            int result = ramValue / 2;

            isCarryBorrow(ramValue, result);
            SaveInDestination(destinationsBit, row, column, result);

            ProgramCounter++;
        }

        internal void rlf(int destinationsBit, int fileRegister)
        {
            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);

            int result = ramValue* 2;

            isCarryBorrow(ramValue, result);
            SaveInDestination(destinationsBit, row, column, result);

            ProgramCounter++;
        }

        internal void swapf(int destinationsBit, int fileRegister)
        {
            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);

            int temp = ramValue/ 16;           //Bitstelle  4-7 um 2^4 (4.Stellen) nach rechts schieben
            int result= ramValue * 16 | temp;   // Bitstelle 0-3 um 2^4 (4.Stellen) nach links verschieben und verknüpfen


            SaveInDestination(destinationsBit, row, column, result);

            ProgramCounter++;
        }

        internal void incfsz(int destinationsBit, int fileRegister)
        {
            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);
            int result = ramValue + 1;
           
            if(ramValue == 0)
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
            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);

            SaveInDestination(1, row, column, W_Register);

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

            StackProgramCounter.Add(ProgramCounter);
            ProgramCounter = constValue;
        }

        internal void retLW(int constValue)
        {
            

            W_Register = constValue;
            ProgramCounter = StackProgramCounter.Last() + 1;
            StackProgramCounter.Remove(StackProgramCounter.Last());

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
            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);

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
            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);

            int mask = Convert.ToInt32(Math.Pow(2,selectedBit));
                      
            int result = ramViewModel.getByte(row, column) | mask;
            ramViewModel.setByte(row, column, result);

            ProgramCounter++;
        }

        internal void retIEF()
        {
            
            ProgramCounter = StackProgramCounter.Last() + 1 ;
            StackProgramCounter.Remove(StackProgramCounter.Last());
        }

        internal void btfsc(int fileRegister, int selectedBit)
        {
            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);

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
            ProgramCounter = StackProgramCounter.Last() + 1;
            StackProgramCounter.Remove(StackProgramCounter.Last());
        }

        internal void btfss(int fileRegister, int selectedBit)
        {
            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);

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
