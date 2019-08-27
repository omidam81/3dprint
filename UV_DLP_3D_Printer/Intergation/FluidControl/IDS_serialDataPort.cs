using System;
using System.IO.Ports;
using System.Threading;
using System.Collections;
using System.Text;
using UV_DLP_3D_Printer.Configs;
using System.Windows.Forms;

namespace UV_DLP_3D_Printer.Integration.FluidManagement
{
    public class IDS_SerialDataPort
    {
        SerialPort mySerialPort = new SerialPort();
        private int LCharDelay = 2;
        private int LCommandDelay = 40;
        private string ActiveCommand = "";
        private Boolean serialActive = false;
        // Creates and initializes a new Queue.
        private Queue MessageQueue = new Queue();
        private string ReceiveBuffer;
        public IDS_SerialDataPort(ConnectionConfig con, Int16 SendCharDelay = 2, Int16 CommandDelay = 40)
        {
            LCharDelay = SendCharDelay;
            LCommandDelay = CommandDelay;
            mySerialPort.PortName = con.comname;// _portName;
            mySerialPort.BaudRate = con.speed;// 19200;
            mySerialPort.Parity = con.parity;// Parity.None;
            mySerialPort.DataBits = con.databits;// 8;
            mySerialPort.StopBits = con.stopbits;// StopBits.One;
            //add data handler thread
            mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }
        public IDS_SerialDataPort(string _portName = "COM1", Int16 SendCharDelay = 2, Int16 CommandDelay = 40)
        {
            LCharDelay = SendCharDelay;
            LCommandDelay = CommandDelay;
            mySerialPort.PortName = _portName;
            mySerialPort.BaudRate = 19200;
            mySerialPort.Parity = Parity.None;
            mySerialPort.DataBits = 8;
            mySerialPort.StopBits = StopBits.One;
            //add data handler thread
            mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }

        ~IDS_SerialDataPort()
        {
            mySerialPort.Close();
            MessageQueue.Clear();
        }


        public void AddData(string data)
        {
            if (!mySerialPort.IsOpen)
            {
                try
                {
                    mySerialPort.Open();
                }
                catch
                {
                    MessageBox.Show("Port is closed or does not exist");
                }
            }
            if (mySerialPort.IsOpen)
            {
                MessageQueue.Enqueue(data);
                if (!serialActive)
                {
                    SendNextMessage();
                }
            }
        }

        public string SendNextMessage()
        {
            string returnValue = "";
            if (MessageQueue.Count > 0)
            {
                serialActive = true;
                ActiveCommand = System.Convert.ToString(MessageQueue.Dequeue());
                //     cmdTimeOut.Enabled = true;
                Console.WriteLine("send data: {0}", ActiveCommand);
                SendData(ActiveCommand);
                returnValue = "OK";
            }
            else
            {
                returnValue = "SEQCOMP";
                serialActive = false;
            }
            return returnValue;
        }

        private void SendData(string dataToSend)
        {

            if (!mySerialPort.IsOpen)
            {
                try
                {
                    mySerialPort.Open();
                }
                catch
                { MessageBox.Show("Port is closed or does not exist"); }
            }

            string IDSstring;

            IDSstring = string.Format(dataToSend + "\r");

            for (int i = 0; i < IDSstring.Length; i++)
            {
                if (mySerialPort.IsOpen)
                    mySerialPort.Write(IDSstring.Substring(i, 1));
                Thread.Sleep(LCharDelay);
            }
            Thread.Sleep(LCommandDelay);

        }

        public void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            int Count = sp.BytesToRead;
            byte[] Buffer = new byte[Count];
            sp.Read(Buffer, 0, Count);
            for (int I = 0; I <= Buffer.GetUpperBound(0); I++)
            {
                //ReceiveBuffer += System.Convert.ToString(Buffer[I]);
                ReceiveBuffer += Encoding.ASCII.GetString(Buffer, I, 1);
                if (Buffer[I] == 10)
                {

                    //invokes a call to the main thread, myDel holds the signiture(ie arguments list) to the process serial method so calling
                    //processSerial calls the method with the arguments
                    try
                    {
                        Process_serial(ReceiveBuffer);
                    }
                    catch
                    {

                    }
                    ReceiveBuffer = "";
                }
            }
        }

