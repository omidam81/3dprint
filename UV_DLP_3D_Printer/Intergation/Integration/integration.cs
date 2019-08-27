using System;
using System.Windows.Forms;
using UV_DLP_3D_Printer.Integration.FluidManagement;
using UV_DLP_3D_Printer.Integration.Motion;


namespace UV_DLP_3D_Printer.Integration.Integration
{
    public class IntegrationFunction
    {
        public PLCFunction PLCFunction = new PLCFunction();
        PLCFunction.printParameter PrintParameter = new PLCFunction.printParameter();
        PLCFunction.printPosition YPos = new PLCFunction.printPosition();
        FluidClass Fluid = new FluidClass();
        //"192.168.0.3", 0, 1
        int meniscusPressure = 450;
        int purgePressureInitialization = 200;
        int purgeTimeInitialization = 50;
        int[] purgeMode = { 1, 2, 3, 4, 5}; // 1:normal, 2:hard, 3:cancel, 4:de airing, 5:release
        bool EnableDisable = false;
        MachineConfig config;
        public void SetConfig (MachineConfig _config)
        {
            config = _config;
        }
        public void initializationCommunication()
        {

            PLCFunction.ConnectPlc(config.m_ip, 0, 1);
           // PLCFunction.ConnectPlc(config.m_ip, Rack, Slot);
            //Fluid.Temp_getSerialPorts();
            //Fluid.serialComPort = config.ConnectionConfig.comname;
            //Fluid.serialBaudRate = config.ConnectionConfig.speed.ToString();
            //Fluid.serialDataBits = ((byte)config.ConnectionConfig.databits).ToString();
            //Fluid.serialParity = ((byte)config.ConnectionConfig.parity).ToString();
            Fluid.openComms(config.ConnectionConfig);
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
        public void DefinePrintCaracteristic(bool Bidirection,bool Stich,int Overlaps,int layers,int[] swathNumber)
        {
            PLCFunction.defineManualPrintParameter(Bidirection, Stich,Overlaps,layers, swathNumber);
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
        public void SetZ1andZ2step(float z1,float z2)
        {
            PLCFunction.SetStepZaxis(z1,z2);

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
        
    }
}
