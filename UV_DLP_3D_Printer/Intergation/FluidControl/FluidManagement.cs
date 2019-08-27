using System;
using System.Collections;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;
using System.Text;
using UV_DLP_3D_Printer.Configs;

namespace UV_DLP_3D_Printer.Integration.FluidManagement
{
    public partial class FluidClass
    {

        // Creates and initializes a new Queue.
        private Queue MessageQueue = new Queue();
        private string ActiveCommand="";
        private bool serialActive;
        public SerialPort SerialPort1 = new SerialPort();
        private string ReceiveBuffer;
        private int timeoutCount = 0;
        private bool timedOut;
        //startup and intialise variables
        public string INIFilePath;
        //public string serialComPort = "COM1";
        //public string serialBaudRate = "9600";
        //public string serialDataBits = "8";
        //public string serialParity = "0";
        //public string serialStopBits = "1";

        public void ReadInINI()
        {
            //serialComPort = WindowsApplication1.INIAccess.INIRead(INIFilePath, "CommSettings", "PLC_ComPort", "COM1");
        }

        public void SaveToIni()
        {
           // WindowsApplication1.INIAccess.INIWrite(INIFilePath, "CommSettings", "PLC_ComPort", serialComPort);
        }

        public void connect_Click(System.Object sender, System.EventArgs e)
        {
            //openComms(serialComPort);

        }

        //openComms is private by default
        public void openComms(ConnectionConfig config)
        {
            if (SerialPort1.IsOpen == false)
            {
                SerialPort1.PortName = config.comname;/// serialComPort;
                SerialPort1.BaudRate = config.speed;// 19200;
                SerialPort1.Parity = config.parity;// Parity.None;
                SerialPort1.DataBits = config.databits;// 8;
                SerialPort1.StopBits = config.stopbits;// StopBits.One;
                //add data handler thread
                SerialPort1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

                try
                {
                    SerialPort1.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (SerialPort1.IsOpen)
                {
                    //connect.Enabled = false;
                    //disconnect.Enabled = true;
                    //TimerPoll.Enabled = true;
                }
            }
            //test
            AddData("STA?");
            //load current data on startup
            //AddData("SVP?");
            //AddData("SRS?");
            //AddData("SV2?");

        }

        public void disconnect_Click(System.Object sender, System.EventArgs e)
        {
            SerialPort1.DataReceived -= DataReceivedHandler; //detach event handler
            SerialPort1.Close();
            //disconnect.Enabled = false;
            //connect.Enabled = true;
            //TimerPoll.Enabled = false;
            MessageQueue.Clear();
        }

        public void temp_disconnect()
        {
            SerialPort1.DataReceived -= DataReceivedHandler; //detach event handler
            SerialPort1.Close();
            MessageQueue.Clear();
        }

        ~FluidClass()
        {
            SerialPort1.DataReceived -= DataReceivedHandler; //detach event handler
            SerialPort1.Close();

        }

        public string SerialWrite(string dataToSend)
        {
            string returnValue = "";

            //   if (!SerialPort1.IsOpen)
            //       SerialPort1.Open();

            string IDSstring;

            IDSstring = string.Format(dataToSend + "\r");

            if (SerialPort1.IsOpen)
            {
                //    SerialPort1.DiscardOutBuffer();
                for (int i = 0; i < IDSstring.Length; i++)
                {
                    SerialPort1.Write(IDSstring.Substring(i, 1));
                    Thread.Sleep(3);
                }
                Thread.Sleep(10);
                returnValue = "OK";
            }
            else
            {
                returnValue = "PORTCLOSED";
            }
            return returnValue;
        }

        public void cmboComPort_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (SerialPort1.IsOpen == true)
            {
                SerialPort1.Close();
                //disconnect.Enabled = false;
                //connect.Enabled = true;
            }
            //serialComPort = System.Convert.ToString("COM4");
            //SerialPort1.PortName = serialComPort;
        }

        private void getSerialPorts()
        {
            // Get a list of serial port names.
            string[] ports = SerialPort.GetPortNames();
            int SelectedPort = 0;

            // Put each port name Into a comboBox control.
            string port = "";
            foreach (string tempLoopVar_port in ports)
            {
                port = tempLoopVar_port;
                //cmboComPort.Items.Add(port);
                //if (port == serialComPort)
                {
                    //cmboComPort.Text = port;
                }
            }

        }