        public void Process_serial(string currentMessage)
        {
            if (currentMessage.Length > 0) //stips blank string
            {

                //Split out the fields
                string[] sField = currentMessage.Split(",".ToCharArray());
                if (sField.Length > 1)
                {
                    MessageBox.Show(currentMessage);
                    if (System.Convert.ToBoolean((sField[1]).IndexOf("C") + 1))
                    {

                        if (System.Convert.ToBoolean((sField[0]).IndexOf("?") + 1))
                        {
                            //   AddToListBox(currentMessage);

                            //resend + count

                            //   AddToListBox("Command failed ");
                        }
                        else
                        {   //in network mode remove header 
                            Console.WriteLine("");
                            string[] idTag = ActiveCommand.Split(",?".ToCharArray());
                            if (idTag[0].Length > 3)
                            {
                                MessageBox.Show(string.Format("Response on NetworkNode: {0}", ActiveCommand.Substring(0, 1)));
                                ActiveCommand = ActiveCommand.Substring(1);
                            }
                            else
                                Console.WriteLine("Non Network Response");
                            //    AddToListBox(currentMessage);
                            switch (ActiveCommand.Substring(0, 4))
                            {
                                case "SA1?": //GET ALARM STATUS
                                             //       ushort Ddata1_1 = System.Convert.ToUInt16(Convert.ToInt32(Conversion.Val(sField[0])));
                                    BitArray Xdata1_1;
                                    //      Xdata1_1 = new BitArray(new int[] { Ddata1_1 });
                                    break;
                                // DisplayAlarmBits(Xdata1)

                                case "SVP?": //GET VACUUM PRESSURE
                                    break;
                                //  txtCalMenSetpoint.Text = (sField(0))
                                case "SPP?": //GET PURGE PRESSURE
                                    break;
                                case "SPH?": //GET PREHEAT TIME
                                    break;
                                case "SBT?": //GET BYPASS TIME
                                    break;
                                case "SPT?": //GET PURGE TIME
                                    break;

                                case "SRS?": //GET RECIRC SPEED
                                    break;
                                //   txtCalRecSetpoint.Text = (sField(0))

                                case "SHT?": //GET TANK TEMP
                                    break;

                                case "SH2?": //GET RECIRC SPEED
                                    break;

                                case "SEB?": //GET CURRENT ENABLED BITS
                                             //      ushort Ddata1 = System.Convert.ToUInt16(Convert.ToInt32(Conversion.Val(sField[0])));
                                    BitArray Xdata1;
                                    //        Xdata1 = new BitArray(new int[] { Ddata1 });
                                    break;
                                //  DisplayEnableBits(Xdata1)
                                case "SVN?": //GET firmware version number
                                    break;
                                //  lblFirmware.Text = "V" & sField(0)
                                case "SSN?": //get unit serial numb
                                    break;
                                //  lblSN.Text = VB.Right("00000" & sField(0), 5)
                                //  getCurrent = False
                                case "SRT?": //get run time
                                    string[] timeSplit = sField[0].Split("-".ToCharArray());
                                    if (timeSplit.Length > 0)
                                    {
                                        //     lblRunTime.Text = timeSplit(0) & " hours " & timeSplit(1) & " minutes"
                                    }
                                    break;
                                default:
                                    break;
                            }

                            //process data per command
                            //AddToListBox("Completed");
                        }
                        MessageBox.Show(string.Format("Queue depth:{0}", MessageQueue.Count));
                        SendNextMessage();
                    }
                    else if (System.Convert.ToBoolean((sField[1]).IndexOf("A") + 1))
                    {
                        //     timeoutCount = 0;
                        //      cmdTimeOut.Enabled = false;
                        //     AddToListBox("Processing ");
                        //      AddToListBox(currentMessage);
                    }
                    else if (System.Convert.ToBoolean((sField[1]).IndexOf("B") + 1))
                    {
                        MessageBox.Show(string.Format("current meniscus{0}", sField[0]));
                        // txtCalMenCurrent.Text = (sField(0))
                        // txtLivePressure.Text = Str(Val(sField(0)))
                        // txtRecircSensCal.Text = Str(Val(sField(0)))
                    }
                    else if (System.Convert.ToBoolean((sField[1]).IndexOf("T") + 1))
                    {
                        MessageBox.Show(string.Format("current Tank temp{0}", sField[0]));
                        //txtLiveTankTemp.Text = sField(0)
                    }
                    else if (System.Convert.ToBoolean((sField[1]).IndexOf("R") + 1))
                    {
                        MessageBox.Show(string.Format("current Recirc{0}", sField[0]));
                        //txtRecircPres.Text = sField(0)
                        //txtCalRecCurrent.Text = (sField(0))
                    }
                    else if (System.Convert.ToBoolean((sField[1]).IndexOf("E") + 1))
                    {
                        MessageBox.Show(string.Format("current aux temp{0}", sField[0]));
                    }
                    else if (System.Convert.ToBoolean((sField[1]).IndexOf("P") + 1))
                    {
                        //lblPreHeatTime.Text = "There is " & sField(0) & " Seconds of Preheat remaining"
                    }
                    else if (System.Convert.ToBoolean((sField[1]).IndexOf("Q") + 1))
                    {
                        //lblBypassTime.Text = "There is " & sField(0) & " Seconds of Bypass remaining"
                    }
                    else if (System.Convert.ToBoolean((sField[1]).IndexOf("S") + 1))
                    {
                        //    ushort Ddata1 = System.Convert.ToUInt16(Convert.ToInt32(Conversion.Val(sField[0])));
                        BitArray Xdata1;
                        //    Xdata1 = new BitArray(new int[] { Ddata1 });
                        //DisplayStatusBits(Xdata1)
                    }
                    else if (System.Convert.ToBoolean((sField[1]).IndexOf("W") + 1))
                    {
                        //    ushort Ddata2 = System.Convert.ToUInt16(Convert.ToInt32(Conversion.Val(sField[0])));
                        BitArray Xdata2;
                        //     Xdata2 = new BitArray(new int[] { Ddata2 });
                        //DisplayAlarmBits(Xdata2)
                    }
                    else if (System.Convert.ToBoolean((sField[1]).IndexOf("k") + 1))
                    {
                        string[] GraphSplit = sField[0].Split("-".ToCharArray());
                        if (GraphSplit.Length > 0)
                        {
                            float scratch;
                            float scratch2;
                            //     scratch = System.Convert.ToSingle(System.Convert.ToDouble(Conversion.Int(GraphSplit[0])) / 26.21);
                            //      scratch2 = System.Convert.ToSingle(System.Convert.ToDouble(Conversion.Int(GraphSplit[1])) / 26.21);
                            //place holder for graphing returned pressure data
                        }
                    }
                    else
                    {
                        //AddToListBox("Data ")
                        if (System.Convert.ToBoolean(currentMessage.IndexOf(" ") + 1))
                        {
                            currentMessage = currentMessage.Substring(0, currentMessage.IndexOf(" ") + 0);
                        }
                        //data process here
                    }
                }
            }
        }





    }
}
