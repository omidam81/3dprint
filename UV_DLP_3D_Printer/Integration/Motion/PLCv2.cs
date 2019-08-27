using System;


namespace UV_DLP_3D_Printer.Integration.Motion
{
   public class PLCc
    {
        //DB data
        static int DB_Number = 1;
        static int DB_Start = 0;
        static int DB_End = 69;

        //Boolean button -> boolean bit
        int[] Use_recoater = new int[] { 0, 0 };
        int[] Home_all_axes = new int[] { 0, 1 }; //Home_all_axes register and bit position
        int[] Home_XY_axes = new int[] { 0, 2 };
        int[] Execute_move_X = new int[] { 0, 3 };
        int[] Execute_move_Y = new int[] { 0, 4 };
        int[] Execute_Move_disposer = new int[] { 0, 6 };
        int[] Execute_Move_Z1 = new int[] { 6, 0 };
        int[] Start_Homing_Z1 = new int[] { 6, 1 };
        int[] Stop_Disposer = new int[] { 6, 2 };
        int[] Execute_Move_Z2 = new int[] { 12, 0 };
        int[] Start_Homing_Z2 = new int[] { 12, 1 };
        int[] Heater_Start = new int[] {70,4};
        int[] Heater_Off = new int[] {70,5};

        int[] Print_Layer_Thickness = new int[] { 14, 0 };
        int[] Start_Homing_X = new int[] { 47, 1 };
        int[] Start_Homing_Y = new int[] { 47, 2 };
        int[] Execute_Spread_Cycle = new int[] { 46, 0 };

        //Real Register -> displacement, speed
        public int Pos_Z1 = 6;
        public int Pos_Z2 = 8;
        public int Pos_X = 54;
        public int Pos_Y = 58;

        int Print_layer_thickness = 14;
        int Velo_z = 18;
        int Velo_Y = 22;
        int Velo_X = 26;
        int Spread_Length_Push = 34;
        int spread_length_recoater = 38;
        int Spread_length = 42;
        int Disposer_step = 48;

        int Zstep = 64;

        byte[] DB1 = new byte[256];
        static S7Client Client;

