using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.ViewModels;
using Caliburn.Micro;
using System.Windows;
using System.Threading;

namespace Simulation.Model
{
    class M_ProgramExecution
    {
        private List<M_FileListItem> _listItems;
        private M_Operators command;
        private RamViewModel ramViewModel;
        private int programCounter;
        private int executionCode;
        private OperationViewModel operationViewModel;
        private int prescaler = 0;
        private Thread thread;


        public M_ProgramExecution(List<M_FileListItem> _listItems, RamViewModel ramViewModel,OperationViewModel operationViewModel) 
        {
            this.operationViewModel = operationViewModel;
            this.ramViewModel = ramViewModel;
            this._listItems = _listItems;
             
            command = new M_Operators(ramViewModel);
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
                    if (operationViewModel.DataGrid_Operation.ElementAt(programCounter).Checkbox_IsSelected == true)
                    {
                        ViewModels.MainViewModel.currentState = ViewModels.MainViewModel.programStates.wait;
                        continue;
                    }

                    listItem = machineCycle();
                    continue;
                }
                else if (ViewModels.MainViewModel.currentState == ViewModels.MainViewModel.programStates.wait)
                    continue;
                else if (ViewModels.MainViewModel.currentState == ViewModels.MainViewModel.programStates.oneCycle)
                {
                    if(_listItems.Count >= programCounter)
                    {                    
                        listItem = machineCycle();
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

        private M_FileListItem machineCycle()
        {
            operationViewModel.selectLine(programCounter);
            M_FileListItem listItem = _listItems.ElementAt(programCounter);

            isExternInterrupt();
                        
            nextMachineCycle(listItem.OpCode);

            incTMRO();
            setPCL();

            Thread.Sleep(10);

            updateBackend();            
            updateSFR();

            programCounter = command.getProgramCounter();

            return listItem;
        }

        private bool isExternInterrupt()
        {

            if(command.PORTB == 12)
                    return true;
            return true;
        }

        private void updateBackend()
        {
            command.OPTION_REGISTER = ramViewModel.getByte(8, 1);
            command.STATUS = ramViewModel.getByte(0, 3);
            command.INTCON = ramViewModel.getByte(0, 11);
            command.TRISA = ramViewModel.getByte(8, 5);
            command.TRISB = ramViewModel.getByte(8, 6);            
        }

        private int oldPrescaler = 128;


        private void incTMRO()
        {
            if(oldPrescaler != command.Prescaler)
            {
                command.PrescalerTemp = 0;
                oldPrescaler = command.Prescaler;
            }


            command.TMR0 = ramViewModel.getByte(0, 1);

            if (command.PrescallerAssignmentBit == 1)
            {
              /*  if (prescaler < (command.Prescaler/2)) { prescaler++; }
                else if (prescaler >= (command.Prescaler / 2))
                {
                    // Watchdog
                    prescaler = 0;
                }
                else { throw new NotImplementedException(); }
                */
                command.TMR0++;
            }
            else if(command.PrescallerAssignmentBit ==0)
            {
                if(command.PrescalerTemp + 1  == command.Prescaler)
                {
                    command.TMR0 = command.TMR0 + 1;
                    command.PrescalerTemp = 0;
                }
                else if(command.PrescalerTemp < command.Prescaler) { command.PrescalerTemp++; }
                else{ throw new NotImplementedException();}
            }
            else { throw new NotImplementedException(); }   
            
            
            
                      
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

        private void nextMachineCycle(string opCode)
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
                if((code & controlCode) == 1)
                {
                    command.goTo(constValue);
                }
                else if((code & controlCode) == 0)
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
