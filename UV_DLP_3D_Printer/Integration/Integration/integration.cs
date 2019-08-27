using System;
using System.Windows.Forms;
using UV_DLP_3D_Printer.Integration.FluidManagement;
using UV_DLP_3D_Printer.Integration.Motion;


namespace UV_DLP_3D_Printer.Integration.Integration
{
    public class IntegrationFunction
    {
       public PLCFunction PLCFunction = new PLCFunction();
        public PLCFunction.printParameter PrintParameter = new PLCFunction.printParameter();
        PLCFunction.printPosition YPos = new PLCFunction.printPosition();
        public FluidClass Fluid = new FluidClass();
        //"192.168.0.3", 0, 1
        int meniscusPressure = 450;
        int purgePressureInitialization = 200;
        int purgeTimeInitialization = 50;
        int[] purgeMode = { 1, 2, 3, 4, 5}; // 1:normal, 2:hard, 3:cancel, 4:de airing, 5:release
        bool EnableDisable = false;
        MachineConfig config;
        private static IntegrationFunction instance = null;
        //public static IntegrationFunction Instance()
        //{
        //    if (instance == null)
        //    {
        //        instance = new IntegrationFunction();
        //    }
        //    return instance;
        //}
        public void SetConfig (MachineConfig _config)
        {
            config = _config;
        }
        public void initializationCommunication()
        {

            PLCFunction.ConnectPlc(config.m_ip, 0, 1);
           // PLCFunction.ConnectPlc(config.m_ip, Rack, Slot);
            //Fluid.Temp_getSerialPorts();
            Fluid.serialComPort = config.serialComPort;
            Fluid.serialBaudRate = config.serialBaudRate;
            Fluid.serialDataBits = config.serialDataBits;
            Fluid.serialParity = config.serialParity;
            Fluid.openComms(Fluid.serialStopBits);
        }
        // initialize parameter of the machine and purge 
        public void initializiationParameter()
        {
            Fluid.setMeniscus(meniscusPressure);
            Fluid.setPurgePressure(purgePressureInitialization);
            Fluid.setPurgeTime(purgeTimeInitialization);
            PLCFunction.XMiddlePosition();
            PLCFunction.ChangePosY(0);
            Fluid.PurgeCommand(purgeMode[0]);
        }

        //manage multiple layer print
        public void layersPrint()
        {

        }
        public void DefinePrintCaracteristic()
        {
            PLCFunction.defineManualPrintParameter(ref PrintParameter.Bidirection, ref PrintParameter.Stich, ref PrintParameter.Overlaps, ref PrintParameter.layers, ref PrintParameter.swathNumber);
        }
        public void PrintSingleLayer()
        {
            PLCFunction.PrintLayer(PrintParameter.Bidirection, PLCFunction.LEFT, PrintParameter.Stich, PLCFunction.nbStich, PrintParameter.Overlaps, PrintParameter.swathNumber[0]);
        }
        public void PrintMultipleLayer()
        {
            for (int i = 0; i <= PrintParameter.layers; i++)
            {
                PLCFunction.SpreadCycle();
                PLCFunction.PrintLayer(PrintParameter.Bidirection, PLCFunction.LEFT, PrintParameter.Stich, PLCFunction.nbStich, PrintParameter.Overlaps, PrintParameter.swathNumber[i]);
            }
        }




        public void PLCFunction_ChangePosX_Right()
        {
            PLCFunction.ChangePosX(PLCFunction.X_Right);
        }
        public void PLCFunction_ChangePosX_Left()
        {
            PLCFunction.ChangePosX(PLCFunction.X_Left);
        }
        public void PLCFunction_XMiddlePosition()
        {
            PLCFunction.XMiddlePosition();
        }
        public void MoveYAxisToStartPrintPosition()
        {
            PLCFunction.YStartPrintPosition();
            YPos.Y_Swath_Position = PLCFunction.Y_Start_Print_Position;
            YPos.Y_Stich_Position = YPos.Y_Swath_Position;

        }

        public void NextYAxisSwathPosition()
        {
            PLCFunction.MotionY(ref YPos.Y_Swath_Position, 0, false);
            YPos.Y_Stich_Position = YPos.Y_Swath_Position;

        }

        public void NextYAxisStichPosition()
        {
            PLCFunction.MotionYStich(YPos.Y_Stich_Position);

        }

        public void XAxisChoicePosition(float xPos)
        {
            PLCFunction.ChangePosX(xPos);
        }

        public void YAxisChoicePosition(float yPos)
        {
            PLCFunction.ChangePosX(yPos);

        }
        public void SetZ1andZ2step(float step1,float step2)
        {
            PLCFunction.SetStepZaxis(step1,step2);

        }
        public void ExecuteSpreadCycle()
        {
            PLCFunction.SpreadCycle();

        }
        public void SetMeniscusValue(int pressureMeniscus)
        {
            if (pressureMeniscus > 450)
                MessageBox.Show("too high Meniscus lower it");
            else
                Fluid.setMeniscus(pressureMeniscus);

        }

