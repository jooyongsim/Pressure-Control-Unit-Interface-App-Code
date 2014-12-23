/* Valve Control and Communication GUI
 * 
 * This code is meant to be used with an arduino board. It enables the user a 
 * graphical interaction with the communication and control of valves.
 * Communication elements such as BAUD rate are easily accessible from the GUI.
 * A graph shows the current pressure as it is received
 * Access to a PID controller parametes is allowed and the target pressure 
 * can be either constant or varying.
 * 
 * The communication is done over a Serial port. 
 * 
 * Significant parts of this program are segments of open source code found over 
 * the internet. 
 * 
 */ 


// declares all the namespaces or libraries that the program will use
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using System.IO.Ports;
using System.Collections;
using System.Data.OleDb;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;

namespace ValveControl
{
    public partial class FormMain : Form
    {
        #region Global Variables

        int TimeStart, counter;
        double smplrate, inputDBuffer, PressurekPa, time;
        string RcvData, Amplitud, Frequency, DutyCycle, statusdata, buildstr, buildstr2;
        string PGain, IGain, DGain;
        bool RecevingPressure, cmdsent;

        #endregion

        #region MainCode

        // loads defaults and intializes the environment
        public FormMain()
        {
            InitializeComponent();
            LoadValues();
            SetDefaults();
            SetControlState();
        }

        // some default settings are loaded
        private void FormMain_Load(object sender, EventArgs e)
        {
            #region Graph Settings
            GraphPane myPane = zg1.GraphPane;
            myPane.Title.Text = "Test of Dynamic Data Update with ZedGraph\n" +
                  "(After 25 seconds the graph scrolls)";
            myPane.XAxis.Title.Text = "Time, Seconds";
            myPane.YAxis.Title.Text = "Pressure, kPa";

            ///allows the zedgraph function RollingPointPairList to know how many data points
            ///we are interested in having
            ///GrphDataPts allows the user to choose how many points to graph based on 
            ///sample rate and data buffer
            RollingPointPairList list = new RollingPointPairList(Convert.ToInt16(GrphDataPts()));

            // Initially, a curve is added with no data points (list is empty)
            // Color is blue, and there will be no symbols
            LineItem curve = myPane.AddCurve("Pressure", list, Color.Blue, SymbolType.None);

            // Just manually control the X axis range so it scrolls continuously
            // instead of discrete step-sized jumps
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 30;
            myPane.XAxis.Scale.MinorStep = 1;
            myPane.XAxis.Scale.MajorStep = 5;

            // Scale the axes
            zg1.AxisChange();
            #endregion
        }

        // this section executes every time there is a timer1 tick (1ms in this case)
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            // increases the counter
            counter++;

                #region GraphEvents
                // Make sure that the curvelist has at least one curve
                if (zg1.GraphPane.CurveList.Count <= 0)
                    return;

                // Get the first CurveItem in the graph
                LineItem curve = zg1.GraphPane.CurveList[0] as LineItem;
                if (curve == null)
                    return;

                // Get the PointPairList
                IPointListEdit list = curve.Points as IPointListEdit;
                // If this is null, it means the reference at curve.Points does not
                // support IPointListEdit, so we won't be able to modify it
                if (list == null)
                    return;
                Scale xScale = zg1.GraphPane.XAxis.Scale;

                // restarts the list and x axis 
                if (counter < 2)
                {
                    xScale.MinAuto = true;
                    list.Clear();
                }

                #endregion

                #region Graph Data Points

                // Time is measured in seconds 
                time = (Environment.TickCount - TimeStart) / 1000.0;

                // this section converts the data received into pressure and handles catches any exeption if the 
                // data received isn't in a readable format
                if (RcvData == null)
                    PressurekPa = 0;
                else
                {
                    try
                    {
                        PressurekPa = (Convert.ToSingle(RcvData) - 105) / 1024 * 5 / 0.267f / 0.14503773773021f;
                    }
                    catch { }
                }

                // shows in a text box the Pressure
                textBox1.Text = Convert.ToString(PressurekPa);
                textBox1.Show();

                // on each tick a new set of points is added to list (which holds the data points)
                list.Add(time, PressurekPa);
                
                #endregion

                #region GraphEvents2

                // Keep the X scale at a rolling 30 second interval, with one
                // major step between the max X value and the end of the axis
                if (time > xScale.Max - xScale.MajorStep)
                {
                    xScale.Max = time + xScale.MajorStep;
                    xScale.Min = xScale.Max - 30.0;
                }

                //Make sure the Y axis is rescaled to accommodate actual data
                zg1.AxisChange();
                //Force a redraw
                zg1.Invalidate();
                #endregion

        }

