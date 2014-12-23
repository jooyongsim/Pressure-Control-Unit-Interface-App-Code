using System;
using System.Text;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
//*****************************************************************************************
//                           LICENSE INFORMATION
//*****************************************************************************************
//   PCCom.SerialCommunication Version 1.0.0.0
//   Class file for managing serial port communication
//   
//   Copyright (C) 2007  
//   Richard L. McCutchen 
//   Email: richard@psychocoder.net
//   Created: 20OCT07
//
//   This program is free software: you can redistribute it and/or modify
//   it under the terms of the GNU General Public License as published by
//   the Free Software Foundation, either version 3 of the License, or
//   (at your option) any later version.
//
//   This program is distributed in the hope that it will be useful,
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//   GNU General Public License for more details.
//
//   You should have received a copy of the GNU General Public License
//   along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
//   Edited by Alexander Gonzalez on July 6, 2010
//

//*****************************************************************************************
namespace ValveControl
{
    
    class CommunicationManager
    {
        
        #region Manager Variables
        //property variables
        private string _baudRate = string.Empty;
        private string _parity = string.Empty;
        private string _stopBits = string.Empty;
        private string _dataBits = string.Empty;
        private string _portName = string.Empty;
        private string _data = string.Empty;
        private string _samplerate = string.Empty;
        private string _datastring = string.Empty;
        private int _bytesinbuffer = 0;
        public SerialPort comPort = new SerialPort();
        #endregion

        #region Manager Properties

        /// <summary>
        /// Property to hold the BaudRate
        /// of our manager class
        /// </summary>
        public string BaudRate
        {
            get { return _baudRate; }
            set { _baudRate = value; }
        }

        /// <summary>
        /// property to hold the Parity
        /// of our manager class
        /// </summary>
        public string Parity
        {
            get { return _parity; }
            set { _parity = value; }
        }

        /// <summary>
        /// property to hold the StopBits
        /// of our manager class
        /// </summary>
        public string StopBits
        {
            get { return _stopBits; }
            set { _stopBits = value; }
        }

        /// <summary>
        /// property to hold the DataBits
        /// of our manager class
        /// </summary>
        public string DataBits
        {
            get { return _dataBits; }
            set { _dataBits = value; }
        }

        /// <summary>
        /// property to hold the PortName
        /// of our manager class
        /// </summary>
        public string PortName
        {
            get { return _portName; }
            set { _portName = value; }
        }

        /// <summary>
        /// property that holds the data of the input buffer
        /// </summary
        public string DataIn
        {
            get { return _data; }
            set { _data = value; }
        }

        /// <summary>
        /// property that sets the sample rate
        /// </summary>
        public string SampleRate 
        {
            get { return _samplerate; }
            set { _samplerate = value; }
        }

        /// <summary>
        /// property that how much data to save
        /// </summary>
        public string DataString
        {
            get { return _datastring; }
            set { _datastring = value; }
        }

        public int BytesinBuffer
        {
            get { return _bytesinbuffer; }
            set { _bytesinbuffer = value; }
        }

        #endregion

        #region Manager Constructors
        /// <summary>
        /// Constructor to set the properties of our Manager Class
        /// </summary>
        /// <param name="baud">Desired BaudRate</param>
        /// <param name="par">Desired Parity</param>
        /// <param name="sBits">Desired StopBits</param>
        /// <param name="dBits">Desired DataBits</param>
        /// <param name="name">Desired PortName</param>
        public CommunicationManager(string baud, string par, string sBits, string dBits, string name, RichTextBox rtb, string SRate, string Dstring)
        {
            _baudRate = baud;
            _parity = par;
            _stopBits = sBits;
            _dataBits = dBits;
            _portName = name;
            _samplerate = SRate;
            _datastring = Dstring;
            
        }

        /// <summary>
        /// Comstructor to set the properties of our
        /// serial port communicator to nothing
        /// </summary>
        public CommunicationManager()
        {
            _baudRate = string.Empty;
            _parity = string.Empty;
            _stopBits = string.Empty;
            _dataBits = string.Empty;
            _portName = "COM8";
            _samplerate = string.Empty;
            _datastring = string.Empty;
            
        }
        #endregion

        #region OpenPort
        public bool OpenPort()
        {
            try
            {
                //first check if the port is already open
                //if its open then close it
                if (comPort.IsOpen == true) comPort.Close();

                //set the properties of our SerialPort Object
                comPort.BaudRate = int.Parse(_baudRate);    //BaudRate
                comPort.DataBits = int.Parse(_dataBits);    //DataBits
                comPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), _stopBits);    //StopBits
                comPort.Parity = (Parity)Enum.Parse(typeof(Parity), _parity);    //Parity
                comPort.PortName = _portName;   //PortName
                //now open the port
                comPort.Open();
                //display message
               
                return true;
            }
            catch 
            {   
                return false;
            }
        }
        #endregion

        #region ClosePort

        public void ClosePort()
        {
            if (comPort.IsOpen == true)
            {
                BytesinBuffer = comPort.BytesToRead;
                comPort.DiscardOutBuffer();
                comPort.Close();
            }
        }

        #endregion

        #region SetParityValues
        public void SetParityValues(object obj)
        {
            foreach (string str in Enum.GetNames(typeof(Parity)))
            {
                ((ComboBox)obj).Items.Add(str);
            }
        }
        #endregion

        #region SetStopBitValues
        public void SetStopBitValues(object obj)
        {
            foreach (string str in Enum.GetNames(typeof(StopBits)))
            {
                ((ComboBox)obj).Items.Add(str);
            }
        }
        #endregion

        #region SetPortNameValues
        public void SetPortNameValues(object obj)
        {

            foreach (string str in SerialPort.GetPortNames())
            {
                ((ComboBox)obj).Items.Add(str);
            }
        }
        #endregion

        #region Set Sampling Rate
        public void SetSamplingRate(object obj)
        {
            string[] rates = { "100ms", "50ms", "10ms", "5ms", "1ms"};
            foreach (string str in rates)
            {
                ((ComboBox)obj).Items.Add(str);
            }
        }

        #endregion

        #region Set DataString
        public void SetDataString(object obj)
        {

            string[] Datastring = { "5min", "1min", "30s", "10s"};
            foreach (string str in Datastring)
            {
                ((ComboBox)obj).Items.Add(str);
            }
        }

        #endregion

        


    }
}
