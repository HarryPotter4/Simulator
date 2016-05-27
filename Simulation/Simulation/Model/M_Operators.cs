using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.ViewModels;
using Caliburn.Micro;
using System.Windows.Forms;
using System.Diagnostics;

namespace Simulation.Model

    
{
    class M_Operators : Caliburn.Micro.Screen
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
        private int _INDF;
       
        
        private int _ProgramCounter;

        private int _localMachineCycle;

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
        private QuarzfrequenzViewModel quarzViewModel;
        private StackViewModel _stackv;

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
                if((_TMR0 == 255 && value == 0) || !(_TMR0 + 1 == value))   // Falls Überlauf oder wenn Wert verändert wird
                {
                    PrescalerTemp = 0;
                }
                _TMR0 = value;
                
               
                if(TMR0 == 256)
                {
                    ZeroFlag = 1;
                    
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
                ramViewModel.setByte(8, 10, _PCLATH);
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
                _PowerDownBit = ramViewModel.getByte(0, 3) & 8;
                _TimeOutBit = ramViewModel.getByte(0, 3) & 16;
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
               // ProgramCounter = (7936 & ProgramCounter)  | (255 & _PCL));       
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

                int mask = STATUS & (253 | _DigitCarryBit);
                ramViewModel.setBit(0, 3, 1, _DigitCarryBit);
                ramViewModel.setBit(8, 3, 1, _DigitCarryBit);

                Debug.WriteLine("Statusregister: " + ramViewModel.getByte(0, 3));

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
                if(_PrescallerAssignmentBit != value/8 )
                {
                    PrescalerTemp = 0;
                }
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

                if(StackProgramCounter.Count > 8)
                {
                    MessageBox.Show("Der Stack ist voll");
                    return;
                }

                for (int index = 8, stackIndex = 0; index > 1; index--, stackIndex++)
                {
                    int tempStack;

                    if(StackProgramCounter.Count > stackIndex) {
                        tempStack = StackProgramCounter.ElementAt(stackIndex);
                    }
                    else { tempStack = 0; }
                    _stackv.DataGrid_StackView.ElementAt(index).Column_Value = tempStack.ToString();
                }

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

        
        public int WatchdogTimer
        {
            get
            {
                return _WatchdogTimer;
            }

            set
            {
                _WatchdogTimer = value;
                // MessageBox.Show("WatchdogTimer: " + WatchdogTimer);
               // Debug.WriteLine("Watchdog count! " + WatchdogTimer );
                if (_WatchdogTimer == 256)
                {
                    
                    if(PowerDownBit == 0)
                    {
                        _WatchdogTimer = 0;
                        STATUS = STATUS | 8;                        
                        ProgramCounter++;
                            return;
                    }
                    STATUS = STATUS & 240;
                    ProgramCounter = 0;
                    Debug.WriteLine("Watchdog occures!");
                    _WatchdogTimer = 0;


                }
            }
        }
    
        public int MachineCycle
        {
            get
            {
                return _machineCycle;
            }

            set
            {
                if(value == 0) { return; } 
                _machineCycle = value;
                                

                if (PrescallerAssignmentBit == 1) //Assign to WDT
                {
                    TMR0++;

                    if (PrescalerTemp == Prescaler / 2)
                    {
                        WatchdogTimer++;
                        PrescalerTemp = 0;
                    }
                    else if (PrescalerTemp < Prescaler / 2)
                    {
                        PrescalerTemp++;
                    }
                }
                else if (PrescallerAssignmentBit == 0)  //Assign to Timer
                {
                    WatchdogTimer++;
                    if (prescalerTemp < Prescaler)
                    {
                        PrescalerTemp++;
                    }
                    if (PrescalerTemp == Prescaler)
                    {
                        TMR0++;
                        PrescalerTemp = 0;
                    }
                    
                }
                if(quarzViewModel.CurrentFrequenz != null)
                {
                    string[] tempString = quarzViewModel.CurrentFrequenz.Split(':');
                    string tempstring2 = tempString[1];
                    double tempFrequenz = Convert.ToDouble(tempstring2);
                    
                    double tempTime = 0.0 + Convert.ToDouble(quarzViewModel.Laufzeit);
                    quarzViewModel.Laufzeit = (tempTime + (1 / tempFrequenz)).ToString();
                }
            }
        }

        public int LocalMachineCycle
        {
            get
            {
                return _localMachineCycle;
            }

            set
            {
                _localMachineCycle = value;
            }
        }

        public int INDF
        {
            get
            {
                int row, column, ramValue, fileRegister;
                fileRegister = ramViewModel.getByte(0, 4);
                getRowColumn(fileRegister, out row, out column, out ramValue);
                return ramViewModel.getByte(row, column);
            }

            set
            {
                _INDF = value;
                NotifyOfPropertyChange(() => INDF);
                int row, column, ramValue;
                getRowColumn(FSR, out row, out column, out ramValue);

                
                ramViewModel.setByte(row, column, value);
                ramViewModel.setByte(row, column, value);
            }
        }

        public M_Operators(RamViewModel ramViewModel, QuarzfrequenzViewModel quarzViewModel, StackViewModel stackv)
        {
            this.quarzViewModel = quarzViewModel;
            this._stackv = stackv;
            this.ramViewModel = ramViewModel;
            StackProgramCounter = new List<int>();
            initRam();
            OldPortB = PORTB;
            WatchdogTimer = 0;
            MachineCycle = 0;
            PowerDownBit = 1;
            TimeOutBit = 1;
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
            if (result == 0)
            {
                ZeroFlag = 1;
            }
            else if(result != 0)
            {
                ZeroFlag = 0;
            }
        }
        private bool isCarryBorrow(int ramValue, int result)
        {
            if (result > 255 || (ramValue == 0 && result > 0 && result < 256))
            {
                CarryBit = 1;
                return true;
            }
            else if(result<=255)
            {
                CarryBit = 0;
                return false;
            }
            throw new NotImplementedException();
            
        }
        private bool isDigitCarryBorrow(int oldValue, int newValue)
        {
            if (oldValue < 16 && newValue >= 16 && oldValue > 0)
            {
                DigitCarryBit = 1;
                return true;
            }
            else
            {
                DigitCarryBit = 0;
                return false;
            }
        }
        
        

        internal void subwf(int destinationsBit, int fileRegister)
        {
            MachineCycle++;
            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);

            int result = ramValue - W_Register;

            isZero(W_Register, result);
            isCarryBorrow(W_Register, result);

            if (result > 31 && W_Register < 32) { DigitCarryBit = 1; }
            else { DigitCarryBit = 0; }

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
            MachineCycle++;
            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);

