using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace UV_DLP_3D_Printer.Integration.Motion
{
    public class PLCFunction
    {
        //----- Variable -----------------------//
        public bool RIGHT = false;
        public bool LEFT = true;
        public bool Bidirection = false; //Default paramater
        public bool Stich = false; // defautl parameter
        public int nbStich = 1;
        public int Overlaps = 0;
        public struct printParameter
        {
            public bool Bidirection;
            public bool Stich;
            public int Overlaps;
            public int layers;
            public int[] swathNumber;
        }
        public struct printPosition
        {
            public float Y_Swath_Position ;
            public float Y_Stich_Position ;
        }
        public printParameter printParam = new printParameter();
        public float X_Zero_Position = 0;
        public float X_Left = 70;
        public float X_Middle_Position = 170;
        public float X_Right = 350;
        public float Y_Start_Print_Position = 560;
        public float Y_End_Print_Position = 350;
        public float Y_Zero_Position = 0;
        public float X_Temporary_Left = 70;
        public float X_Temporary_Right = 350;

        public float Y_Step = 64.890f; //real value 64.897 precision -> 10 micrometer
        public float Y_Step_Stich = 0.063f;
        public int swaths = 3;
        public int nb_layer = 1;


        public PLCc PLC = new PLCc();
        public void ConnectPlc(string Address, int Rack, int Slot)
        {
            PLC.ConnectPLC(Address,Rack,Slot);
        }
        public void XZeroPosition()
        {
            PLC.ChangePosX(X_Zero_Position);
        }
        public void XStartPrintPosition(bool PrintMainDirection)
        {
            if (PrintMainDirection == RIGHT)
            {
                PLC.ChangePosX(X_Left);
            }
            if(PrintMainDirection == LEFT)
            {
                PLC.ChangePosX(X_Right);
            }
        }
        public void XMiddlePosition()
        {
            PLC.ChangePosX(X_Middle_Position);
        }
        public void XEndPosition(bool PrintMainDirection)
        {
            if (PrintMainDirection == RIGHT)
            {
                PLC.ChangePosX(X_Right);
            }
            if (PrintMainDirection == LEFT)
            {
                PLC.ChangePosX(X_Left);
            }
        }
        public void YStartPrintPosition()
        {
            PLC.ChangePosY(Y_Start_Print_Position);
        }
        public void YZeroPosition()
        {
            PLC.ChangePosY(Y_Zero_Position);
        }
        public float AxisLastPosition(char axis)
        {
            if (axis == 'x')
            {
                return PLC.GetRealAt(PLC.Pos_X); // Pos_X offset = 42
            }
            if (axis == 'y')
            {
                return PLC.GetRealAt(PLC.Pos_Y); // Pos_Y offset = 46
            }
            else return 0;
        }
        public void MotionX(bool Position)
        {
            if(Position == RIGHT)
            {
                MessageBox.Show(string.Format("Move Left: {0}" ,X_Left));
                PLC.ChangePosX(X_Left);
                Position = LEFT;
            }
            else
            {
                MessageBox.Show(string.Format("Move Right : {0}", X_Right));
                PLC.ChangePosX(X_Right);
                Position = RIGHT;
            }
        }
        public void MotionYStich(float YPosition)
        {
            YPosition = YPosition - Y_Step_Stich;
            MessageBox.Show(string.Format("Move down YStich: {0}", YPosition));
            PLC.ChangePosY(YPosition);
        }
        public void ChangePosY(float Y_Position)
        {
            PLC.ChangePosY(Y_Position);
        }
        public void ChangePosX(float X_Position)
        {
            PLC.ChangePosX(X_Position);
        }
        public void MotionY(ref float YPosition, int Stich_Number, bool Stich)
        {
            if(Stich)
            {
                YPosition = YPosition + Stich_Number * Y_Step_Stich;
            }
            YPosition = YPosition - Y_Step;
            MessageBox.Show(string.Format("Moove Y position by Y tep : {0}", YPosition));
            PLC.ChangePosY(YPosition);
        }
        public void SetStepZaxis(float z1,float z2)
        {
            PLC.SetSpreadStepZ1(z1);
            PLC.SetSpreadStepZ2(z2);
        }
        public void SpreadCycle()
        {
            PLC.SpreadCycle();
        }
        public void defineManualPrintParameter(bool bidirection,bool stitch,int overlaps,int layers,int[] swathNumber)
        {
            printParam.Bidirection = bidirection;
            printParam.Stich = stitch;
            printParam.Overlaps = overlaps;
            printParam.layers = layers;
            printParam.swathNumber = swathNumber;

            //Console.WriteLine("---- Manual setting of print parameter ----");
            //int temp = 'i';
            //while (temp != '0' && temp != '1')
            //{
            //    Console.WriteLine("Bidirection setting: 0(false) or  1(true)");
            //    temp = Console.Read();
            //}
            //bidirection = Convert.ToBoolean(bidirection);
            //Console.WriteLine("Stich setting : 0(false) or 1(true)");
            //temp = 'i';
            //while (temp != '0' && temp != '1')
            //{
            //    Console.WriteLine("Stich setting : 0(false) or 1(true)");
            //    temp = Console.Read();
            //}
            //stitch = Convert.ToBoolean(temp);
            //int temp_i = 0;
            //while (temp_i < 1 && temp_i > 5)
            //{
            //    Console.WriteLine("Number of overlaps (up to 3)");
            //    temp_i = Console.Read();
            //}
            //overlaps = temp_i;
            //temp_i = -1;
            //float step = PLC.GetRealAt(PLC.Pos_Z2);
            //float maxLayerF = 30 / step;//max number of layer
            //int maxLayerI = Convert.ToInt32(maxLayerF);
            //while (temp_i < 1 && temp_i > maxLayerI)
            //{
            //    temp_i = Console.Read();
            //}
            //layers = temp_i;
            //temp_i = -1;
            //while (temp_i < 1 && temp_i > 6)
            //{
            //    Console.WriteLine("In this mode just define the mqximum number of swath: ");
            //    temp_i = Console.Read();
            //}
            //for (int i = 0; i < layers; i++)
            //{
            //    swathNumber[i] = temp_i;
            //}
        }


        //------------------ print routine ------------------//
        public void PrintLayer(bool Bidirection, bool PrintMainDirection, bool Stich, int Nb_Stich, int Overlaps, int Swaths)
        {
            //PrintHead initiialisation
            YStartPrintPosition();
            XStartPrintPosition(PrintMainDirection);
            bool Position = true;
            if(PrintMainDirection == RIGHT)
            {
                Position = LEFT;
            }
            else
            {
                Position = RIGHT;
            }
            float YPosition = Y_Start_Print_Position;
            MessageBox.Show(string.Format("YPostion initial value: {0}", YPosition));
            int i;
            int Count_Overlaps = 0;
            int s;
            for(i = 0; i< swaths; i++)
            {
                MessageBox.Show(string.Format("Swaths Nb ; {0}", i));
                for (s =0; s<= Nb_Stich; s++)
                {
                    for (Count_Overlaps = 0; Count_Overlaps < Overlaps; Count_Overlaps++)
                    {
                        MessageBox.Show(string.Format("Overlaps Nb : {0}", Count_Overlaps));
                        MessageBox.Show(string.Format("Stich Nb: {0}", Nb_Stich));
                        if (s < Nb_Stich || i < swaths - 1 || Count_Overlaps < Overlaps)
                        {
                            MotionX(Position);
                        }
                        if (!Bidirection && (s <Nb_Stich || i< swaths - 1 || Count_Overlaps < Overlaps -1))
                        {
                            MotionX(Position);
                        }
                    }
                    if (s < Nb_Stich)
                    {
                        MotionYStich(YPosition);
                    }
                }
                if (s < Nb_Stich || i < swaths - 1 || Count_Overlaps < Overlaps)
                {
                    MotionY(ref YPosition, Nb_Stich, Stich);
                }
            }
        }

    }
}