        //Temp_getSerialPorts should be private
        public void Temp_getSerialPorts()
        {
            //get a list of serial port names 
            string[] ports = SerialPort.GetPortNames();
            int SelectedPort = 0;
            //Show the list of port name into consol 
            string port = "";
            int i = 0;
            foreach (string tempLoopVar_port in ports)
            {
                port = tempLoopVar_port;
                Console.WriteLine("serial port number : {0} name: {1}", i, port);
                i++;
            }
            if (ports.Length>0)
            {
                Console.WriteLine(" choose the port number :");
                string input = Console.ReadLine();
                Int32.TryParse(input, out i);
                //i = Console.Read();
                Console.WriteLine("port chosen: {0}", i);
                Console.WriteLine("port name: {0}", ports[0]);
                //serialComPort = ports[i];
            }
            else
            {
                Console.WriteLine("No available port for fluid supply system");
            }
        }

        public void FluidManagement_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Are you sure you want to Exit?", "Exit Software", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                SaveToIni();
                e.Cancel = false;
            }


        }

        public void FluidManagement_Load(object sender, System.EventArgs e)
        {
            INIFilePath = Application.StartupPath + "\\setup.ini";
            ReadInINI();
            getSerialPorts();
            //openComms(serialComPort);
        }

        public void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            //SerialPort sp = (SerialPort)sender;
            int Count = SerialPort1.BytesToRead;
            byte[] Buffer = new byte[Count];
            SerialPort1.Read(Buffer, 0, Count);
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
                        //this.Invoke(new MyDel(Process_serial), ReceiveBuffer);
                        Process_serial(ReceiveBuffer);

                    }
                    catch
                    {

                    }
                    ReceiveBuffer = "";
                }
            }
        }

        delegate void MyDel(string currentMessage);

        public void Process_serial(string currentMessage)
        {
            if (currentMessage.Length > 0) //stips blank string
            {
                //Split out the fields
                string[] sField = currentMessage.Split(",".ToCharArray());
                if (sField.Length > 1)
                {
                    // AddToListBox(currentMessage);
                    Console.WriteLine(currentMessage);

                    if (System.Convert.ToBoolean((sField[1]).IndexOf("C") + 1))
                    {
                        //timeoutCount = 0;
                        //    cmdTimeOut.Enabled = false;
                        if (System.Convert.ToBoolean((sField[0]).IndexOf("?") + 1))
                        {
                            //       AddToListBox(currentMessage);

                            //resend + count

                            //       AddToListBox("Command failed ");
                        }
                        else
                        {   //in network mode remove header tag
                            Console.WriteLine("");
                            string[] idTag = ActiveCommand.Split(",?".ToCharArray());
                            if (idTag[0].Length > 3)
                            {
                                //           AddToListBox("Response on NetworkNode:" + ActiveCommand.Substring(0, 1));
                                Console.WriteLine("Response on NetworkNode: {0}", ActiveCommand.Substring(0, 1));
                                ActiveCommand = ActiveCommand.Substring(1);
                            }
                            else
                                Console.WriteLine("Non Network Response");
                            //           AddToListBox("Non Network Response:");
                            //       AddToListBox(currentMessage);
                            switch (ActiveCommand.Substring(0, 4))
                                {
                                    case "SA1?": //GET ALARM STATUS
                                        ushort Ddata1_1 = ushort.Parse(sField[0]);
                                        BitArray Xdata1_1;
                                        //Xdata1_1 = new BitArray(new int[] { Ddata1_1 });
                                        break;
                                    // DisplayAlarmBits(Xdata1)

                                    case "SVP?": //GET VACUUM PRESSURE
                                                 //               parameterUpdater1.dataValue = sField[0];
                                    break;
                                    case "SPP?": //GET PURGE PRESSURE
                                                 //  textBox.Text = sField[0];
                                        break;
                                    case "SPH?": //GET PREHEAT TIME
                                                 //  textBox.Text = sField[0];
                                        break;
                                    case "SBT?": //GET BYPASS TIME
                                                 //  textBox.Text = sField[0];
                                        break;
                                    case "SPT?": //GET PURGE TIME
                                                 //  textBox.Text = sField[0];
                                        break;
                                    case "SRS?": //GET RECIRC SPEED
                                                 //               parameterUpdater2.dataValue = sField[0];
                                        break;
                                    case "SHT?": //GET TANK TEMP
                                                 //  textBox.Text = sField[0];
                                        break;
                                    case "SH2?": //GET heater 2 temp
                                                 //  textBox.Text = sField[0];
                                        break;
                                    case "SEB?": //GET CURRENT ENABLED BITS
                                        //ushort Ddata1 = ushort.Parse(sField[0]);
                                        BitArray Xdata1;
                                        //Xdata1 = new BitArray(new int[] { Ddata1 });
                                        break;
                                    //  DisplayEnableBits(Xdata1)
                                    case "SVN?": //GET firmware version number
                                                 //  textBox.Text = sField[0];
                                        break;
                                    //  lblFirmware.Text = "V" & sField[0];
                                    case "SSN?": //get unit serial numb
                                                 //  textBox.Text = sField[0];
                                        break;
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
                            //           AddToListBox("Completed");
                        }
                        Console.WriteLine("Queue depth:{0}", MessageQueue.Count);

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
                        Console.WriteLine("current meniscus{0}", sField[0]);
                        // txtCalMenCurrent.Text = (sField(0))
                        // txtLivePressure.Text = Str(Val(sField(0)))
                        // txtRecircSensCal.Text = Str(Val(sField(0)))
                    }
                    else if (System.Convert.ToBoolean((sField[1]).IndexOf("T") + 1))
                    {
                        Console.WriteLine("current Tank temp{0}", sField[0]);
                        //txtLiveTankTemp.Text = sField(0)
                    }
                    else if (System.Convert.ToBoolean((sField[1]).IndexOf("R") + 1))
                    {
                        Console.WriteLine("current Recirc{0}", sField[0]);
                        //txtRecircPres.Text = sField(0)
                        //txtCalRecCurrent.Text = (sField(0))
                    }
                    else if (System.Convert.ToBoolean((sField[1]).IndexOf("E") + 1))
                    {
                        Console.WriteLine("current aux temp{0}", sField[0]);
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

        public void AddData(string data)
        {
            if (!SerialPort1.IsOpen)
            {
                try
                {
                    SerialPort1.Open();
                }
                catch
                {
                    Console.WriteLine("Port is closed or does not exist");
                }
            }
            if (SerialPort1.IsOpen)
            {
                timedOut = false;
                MessageQueue.Enqueue(data);
                Console.WriteLine("addData function data: {0}", data);
                Console.WriteLine("ActiveCommand : {0}", ActiveCommand);
                if (!serialActive)
                {
                    SendNextMessage();
                }
            }
        }

        private string SendNextMessage()
        {
            string returnValue = "";
            //   this.txtMessages.Text = System.Convert.ToString(MessageQueue.Count);
            if (MessageQueue.Count > 0)
            {
                serialActive = true;
                ActiveCommand = System.Convert.ToString(MessageQueue.Dequeue());
                //       cmdTimeOut.Enabled = true;
                SerialWrite(ActiveCommand);
                returnValue = "OK";
            }
            else
            {
                returnValue = "SEQCOMP";
                serialActive = false;
            }
            return returnValue;
        }

        public void setMeniscus(int pressureMH2O)
        {
            // string pressure = Convert.ToString(pressureMH2O);
            string data = "SVP," + Convert.ToString(pressureMH2O) + "\r";
            AddData(data);
        }

        public void readMeniscus()
        {
            string data = "SVP?\r";
            //Process_serial(data);
            AddData(data);
        }

        public void setPurgePressure(int PurgePressure)
        {
            string data = "SPP," + Convert.ToString(PurgePressure) + "\r";
            AddData(data);
        }
        public void setPurgeTime(int PurgeTime)
        {
            string data = "SPT," + Convert.ToString(PurgeTime) + "\r";
            AddData(data);
        }
        public void PurgeCommand(int PurgeMode)
        {
            if (PurgeMode!=3)
            {
                string data = "STP," + Convert.ToString(PurgeMode) + "\r";
                AddData(data);
            }
        }
        public void enableSystemFunctionality(int function)
        {
            //enable ink is function = 1
            string data = "SEB," + Convert.ToString(function);// + "\r";
            Console.WriteLine("data: {0}",data);
            AddData(data);
            //Process_serial(data);            
        }
    }
}