        public void SetPurgePressureValue(int pressurePurge)
        {
            if (pressurePurge > 500)
                MessageBox.Show("too high purge pressure lower it");
            else
                Fluid.setPurgePressure(pressurePurge);

        }

        public void SetPurgeTimeValue(int timePurge)
        {
            if (timePurge > 250)
                MessageBox.Show("too much time");
            else
                Fluid.setPurgeTime(timePurge);

        }

        public void ReadTankPressure()
        {
            Fluid.readMeniscus();
        }

        public void PurgeCommand()
        {
            Fluid.PurgeCommand(1);
        }

        public void EnableDisableInkSystem()
        {
            if (!EnableDisable)
            {
                Fluid.enableSystemFunctionality(721);
                EnableDisable = true;
            }
            else
            {
                Fluid.enableSystemFunctionality(720);
                EnableDisable = false;
            }
        }
        //main consol interface
        //void interfaceMain()
        //{
        //    Console.WriteLine("\n\n---------------------------");
        //    Console.WriteLine("---- possible command: ----");
        //    Console.WriteLine("1 : initialize communication parameter");
        //    Console.WriteLine("2 : Initialize printer");
        //    Console.WriteLine("3 : Automated Mode");
        //    Console.WriteLine("4 : Motion Control");
        //    Console.WriteLine("5 : Fluid supply control");
        //    Console.WriteLine("6 : Media control");
        //    Console.WriteLine("Q : Quit the app");
        //    Console.WriteLine("---------------------------");
        //}
        //void interfaceAutomatedMode()
        //{
        //    Console.WriteLine("\n\n---------------------------");
        //    Console.WriteLine("---- possible command: ----");
        //    Console.WriteLine("1 : get media folder (not implemented for now)");
        //    Console.WriteLine("2 : Print media folder (not implemented for now)");
        //    Console.WriteLine("---------------------------");
        //    Console.WriteLine("---- Advanced mode ----");
        //    Console.WriteLine("3 : Define Print Caracteristic");
        //    Console.WriteLine("4 : Print single layer");
        //    Console.WriteLine("5 : Print multiple layer");
        //    Console.WriteLine("---------------------------");
        //}
        //void interfaceMotionControl()
        //{
        //    Console.WriteLine("\n\n---------------------------");
        //    Console.WriteLine("---- possible command: ----");
        //    Console.WriteLine("1 : Move X-Axis to the right position of the PrintBed");
        //    Console.WriteLine("2 : Move X-Axis in the middle of the PrintBed");
        //    Console.WriteLine("3 : Move X-Axis to the left position of the PrintBed");
        //    Console.WriteLine("4 : Move Y-Axis to the start Print Position");
        //    Console.WriteLine("5 : Next Y-Axis Swath position");
        //    Console.WriteLine("6 : Next Y-Axis Stich Position");
        //    Console.WriteLine("7 : X axis choice position");
        //    Console.WriteLine("8 : Y axis choice position");
        //    Console.WriteLine("9 : Set Z1 & Z2 step");
        //    Console.WriteLine("s : Execute spread Cycle");
        //    Console.WriteLine("Q : Quit motion control");
        //}
        //void interfaceFluidSupplyControl()
        //{
        //    Console.WriteLine("\n\n---------------------------");
        //    Console.WriteLine("---- possible command: ----");
        //    Console.WriteLine("1 : Set Meniscus value:");
        //    Console.WriteLine("2 : Set purge pressure value:");
        //    Console.WriteLine("3 : set purge time value: ");
        //    Console.WriteLine("4 : read Tank pressure:");
        //    Console.WriteLine("5 : Purge command");
        //    Console.WriteLine("6 : Enable/disable ink system");
        //    Console.WriteLine("Q : Quit fluid supply control");
        //    Console.WriteLine("---------------------------");
        //}
        //void interfaceMediaControl()
        //{
        //    Console.WriteLine("\n\n---------------------------");
        //    Console.WriteLine("---- possible command: ----");
        //    Console.WriteLine("Not done yet");
        //    Console.WriteLine("Q : Quit media control");
        //    Console.WriteLine("");
        //}

