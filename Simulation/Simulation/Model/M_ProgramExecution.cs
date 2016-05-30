using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.ViewModels;
using Caliburn.Micro;
using System.Windows;
using System.Threading;
using System.Diagnostics;

namespace Simulation.Model
{
    class M_ProgramExecution
    {
        private List<M_FileListItem> _listItems;
        private M_Operators command;
        private RamViewModel ramViewModel;
        private int programCounter;
        private OperationViewModel operationViewModel;        
        private Thread thread;
        private StackViewModel stackviewModel;
        private QuarzfrequenzViewModel quarzViewModel;
        private MainViewModel mainview;

        public M_ProgramExecution(List<M_FileListItem> _listItems, RamViewModel ramViewModel,OperationViewModel operationViewModel,StackViewModel stackv, QuarzfrequenzViewModel quarzV) 
        {
            this.operationViewModel = operationViewModel;
            this.ramViewModel = ramViewModel;
            this._listItems = _listItems;
            this.quarzViewModel = quarzV;
            this.stackviewModel = stackv;
            
             
            command = new M_Operators(ramViewModel,quarzViewModel,stackv);
            updateSFR();
            
            thread = new Thread(startProgram);

            if (!(this._listItems.Count.Equals(null)))
            {
                thread.Start();
            }
        }

        public Thread getThread()
        {
            return this.thread;
        }

        private void startProgram()
        {
            M_FileListItem listItem;
            programCounter = 0;

            for (programCounter = 0; programCounter < Convert.ToInt32(_listItems.Count );)
            {
                if (ViewModels.MainViewModel.currentState == ViewModels.MainViewModel.programStates.unstarted)
                    continue;
                else if (ViewModels.MainViewModel.currentState == ViewModels.MainViewModel.programStates.execute)
                {
                    if (operationViewModel.DataGrid_Operation.ElementAt(programCounter).Checkbox_IsSelected == true) // Breakpoint ?
                    {
                        ViewModels.MainViewModel.currentState = ViewModels.MainViewModel.programStates.oneCycle;
                        continue;                      
                    }

                    listItem = operationCycle();
                    continue;
                }
                else if (ViewModels.MainViewModel.currentState == ViewModels.MainViewModel.programStates.wait)
                    continue;
                else if (ViewModels.MainViewModel.currentState == ViewModels.MainViewModel.programStates.oneCycle)
                {
                    if(_listItems.Count >= programCounter)
                    {                    
                        listItem = operationCycle();
                    }
                    ViewModels.MainViewModel.currentState = ViewModels.MainViewModel.programStates.wait;
                    continue;
                }
                else if (ViewModels.MainViewModel.currentState == ViewModels.MainViewModel.programStates.finish)
                    return;
                else
                    if (ViewModels.MainViewModel.currentState == ViewModels.MainViewModel.programStates.execute)
                        return;
                    throw new NotImplementedException(); 
            }


        }

        private M_FileListItem operationCycle() 
        {
            setPCL();
            operationViewModel.selectLine(programCounter);      // Update der Ansich "Operation View"
            M_FileListItem listItem = _listItems.ElementAt(programCounter);     // Hole aktuellen Befehl per PC
            nextoperationCycle(listItem.OpCode);
            
            if(isTimerInterrupt())
            {
                Debug.WriteLine("Timer interrupt occures");
            }

            if(isExternInterrupt())
            {
                command.StackProgramCounter.Add(programCounter);
                command.ProgramCounter = 4;
            }
            if (isWatchdog()) { command.STATUS = command.STATUS & 240; }

            updateBackend();
            updateSFR();
            programCounter = command.getProgramCounter();
            
            return listItem;
        }

        private bool isWatchdog()
        {
            if((command.STATUS & 16 )== 0)  //Time out bit gesetzt?
            {
                command.ProgramCounter = 0;
                return true;
            }
            return false;
        }