        private void ShowResult(int Result)
        {
            Console.Write ( Client.ErrorText(Result) + "(" + Client.ExecTime().ToString() + " ms)");
        }
        public void ConnectPLC(string Address, int Rack, int Slot)
        {     
            int Result;
            Client = new S7Client();
            Result = Client.ConnectTo(Address, Rack, Slot);
            ShowResult(Result);
            if (Result == 0)
            {
                //enable print button and related button
            }
        }
        public void DisconnectPLC()
        {
            Client.Disconnect();
            //disable print buttonand related button
        }
        public void PLcDBRead()
        {
            int Result;
            Result = Client.DBRead(DB_Number, DB_Start, DB_End, DB1);
            ShowResult(Result);
            if (Result == 0)
            {
                //Actually there's no need for this line...
            }
        }
        public void PLcDBWrite()
        {
            int Result;
            Result = Client.DBWrite(DB_Number, DB_Start, DB_End, DB1);
            ShowResult(Result);
        }
        public void HomeAll()
        {
            PLcDBRead();
            if(S7.GetBitAt(DB1, Home_all_axes[0], Home_all_axes[1]))
            {
                S7.SetBitAt(ref DB1, Home_all_axes[0], Home_all_axes[1], false);
                PLcDBWrite();
            }
            S7.SetBitAt(ref DB1, Home_all_axes[0], Home_all_axes[1], true);
            PLcDBWrite();
            while (S7.GetBitAt(DB1, Home_all_axes[0], Home_all_axes[1]))
            {
                System.Threading.Thread.Sleep(100);
                PLcDBRead();
            }
        }
        public void HomeXY()
        {
            PLcDBRead();
            if (S7.GetBitAt(DB1, Home_XY_axes[0], Home_XY_axes[1]))
            {
                S7.SetBitAt(ref DB1, Home_XY_axes[0], Home_XY_axes[1], false);
                PLcDBWrite();
            }
            S7.SetBitAt(ref DB1, Home_XY_axes[0], Home_XY_axes[1], true);
            PLcDBWrite();
            while (S7.GetBitAt(DB1, Home_XY_axes[0], Home_XY_axes[1]))
            {
                System.Threading.Thread.Sleep(100);
                PLcDBRead();
            }
        }
        public void HomeZ1()
        {
            PLcDBRead();
            if (S7.GetBitAt(DB1, Execute_Move_Z1[0], Execute_Move_Z1[1]))
            {
                S7.SetBitAt(ref DB1, Execute_Move_Z1[0], Execute_Move_Z1[1], false);
                PLcDBWrite();
            }
            S7.SetBitAt(ref DB1, Execute_Move_Z1[0], Execute_Move_Z1[1], true);
            PLcDBWrite();
            while (S7.GetBitAt(DB1, Execute_Move_Z1[0], Execute_Move_Z1[1]))
            {
                System.Threading.Thread.Sleep(100);
                PLcDBRead();
            }
        }
        public void HomeZ2()
        {
            PLcDBRead();
            if (S7.GetBitAt(DB1, Start_Homing_Z2[0], Start_Homing_Z2[1]))
            {
                S7.SetBitAt(ref DB1, Start_Homing_Z2[0], Start_Homing_Z2[1], false);
                PLcDBWrite();
            }
            S7.SetBitAt(ref DB1, Start_Homing_Z2[0], Start_Homing_Z2[1], true);
            PLcDBWrite();
            while (S7.GetBitAt(DB1, Start_Homing_Z2[0], Start_Homing_Z2[1]))
            {
                System.Threading.Thread.Sleep(100);
                PLcDBRead();
            }
        }
        public void SpreadCycle()
        {
            PLcDBRead();
            if (S7.GetBitAt(DB1, Execute_Spread_Cycle[0], Execute_Spread_Cycle[1]))
            {
                S7.SetBitAt(ref DB1, Execute_Spread_Cycle[0], Execute_Spread_Cycle[1], false);
                PLcDBWrite();
            }
            S7.SetBitAt(ref DB1, Execute_Spread_Cycle[0], Execute_Spread_Cycle[1],true);
            PLcDBWrite();
            while (S7.GetBitAt(DB1, Execute_Spread_Cycle[0], Execute_Spread_Cycle[1]))
            {
                System.Threading.Thread.Sleep(100);
                PLcDBRead();
            }
        }
        //Function to move Axis Z1 (The powder bed by a step) with set step
        public void StepZ1(float step)
        {
        	PLcDBRead();
            if (S7.GetBitAt(DB1, Execute_Move_Z1[0], Execute_Move_Z1[1]))
            {
                S7.SetBitAt(ref DB1, Execute_Move_Z1[0], Execute_Move_Z1[1], false);
                PLcDBWrite();
            }
            S7.SetRealAt(DB1, Pos_Z1, step);
            S7.SetBitAt(ref DB1, Execute_Move_Z1[0], Execute_Move_Z1[1], true);
            PLcDBWrite();
            while (S7.GetBitAt(DB1, Execute_Move_Z1[0], Execute_Move_Z1[1]))
            {
                System.Threading.Thread.Sleep(100);
                PLcDBRead();
            }
        }
        //Function to move axis Z2 ( the print bed) with set step
        public void StepZ2(float step)
        {
        	PLcDBRead();
            if (S7.GetBitAt(DB1, Execute_Move_Z2[0], Execute_Move_Z2[1]))
            {
                S7.SetBitAt(ref DB1, Execute_Move_Z2[0], Execute_Move_Z2[1], false);
                PLcDBWrite();
            }
            S7.SetRealAt(DB1, Pos_Z2, step);
            S7.SetBitAt(ref DB1, Execute_Move_Z2[0], Execute_Move_Z2[1], true);
            PLcDBWrite();
            while (S7.GetBitAt(DB1, Execute_Move_Z2[0], Execute_Move_Z2[1]))
            {
                System.Threading.Thread.Sleep(100);
                P
        }
        public void MoveZ1Up()
        {
            PLcDBRead();
            if (S7.GetBitAt(DB1, Execute_Move_Z1[0], Execute_Move_Z1[1]))
            {
                S7.SetBitAt(ref DB1, Execute_Move_Z1[0], Execute_Move_Z1[1], false);
                PLcDBWrite();
            }
            S7.SetRealAt(DB1, Pos_Z1, 10);
            S7.SetBitAt(ref DB1, Execute_Move_Z1[0], Execute_Move_Z1[1], true);
            PLcDBWrite();
            while (S7.GetBitAt(DB1, Execute_Move_Z1[0], Execute_Move_Z1[1]))
            {
                System.Threading.Thread.Sleep(100);
                PLcDBRead();
            }
        }
        public void MoveZ2Up()
        {
            PLcDBRead();
            if (S7.GetBitAt(DB1, Execute_Move_Z2[0], Execute_Move_Z2[1]))
            {
                S7.SetBitAt(ref DB1, Execute_Move_Z2[0], Execute_Move_Z2[1], false);
                PLcDBWrite();
            }
            S7.SetRealAt(DB1, Pos_Z2, -10);
            S7.SetBitAt(ref DB1, Execute_Move_Z2[0], Execute_Move_Z2[1], true);
            PLcDBWrite();
            while (S7.GetBitAt(DB1, Execute_Move_Z2[0], Execute_Move_Z2[1]))
            {
                System.Threading.Thread.Sleep(100);
                PLcDBRead();
            }
        }
        public void MoveZ1Down()
        {
            PLcDBRead();
            if (S7.GetBitAt(DB1, Execute_Move_Z1[0], Execute_Move_Z1[1]))
            {
                S7.SetBitAt(ref DB1, Execute_Move_Z1[0], Execute_Move_Z1[1], false);
                PLcDBWrite();
            }
            S7.SetRealAt(DB1, Pos_Z1, -10);
            S7.SetBitAt(ref DB1, Execute_Move_Z1[0], Execute_Move_Z1[1], true);
            PLcDBWrite();
            while (S7.GetBitAt(DB1, Execute_Move_Z1[0], Execute_Move_Z1[1]))
            {
                System.Threading.Thread.Sleep(100);
                PLcDBRead();
            }
        }
        public void MoveZ2Down()
        {
            PLcDBRead();
            if (S7.GetBitAt(DB1, Execute_Move_Z2[0], Execute_Move_Z2[1]))
            {
                S7.SetBitAt(ref DB1, Execute_Move_Z2[0], Execute_Move_Z2[1], false);
                PLcDBWrite();
            }
            S7.SetRealAt(DB1, Pos_Z1, 10);
            S7.SetBitAt(ref DB1, Execute_Move_Z2[0], Execute_Move_Z2[1], true);
            PLcDBWrite();
            while (S7.GetBitAt(DB1, Execute_Move_Z2[0], Execute_Move_Z2[1]))
            {
                System.Threading.Thread.Sleep(100);
                PLcDBRead();
            }
        }
        public void ChangePosY(float amount)
        {
            PLcDBRead();
            if(S7.GetBitAt(DB1,Execute_move_Y[0],Execute_move_Y[1]))
            {
                S7.SetBitAt(ref DB1, Execute_move_Y[0], Execute_move_Y[1], false);
                PLcDBRead();
                System.Threading.Thread.Sleep(100);
            }
            S7.SetRealAt(DB1, Pos_Y, amount);
            S7.SetBitAt(ref DB1, Execute_move_Y[0], Execute_move_Y[1], true);
            PLcDBWrite();
            while (S7.GetBitAt(DB1, Execute_move_Y[0], Execute_move_Y[1]))
            {
                System.Threading.Thread.Sleep(100);
                PLcDBRead();
            }
        }
        public void ChangePosX(float amount)
        {
            PLcDBRead();
            if (S7.GetBitAt(DB1, Execute_move_X[0], Execute_move_X[1]))
            {
                S7.SetBitAt(ref DB1, Execute_move_X[0], Execute_move_X[1], false);
                PLcDBRead();
                System.Threading.Thread.Sleep(100);
            }
            S7.SetRealAt(DB1, Pos_X, amount);
            S7.SetBitAt(ref DB1, Execute_move_X[0], Execute_move_X[1], true);
            PLcDBWrite();
            while (S7.GetBitAt(DB1, Execute_move_X[0], Execute_move_X[1]))
            {
                System.Threading.Thread.Sleep(100);
                PLcDBRead();
            }
        }
        // Change the speed of both x axis
        public void ChangeVelocityX( float speed )
        {
        	PLcDBRead();
        	S7.SetRealAt(DB1,Velo_X,speed);
        	PLcDBWrite();
        }
        // Change the speed of both y axis
        public void ChangeVelocityY( float speed )
        {
        	PLcDBRead();
        	S7.SetRealAt(DB1,Velo_Y,speed);
        	PLcDBWrite();
        }
        // Change the speed of both z axis
        public void ChangeVelocityZ( float speed )
        {
        	PLcDBRead();
        	S7.SetRealAt(DB1,Velo_z,speed);
        	PLcDBWrite();
        }

        // Turn On/Off Heater lamp 
        public	void Heater(bool OnOff)
        {
        	PLcDBRead();
        	if (bool OnOff)
        	{
        		S7.SetBitAt(DB1,Heater_Start[0],Heater_Start[1],OnOff);
        		PLcDBWrite();
        	}
        	else
        	{
        		S7.SetBitAt(DB1,Heater_Start[0],Heater_Start[1],OnOff);
        		PLcDBWrite();
        	}
        }
        public float GetRealAt(int var_register)
        {
            float Result;
            PLcDBRead();
            Result = S7.GetRealAt(DB1, var_register);
            Console.WriteLine("Read value: ", Result);
            return Result;
        }
        public void SetSpreadStepZ1(float step)
        {
            PLcDBRead();
            S7.SetRealAt(DB1, Zstep, step);
            Client.DBWrite(DB_Number, DB_Start, DB_End,DB1);
        }
        public void SetSpreadStepZ2(float step)
        {
            PLcDBRead();
            S7.SetRealAt(DB1, Print_layer_thickness, step);
            Client.DBWrite(DB_Number, DB_Start, DB_End, DB1);
        }

    }
}