        // executes each time there is data received from the serial port
        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // this section decided what to do with the data received from the arduino
            // it also catches any exceptions related to wrong data format received 
            try
            {
                if (RecevingPressure == false && cmdsent == true)
                {
                    statusdata = Port.ReadTo("$");
                    this.Invoke(new EventHandler(DisplayText));
                }
                else if (RecevingPressure == true)
                    RcvData = Port.ReadTo("$");
                else
                    Port.DiscardInBuffer();
            }
            catch { }
        }

        #endregion

        #region Events Control

        // executes every time the user clicks the Open Port button
        private void cmdOpen_Click_1(object sender, EventArgs e)
        {
           
            #region Load User Inputs

            // loads the user inputs from Serial Communication Settings
            Port.PortName = cboPort.Text;
            Port.Parity = (Parity)Enum.Parse(typeof(Parity), cboParity.Text);
            Port.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cboStop.Text);
            Port.DataBits = Convert.ToInt16(cboData.Text);
            Port.BaudRate = Convert.ToInt16(cboBaud.Text);
            GrphDataPts();
            cboallowUserChanges();

            #endregion

            // Opens the Serial port for communication
            Port.Open();

            // enables or disable user interactions depending on the current state
            cmdOpen.Enabled = false;
            cmdClose.Enabled = true;
            cmdSend.Enabled = true;
            btoRcvData.Enabled = true;
        }

        // executes every time the user clicks the Send button
        private void cmdSend_Click_1(object sender, EventArgs e)
        {
            try
            {
                // reads the user inputs for the waveform 
                Amplitud = StrLengthSet(tbAmp.Text, 5);
                Frequency = StrLengthSet(tbFreq.Text, 5);
                DutyCycle = StrLengthSet(tbDutyCycle.Text, 5);

                // discards data from the buffer
                Port.DiscardInBuffer();
                Port.DiscardOutBuffer();

                // reads the waveform chosen and builds the string accordingly
                switch (cboInput.Text)
                {
                    case "Constant":
                        {
                            buildstr = "c" + Amplitud;
                            break;
                        }
                    case "Sine Waveform":
                        {
                            buildstr = "s" + Amplitud + Frequency;
                            break;
                        }
                    case "Rectangular Waveform":
                        {
                            buildstr = "r" + Amplitud + Frequency + DutyCycle;
                            break;
                        }
                }

                buildstr = buildstr.PadRight(16, '0');

                // writes the string to the arduino
                Port.WriteLine(buildstr);

                tbstatus.Text = "";

                // enables or disable user interactions depending on the current state
                cmdsent = true;
                cmdControl.Enabled = true;
                cmdSControl.Enabled = true;
            }

            catch
            {
                MessageBox.Show("Error");
            }

        }

        // executes every time the user clicks the Close Port button
        private void cmdClose_Click_1(object sender, EventArgs e)
        {
            if (RecevingPressure == false)
            {
                // enables or disable user interactions depending on the current state
                cmdOpen.Enabled = true;
                cmdClose.Enabled = false;
                cmdSend.Enabled = false;
                cmdControl.Enabled = false;
                btoRcvData.Enabled = false;
                cmdSControl.Enabled = false;

                // closes the serial port
                Port.Close();
                cboallowUserChanges();
                tbstatus.Text = "";
            }
        }

        // executes every time the user clicks the Receive Data button
        private void btoRcvData_Click(object sender, EventArgs e)
        {
            // re-initialize the counter
            counter = 0;

            #region Timer Settings

            // Sample at smplrates intervals, choosen by the user
            timer1.Interval = Convert.ToInt16(smplrate);
            timer1.Enabled = true;
            timer1.Start();

            TimeStart = Environment.TickCount;

            btoStopRcvData.Enabled = true;

            #endregion

            cmdsent = false;
            RecevingPressure = true;

            Port.DiscardOutBuffer();
            // the arduino code interprets the character e as a command to receive data
            Port.WriteLine("e");
            Port.DiscardInBuffer();

            // enables or disable user interactions depending on the current state
            btoStopRcvData.Enabled = true;
            btoRcvData.Enabled = false;
            cmdClose.Enabled = false;
            cmdSend.Enabled = false;

        }

        // executes every time the user clicks the Stop Receiving Data button
        private void btoStopRcvData_Click(object sender, EventArgs e)
        {
            Port.DiscardOutBuffer();

            // arduino interprets as stop sending data
            Port.WriteLine("f");

            // enables or disable user interactions depending on the current state
            btoRcvData.Enabled = true;
            btoStopRcvData.Enabled = false;
            cmdSend.Enabled = true;
            cmdClose.Enabled = true;

            timer1.Stop();
            RecevingPressure = false;
            Port.DiscardInBuffer();
            tbstatus.Text = "";
        }
        
        // executes each time the user changes the waveform type
        private void cboInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboInput.Text)
            {
                case "Constant":
                    {
                        tbFreq.ReadOnly = true;
                        tbFreq.Text = "";
                        tbDutyCycle.ReadOnly = true;
                        tbDutyCycle.Text = "";
                        break;
                    }
                case "Sine Waveform":
                    {
                        tbFreq.ReadOnly = false;
                        tbFreq.Text = "";
                        tbDutyCycle.ReadOnly = true;
                        tbDutyCycle.Text = "";
                        break;
                    }
                default:
                    {
                        tbFreq.ReadOnly = false;
                        tbDutyCycle.ReadOnly = false;
                        break;
                    }
            }
        }

        // executes every time the user clicks the Control button
        private void cmdControl_Click(object sender, EventArgs e)
        {
            // reads user settings for the control parameters from the GUI
            PGain = StrLengthSet(tboPGain.Text, 5);
            IGain = StrLengthSet(tboIGain.Text, 5);
            DGain = StrLengthSet(tboDGain.Text, 5);
             
            // builds a string with all the user inputs
            buildstr2 = "y" + PGain + IGain + DGain;
            Port.DiscardOutBuffer();

            // discards data in the input buffer if it is not pressure data
            if (RecevingPressure == false)
            {
                Port.DiscardInBuffer();
                cmdsent = true;
            }

            // writes a string to the with all the parameters
            Port.WriteLine(buildstr2);

            // enables or disable user interactions depending on the current state
            cmdSControl.Enabled = true;

        }

        // executes every time the user clicks Stop Control
        private void cmdSControl_Click(object sender, EventArgs e)
        {
            Port.DiscardOutBuffer();

            // command for stopping the calculation of the PID controller output
            Port.WriteLine("x");

            // enables or disable user interactions depending on the current state
            cmdSControl.Enabled = false;
        }

        #endregion

        #region Defaults

        // loads the possible inputs for the serial communication 
        private void SetParityValues(object obj)
        {
            foreach (string str in Enum.GetNames(typeof(Parity)))
            {
                ((ComboBox)obj).Items.Add(str);
            }
        }

        private void SetPortNameValues(object obj)
        {
            foreach (string str in SerialPort.GetPortNames())
            {
                ((ComboBox)obj).Items.Add(str);
            }
        }

        private void SetSamplingRate(object obj)
        {
            string[] rates = { "100ms", "50ms", "10ms", "5ms", "1ms" };
            foreach (string str in rates)
            {
                ((ComboBox)obj).Items.Add(str);
            }
        }

        private void SetDataString(object obj)
        {

            string[] Datastring = { "5min", "1min", "30s", "10s" };
            foreach (string str in Datastring)
            {
                ((ComboBox)obj).Items.Add(str);
            }
        }

        public void SetStopBitValues(object obj)
        {
            foreach (string str in Enum.GetNames(typeof(StopBits)))
            {
                ((ComboBox)obj).Items.Add(str);
            }
        }

        private void LoadValues()
        {
            SetPortNameValues(cboPort);
            SetParityValues(cboParity);
            SetStopBitValues(cboStop);
            SetDataString(cboDbuffer);
            SetSamplingRate(cboSamRate);
        }

        private void SetDefaults()
        {
            cboPort.SelectedIndex = 4;
            cboBaud.SelectedIndex = 5;
            cboParity.SelectedIndex = 0;
            cboStop.SelectedIndex = 1;
            cboData.SelectedIndex = 1;
            cboSamRate.SelectedIndex = 3;
            cboDbuffer.SelectedIndex = 1;
            cboInput.SelectedIndex = 0;
        }

        // function that determines the resolution of the graph
        private double GrphDataPts()
        {
            double[] rates = { 100, 50, 10, 5, 1 };
            smplrate = rates[cboSamRate.SelectedIndex];

            double[] length_buffer = { 300, 60, 30, 10 };
            inputDBuffer = length_buffer[cboDbuffer.SelectedIndex];

            double points = (inputDBuffer / smplrate) * 1000;
            return points;

        }

        // inital state
        private void SetControlState()
        {
            cmdSend.Enabled = false;
            cmdClose.Enabled = false;
            btoRcvData.Enabled = false;
            btoStopRcvData.Enabled = false;
            cmdControl.Enabled = false;
            cmdSControl.Enabled = false; 
        }

        #endregion

        #region Addional Functions
    
        // toogles some fields for read only or write 
        private void cboallowUserChanges()
        {
            cboPort.Enabled = !cboPort.Enabled;
            cboBaud.Enabled = !cboBaud.Enabled;
            cboData.Enabled = !cboData.Enabled;
            cboParity.Enabled = !cboParity.Enabled;
            cboSamRate.Enabled = !cboSamRate.Enabled;
            cboStop.Enabled = !cboStop.Enabled;
            cboDbuffer.Enabled = !cboDbuffer.Enabled;
        }

        // function for left padding with 0's
        private string StrLengthSet(string str, int length)
        {
            if(str.Length < length)
                str = str.PadLeft(length,'0');
            else if (str.Length > length)
                MessageBox.Show("Out of Range Input");

            return str;
        }

        private void DisplayText(object sender, EventArgs e)
        {
            tbstatus.AppendText(statusdata);
        }

        #endregion
    }
}