            isZero(ramValue, ramValue - 1);

            SaveInDestination(destinationsBit, row, column, ramValue - 1);
            
            ProgramCounter++;
            
        }

        internal void iOrWf(int destinationsBit, int fileRegister)
        {
            MachineCycle++;
            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);

            int result = ramValue | W_Register;

            isZero(ramValue, result);

            SaveInDestination(destinationsBit, row, column, result);
            ProgramCounter++;
            
        }

        internal void andWf(int destinationsBit, int fileRegister)
        {
            MachineCycle++;
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
            MachineCycle++;
            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);

            int result = W_Register ^ ramValue;

            isZero(ramValue, result);
            SaveInDestination(destinationsBit, row, column, result);
            ProgramCounter++;
            

        }

        internal void addWf(int destinationsBit, int fileRegister)
        {
            MachineCycle++;
            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);

            if(row == 0 && column == 0)
            {
                ramValue = INDF;
            }

            int result = W_Register + ramValue;

            if((row == 0 || row == 8 ) && (column == 2))
            {
                PCL = result;
                ramViewModel.setByte(row, column, PCL);
                ProgramCounter = (PCLATH*256) | PCL;
            }

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
            MachineCycle++;
        }

        internal void compF(int destinationsBit, int fileRegister)
        {
            MachineCycle++;
            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);


            int result = ~ramValue;

            isZero(ramValue, result);

            SaveInDestination(destinationsBit, row, column, result);
            ProgramCounter++;
            
        }

        internal void clearF(int fileRegister)
        {
            MachineCycle++;

            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);

            int result = 0;

            isZero(1,0);

            ramViewModel.setByte(row, column, result);
            
            ProgramCounter++;
            
        }

        internal void clearW()
        {
            MachineCycle++;
            int ramValue = W_Register;
            int result = 0;

            isZero(ramValue, result);

            W_Register = 0;

            ProgramCounter++;
            
        }

        internal void incF(int destinationsBit, int fileRegister)
        {
            MachineCycle++;
            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);

            int result = ramValue + 1;

            isZero(ramValue, result);

            ramViewModel.setByte(row, column, result);

            ProgramCounter++;
            
        }

        internal void decfsz(int destinationsBit, int fileRegister)
        {
            MachineCycle++;

            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);

            int result = ramValue - 1;

            if (ramValue == 0)
            {
                ProgramCounter++;
                ProgramCounter++;
                MachineCycle++;                
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
            MachineCycle++;

            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);

            int result = ramValue / 2;

            Debug.WriteLine("Result: " + result + "\t Ramvalue: " + ramValue + "\t W_Register: " + W_Register +"Carrybit: "+ CarryBit);

            if (CarryBit == 1)
            {
                result = result * 128;
            }

            //isCarryBorrow
            if((ramValue & 1) == 1) { CarryBit = 1; }
            else if((ramValue & 1) == 0 ) { CarryBit = 0; } 
            
                        
            SaveInDestination(destinationsBit, row, column, result);

            ProgramCounter++;
            
        }

        internal void rlf(int destinationsBit, int fileRegister)
        {
            MachineCycle++;

            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);

            int result = ramValue * 2;

            if(CarryBit == 1)
            {
                result++;
            }

            if(isCarryBorrow(ramValue, result)) { Debug.WriteLine("Carry is Borrow"); }
            else { Debug.WriteLine("Carry is not borrow"); }

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
            MachineCycle++;
        }

        internal void incfsz(int destinationsBit, int fileRegister)
        {

            
            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);
            int result = ramValue + 1;
           
            if((result & 255) == 0)                         // P11: Ergebnis = 0?
            {
                if(destinationsBit == 0) { W_Register = 0; }
                else if(destinationsBit == 1) { ramViewModel.setByte(row, column, 0); }

                ProgramCounter++;
                ProgramCounter++;

                MachineCycle++;
                MachineCycle++;
            }                         
            else if (destinationsBit == 1)
            {
                ramViewModel.setByte(row, column, result);
                ProgramCounter++;
                MachineCycle++;

            }
            else if (destinationsBit == 0)
            {
                W_Register = result;
                ProgramCounter++;
                MachineCycle++;
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

            if((row == 0 || row == 8) && (column == 0))
            {
                INDF = W_Register;
            }
            else
            {            
                SaveInDestination(1, row, column, W_Register);
            }          
            ProgramCounter++;
            MachineCycle++;
        }

        internal void nop(int v, int fileRegister)
        {
            ProgramCounter++;
            MachineCycle++;
        }

        internal void movLW(int constValue)
        {
            W_Register = constValue;

            ProgramCounter++;
            MachineCycle++;
        }

        internal void goTo(int constValue)
        {
            ProgramCounter = constValue;

            MachineCycle++;
            MachineCycle++;            
        }

        internal void call(int constValue)
        {
            MachineCycle++;
            MachineCycle++;

            StackProgramCounter.Add(ProgramCounter);
            StackProgramCounter = StackProgramCounter;

            ProgramCounter = PCLATH * 8 | constValue;

            if(constValue > 255 && PCLATH == 0)
            {
                MessageBox.Show("Fehler: Progamm ändern");
            }            
        }

        internal void retLW(int constValue)
        {
            MachineCycle++;
            MachineCycle++;

            W_Register = constValue;
            ProgramCounter = StackProgramCounter.Last() + 1;
            StackProgramCounter.Remove(StackProgramCounter.Last());
            StackProgramCounter = StackProgramCounter;


            PCLATH = 0;

            

        }

        internal void iorLW(int constValue)
        {
            MachineCycle++;
            int result = W_Register | constValue;
            isZero(W_Register, result);

            W_Register = result;


            ProgramCounter++;
           
        }

        internal void andLW(int constValue)
        {
            MachineCycle++;
            int result = W_Register & constValue;

            isZero(W_Register, result);

            W_Register = result;

            ProgramCounter++;
            
        }

        internal void xorLW(int constValue)
        {
            MachineCycle++;
            int result = W_Register ^ constValue;

            isZero(W_Register, result);

            W_Register = result;

            ProgramCounter++;
            
        }

        internal void subLW(int constValue)
        {
            MachineCycle++;
            int result = constValue - W_Register;

            isZero(W_Register, result);

            if(result >= 0)     { CarryBit = 1;  }
            else if(result < 0) { CarryBit = 0; }
            
            if(result > 31 && W_Register < 32) { DigitCarryBit = 1; }
            else { DigitCarryBit = 0; }
            
            W_Register = result;

            ProgramCounter++;
            
        }

        internal void addLW(int constValue)
        {
            MachineCycle++;
            int result = W_Register + constValue;

            isZero(W_Register, result);
            isDigitCarryBorrow(W_Register, result);
            isCarryBorrow(W_Register, result);

            W_Register = result;

            ProgramCounter++;
            
        }              

        internal void bcf(int fileRegister, int selectedBit)
        {
            MachineCycle++;
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
            MachineCycle++;
            WatchdogTimer = 0;
            TimeOutBit = 1;
            PowerDownBit = 1;

            STATUS = STATUS | 24;
            ProgramCounter++;
            
        }

        internal void bsf(int fileRegister, int selectedBit)
        {
            MachineCycle++;
            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);

            int mask = Convert.ToInt32(Math.Pow(2,selectedBit));
                      
            int result = ramViewModel.getByte(row, column) | mask;
            ramViewModel.setByte(row, column, result);

            ProgramCounter++;
            
        }

        internal void retIEF()
        {
            MachineCycle++;
            MachineCycle++;
            ProgramCounter = StackProgramCounter.Last() + 1 ;
            StackProgramCounter.Remove(StackProgramCounter.Last());

            StackProgramCounter = StackProgramCounter;

            
        }

        internal void btfsc(int fileRegister, int selectedBit)
        {
            
            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);

            int result = ramViewModel.getByte(row, column) & Convert.ToInt32(Math.Pow(2, selectedBit));

            if(result > 0)
            {
                ProgramCounter++;
                MachineCycle++;
            }
            else if (result == 0)
            {
                ProgramCounter++;
                ProgramCounter++;
                MachineCycle++;
                MachineCycle++;
            }
            else
            {
                throw new NotImplementedException();
            }
            MachineCycle++;
        }

        internal void reTurn()
        {
            //throw new NotImplementedException();
            MachineCycle++;
            MachineCycle++;

            ProgramCounter = StackProgramCounter.Last() + 1;
            StackProgramCounter.Remove(StackProgramCounter.Last());

            StackProgramCounter = StackProgramCounter;

            PCLATH = 0;

            
        }

        internal void btfss(int fileRegister, int selectedBit)
        {
            
            int row, column, ramValue;
            getRowColumn(fileRegister, out row, out column, out ramValue);

            int result = (ramViewModel.getByte(row, column) & Convert.ToInt32(Math.Pow(2, selectedBit))) / Convert.ToInt32(Math.Pow(2, selectedBit));


         /*   if(row == 0 && column == 1 && PrescallerAssignmentBit == 1) // Falls TMR0 Register überprüft wird: TMR0 hat einen höheren Werte, da Machinenzyklus
            {
                result = ((ramViewModel.getByte(row, column) + 1 ) & Convert.ToInt32(Math.Pow(2, selectedBit)))  / Convert.ToInt32(Math.Pow(2, selectedBit));
            }
           */

            if (result == 0 )
            {
                ProgramCounter++;
                MachineCycle++;

            }
            else if (result == 1)       // Skip if set
            {
                ProgramCounter++;
                ProgramCounter++;

                MachineCycle++;
                MachineCycle++;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        internal void sleep()
        {
            
            TimeOutBit = 1;
            PowerDownBit = 0;
            _STATUS = 247 & PowerDownBit;
            STATUS = STATUS | 16;
            MachineCycle++;
            //unveränderter Programmcounter           
        }
    }
}