        private bool isTimerInterrupt()
        {
            if (command.T0IE == 1 && command.GIE == 1 && command.TMR0 > 255)
            {
                command.INTCON = command.INTCON | 4;        // Set 4th Bit for timer overflow
                command.StackProgramCounter.Add(command.ProgramCounter);
                command.ProgramCounter = 4;
                command.TMR0 = 0;
                return true;
            }
            return false;
        }

        private bool isExternInterrupt()
        {
            command.PORTA = ramViewModel.getByte(0, 5);
            command.PORTB = ramViewModel.getByte(0, 6);

            if ((command.TRISB & 1) == 1 && command.OldPortB != command.PORTB && command.INTE == 1 && command.GIE == 1) // RB0 
            {
                
                if (command.INTEDG == 1 && command.OldPortB == 0)       // Rising edge 
                {
                    command.INTCON = command.INTCON | 2;
                    command.OldPortB = command.PORTB;
                    return true;
                }
                else if(command.INTEDG == 1 && command.OldPortB == 1) {
                    command.OldPortB = command.PORTB;
                    return false; }
                else if (command.INTEDG == 0 && command.OldPortB == 0) {
                    command.OldPortB = command.PORTB;
                    return false; }
                else if (command.INTEDG == 0 && command.OldPortB == 1)          // Falling edge
                {
                    command.INTCON = command.INTCON | 2;
                    command.OldPortB = command.PORTB;
                    return true;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            //Interrupt an Pin  4 -7 von Port B
            else if (command.TRISB > 15 && ((command.OldPortB & 240) != (command.PORTB & 240)) && command.RBIE == 1)
            {
                
                if (command.INTEDG == 1 && command.OldPortB == 0)           // rising edge
                {
                    command.INTCON = command.INTCON | 1;
                    command.OldPortB = command.PORTB;
                    return true;
                }
                else if (command.INTEDG == 0 && command.OldPortB > 15)      // falling edge
                {
                    command.INTCON = command.INTCON | 1;
                    command.OldPortB = command.PORTB;
                    return true;
                }
                else if(command.INTEDG == 1 && command.OldPortB > 15)
                {
                    command.OldPortB = command.PORTB;
                    return false;
                }
                else if(command.INTEDG == 0 && command.OldPortB == 0)
                {
                    command.OldPortB = command.PORTB;
                    return false;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            return false;
        }
        private void updateBackend()
        {
            if ((command.OPTION_REGISTER & 8) != (ramViewModel.getByte(8, 1) & 8))
            {
                command.PrescalerTemp = 0;
            }
            command.OPTION_REGISTER = ramViewModel.getByte(8, 1);
            command.STATUS = ramViewModel.getByte(0, 3);
            command.INTCON = ramViewModel.getByte(0, 11);
            command.TRISA = ramViewModel.getByte(8, 5);
            command.TRISB = ramViewModel.getByte(8, 6);
            command.FSR = ramViewModel.getByte(0, 4);
            command.PCLATH = ramViewModel.getByte(0, 10);
            
            if(command.TMR0 > 255) { command.TMR0 = 0; }
        }
        
        private void setPCL()
        {
            ramViewModel.setByte(0, 2, programCounter);
        }

        private void updateSFR()
        {
            var bank0 = ramViewModel.DataGrid_RamView.ElementAt(0);
            var bank1 = ramViewModel.DataGrid_RamView.ElementAt(8);
            var sfrView = ramViewModel.SfrView.DataGrid_SFRView;

            sfrView.ElementAt(0).Column_HEX = bank1.Column_5;           //TRISA
            sfrView.ElementAt(1).Column_HEX = bank0.Column_5;           // PORT A
            sfrView.ElementAt(2).Column_HEX = bank1.Column_6;           //TRISB
            sfrView.ElementAt(3).Column_HEX = bank0.Column_6;           // PORTB
            sfrView.ElementAt(4).Column_HEX = bank0.Column_3;           //STATUS
            sfrView.ElementAt(5).Column_HEX = bank1.Column_1;           //OPTION
            sfrView.ElementAt(6).Column_HEX = bank0.Column_11;          //INTCON
            sfrView.ElementAt(7).Column_HEX = ramViewModel.W_Register.ToString();  // W_Register
            sfrView.ElementAt(8).Column_HEX = bank0.Column_4;           //FSR
            sfrView.ElementAt(9).Column_HEX = bank0.Column_2;           // PCL
            sfrView.ElementAt(10).Column_HEX = bank0.Column_10;         // PCLATH
            command.RP0 = ramViewModel.getBit(0, 3, 5);
        }

        private void nextoperationCycle(string opCode)
        {
            int code = Convert.ToInt32(opCode,16);

            int patternMask =  convertBinToInt("1111_0000_0000_0000");
            patternMask = (code & patternMask) / Convert.ToInt32(Math.Pow(2,12));


            if (patternMask == 0)
            {
                select_BO_Command(code);
            }
            else if(patternMask > 1)
            {
                select_LIT_Operations(code);
            }
            else if(patternMask == 1)
            {
                select_Bit_Operations(code);
            }
        }

        private void select_BO_Command(int opCode)
        {
            int code = Convert.ToInt32(opCode);

            int operationCodeMask = convertBinToInt("0000_1111_0000_0000");
            int destinationBitMask = convertBinToInt("0000_0000_1000_0000");
            int fileRegisterMask = convertBinToInt("0000_0000_0111_1111");

            int operationCode = (code & operationCodeMask) / Convert.ToInt32(Math.Pow(2, 8));
            int destinationsBit = (code & destinationBitMask) / Convert.ToInt32(Math.Pow(2, 7));
            int fileRegister = (code & fileRegisterMask);

            switch (operationCode)
            {
                case 0:
                    specialCases(destinationsBit, fileRegister);
                    break;
                case 1:
                    if (destinationsBit == 0)
                        command.clearW();
                    else if (destinationsBit == 1)
                        command.clearF(fileRegister);
                    else
                        Console.WriteLine("Case1 of CLRW/F");
                    break;
                case 2:
                    command.subwf(destinationsBit, fileRegister);
                    break;
                case 3:
                    command.decf(destinationsBit, fileRegister);
                    break;
                case 4:
                    command.iOrWf(destinationsBit, fileRegister);
                    break;
                case 5:
                    command.andWf(destinationsBit, fileRegister);
                    break;
                case 6:
                    command.xorWF(destinationsBit, fileRegister);
                    break;
                case 7:
                    command.addWf(destinationsBit, fileRegister);
                    break;
                case 8:
                    command.movF(destinationsBit, fileRegister);
                    break;
                case 9:
                    command.compF(destinationsBit, fileRegister);
                    break;                
                case 10:
                    command.incF(destinationsBit, fileRegister);
                    break;
                case 11:
                    command.decfsz(destinationsBit, fileRegister);
                    break;
                case 12:
                    command.rrf(destinationsBit, fileRegister);
                    break;
                case 13:
                    command.rlf(destinationsBit, fileRegister);
                    break;
                case 14:
                    command.swapf(destinationsBit, fileRegister);
                    break;
                case 15:
                    command.incfsz(destinationsBit, fileRegister);
                    break;
                default:
                    Console.WriteLine("Error in switch of byte-orientated file register; value of operationCode: " + operationCode);
                    break;
            }
  

           
        }
        private void specialCases(int destinationsBit, int fileRegister)
        {
            if(destinationsBit == 1)
            {
                command.movWF(destinationsBit = 1, fileRegister);
            }
            else if((fileRegister & convertBinToInt("0000_0000_0001_1111")) == 0 )
            {
                command.nop(destinationsBit = 0, fileRegister);
            }
            else if((fileRegister & convertBinToInt("0000_0000_0111_1111")) == 100)
            {
                command.clrwdt();
            }
            else if ((fileRegister & convertBinToInt("0000_0000_0111_1111")) == 9)
            {
                command.retIEF();
            }
            else if ((fileRegister & convertBinToInt("0000_0000_0111_1111")) == 8)
            {
                command.reTurn();
            }
            else if ((fileRegister & convertBinToInt("0000_0000_0111_1111")) == 99)
            {
                command.sleep();
            }
        }

        private void select_LIT_Operations(int opCode)
        {
            int code = Convert.ToInt32(opCode);

            int operationCodeMask = convertBinToInt("0011_0000_0000_0000");
            int operationCode = (code & operationCodeMask) / Convert.ToInt32(Math.Pow(2, 12));

            int constValueMask = convertBinToInt("0000_0111_1111_1111");
            int constValue = (code & constValueMask);

            int controlMask = convertBinToInt("0000_1000_0000_0000");
            int controlCode = (code & controlMask) / Convert.ToInt32(Math.Pow(2, 11));

            if (operationCode == 3)
            {
                select_Literals(opCode);
            }
            else if (operationCode == 2)
            {
                if((controlCode) == 1)
                {
                    command.goTo(constValue);
                }
                else if((controlCode) == 0)
                {
                    command.call(constValue);
                }
            }
            else
            {
                Console.WriteLine("Error in select_LIT_Operations");
            }    
        }
        private void select_Literals(int code)
        {
            int constValueMask = convertBinToInt("0000_0000_1111_1111");
            int codeMask = convertBinToInt("0000_1111_0000_0000");

            int constValue = (code & constValueMask);
            int operationCode = (code & codeMask) / Convert.ToInt32(Math.Pow(2, 8));
            
            switch (operationCode)
            {
                case 0:
                    command.movLW(constValue);
                    break;
                case 1:
                    command.movLW(constValue);
                    break;
                case 2:
                    command.movLW(constValue);
                    break;
                case 3:
                    command.movLW(constValue);
                    break;
                case 4:
                    command.retLW(constValue);                    
                    break;
                case 5:
                    command.retLW(constValue);
                    break;
                case 6:
                    command.retLW(constValue);
                    break;
                case 7:
                    command.retLW(constValue);
                    break;
                case 8:
                    command.iorLW(constValue);
                    break;
                case 9:
                    command.andLW(constValue);
                    break;
                case 10:
                    command.xorLW(constValue);
                    break;                
                case 12:
                    command.subLW(constValue);
                    break;
                case 13:
                    command.subLW(constValue);
                    break;
                case 14:
                    command.addLW(constValue);
                    break;
                case 15:
                    command.addLW(constValue);
                    break;
                default:
                    Console.WriteLine("Error in switch of byte-orientated file register; value of operationCode: " + operationCode);
                    break;
            }
        }

        private void select_Bit_Operations(int code)
        {
            int codeMask = convertBinToInt("0000_1100_0000_0000");
            int bitMask = convertBinToInt("0000_0011_1000_0000");
            int fileMask = convertBinToInt("0000_0000_0111_1111");
            
            int operationCode = (code & codeMask) / Convert.ToInt32(Math.Pow(2, 10));
            int selectedBit = (code & bitMask) / Convert.ToInt32(Math.Pow(2,7));
            int fileRegister = (code & fileMask);

            switch (operationCode)
            {
                case 0:
                    command.bcf(fileRegister, selectedBit);
                    break;
                case 1:
                    command.bsf(fileRegister, selectedBit);
                    break;
                case 2:
                    command.btfsc(fileRegister, selectedBit);
                    break;
                case 3:
                    command.btfss(fileRegister, selectedBit);
                    break;         
                              
                default:
                    Console.WriteLine("Error in switch of bit-orientated file register; value of operationCode: " + operationCode);
                    break;
            }
        }    
        private int convertBinToInt(string bin)
        {
            bin = bin.Replace("_", "");

            return Convert.ToInt32(bin, 2);
        }

        public void resetProgrammCounter()
        {
            programCounter = 0;
            operationViewModel.selectLine(programCounter);
        }
    }
}