        //void motionControl()
        //{
        //    char keyCommand = 'i';
        //    while (keyCommand != 'Q')
        //    {
        //        interfaceMotionControl();
        //        keyCommand = Console.ReadKey().KeyChar;
        //        switch (keyCommand)
        //        {
        //            case '1':
        //                PLCFunction.ChangePosX(PLCFunction.X_Right);
        //                break;
        //            case '2':
        //                PLCFunction.XMiddlePosition();
        //                break;
        //            case '3':
        //                PLCFunction.ChangePosX(PLCFunction.X_Left);
        //                break;
        //            case '4':
        //                PLCFunction.YStartPrintPosition();
        //                YPos.Y_Swath_Position = PLCFunction.Y_Start_Print_Position;
        //                YPos.Y_Stich_Position = YPos.Y_Swath_Position;
        //                break;
        //            case '5':
        //                PLCFunction.MotionY(ref YPos.Y_Swath_Position, 0, false);
        //                YPos.Y_Stich_Position = YPos.Y_Swath_Position;
        //                break;
        //            case '6':
        //                PLCFunction.MotionYStich(YPos.Y_Stich_Position);
        //                break;
        //            case '7':
        //                float xPos;
        //                if(!float.TryParse(Console.ReadLine(),out xPos))
        //                {
        //                    Console.WriteLine("Not a valid float");
        //                }
        //                else
        //                {
        //                    PLCFunction.ChangePosX(xPos);
        //                }
        //                break;
        //            case '8':
        //                float yPos;
        //                if (!float.TryParse(Console.ReadLine(), out yPos))
        //                {
        //                    Console.WriteLine("Not a valid float");
        //                }
        //                else
        //                {
        //                    PLCFunction.ChangePosX(yPos);
        //                }
        //                break;
        //            case '9':
        //                PLCFunction.SetStepZaxis();
        //                break;
        //            case 's':
        //                PLCFunction.SpreadCycle();
        //                break;
        //            case 'Q':
        //                Console.WriteLine("\n\nBye bye");
        //                break;


        //        }
        //    }
        //}
        //void fluidSupplyControl()
        //{
        //    char keyCommand = 'i';
        //    while (keyCommand != 'Q')
        //    {
        //        interfaceFluidSupplyControl();
        //        //Console.WriteLine("porname: {0}", FC.serialComPort);
        //        keyCommand = Console.ReadKey().KeyChar;
        //        switch (keyCommand)
        //        {
        //            case '1':
        //                int pressureMeniscus;
        //                if (!int.TryParse(Console.ReadLine(), out pressureMeniscus))
        //                {
        //                    Console.WriteLine("Not a valid int");
        //                }
        //                else
        //                {
        //                    if (pressureMeniscus>450)
        //                    {
        //                        Console.WriteLine("too high Meniscus lower it");
        //                    }
        //                    else
        //                    {
        //                        Fluid.setMeniscus(pressureMeniscus);
        //                    }                           
        //                }
        //                break;
        //            case '2':
        //                int pressurePurge;
        //                if (!int.TryParse(Console.ReadLine(), out pressurePurge))
        //                {
        //                    Console.WriteLine("Not a valid int");
        //                }
        //                else
        //                {
        //                    if (pressurePurge > 500)
        //                    {
        //                        Console.WriteLine("too high purge pressure lower it");
        //                    }
        //                    else
        //                    {
        //                        Fluid.setPurgePressure(pressurePurge);
        //                    }
        //                }
        //                break;
        //            case '3':
        //                int timePurge;
        //                if (!int.TryParse(Console.ReadLine(), out timePurge))
        //                {
        //                    Console.WriteLine("Not a valid int");
        //                }
        //                else
        //                {
        //                    if (timePurge > 250)
        //                    {
        //                        Console.WriteLine("too much time");
        //                    }
        //                    else
        //                    {
        //                        Fluid.setPurgeTime(timePurge);
        //                    }
        //                }
        //                break;
        //            case '4':
        //                //int tankPressure;
        //                Fluid.readMeniscus();
        //                break;
        //            case '5':
        //                Fluid.PurgeCommand(1);
        //                break;
        //            case '6':
        //                if(!EnableDisable)
        //                {
        //                    Fluid.enableSystemFunctionality(721);
        //                    EnableDisable = true;
        //                }
        //                else
        //                {
        //                    Fluid.enableSystemFunctionality(720);
        //                    EnableDisable = false;
        //                }                        
        //                break;
        //            case 'Q':
        //                Console.WriteLine("\n\nBye bye");
        //                break;



        //        }
        //    }
        //}
        //main loop of the code
        //public void mainCommand()
        //{
        //    char keyCommand ='i';
        //    while (keyCommand!='Q')
        //    {
        //        interfaceMain();
        //        keyCommand = Console.ReadKey().KeyChar;
        //        Console.WriteLine();
        //        switch (keyCommand)
        //        {
        //            case '1': //initilization of communication parameter
        //                initializationCommunication();
        //                break;
        //            case '2'://initialization of the printer
        //                initializiationParameter();
        //                break;
        //            case '3'://automated mode
        //                //automatedMode();
        //                break;
        //            case '4'://motion control
        //                motionControl();
        //                break;
        //            case '5'://fluid supply control
        //                fluidSupplyControl();
        //                break;
        //            case '6': //media control 
        //                Console.WriteLine("Nothing to see here");
        //                break;
        //            case '7':
        //                Fluid.temp_disconnect();
        //                break;
        //            case 'Q':
                        
        //                Console.WriteLine("/nBye bye");
        //                break;
        //            default:
        //                Console.WriteLine("Wrong Key -> try again");
        //                break;
        //        }
        //    }
            
        //}
    }
}
