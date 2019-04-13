using System;
using System.IO.Ports;
using System.Threading;

namespace ArduinoListener
{
    class SerialPortListener
    {
        private readonly string portName;
        private readonly int baudRate;

        private readonly SerialPort serialPort;

        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        public SerialPortListener(string portName, int baudRate)
        {
            this.portName = portName.ToLower();
            this.baudRate = baudRate;

            serialPort = new SerialPort(portName, baudRate);
        }

        public void Start()
        {
            serialPort.Open();
            var thread = new Thread(Listen);
            thread.Start();
        }

        private void Listen()
        {
            while (serialPort.IsOpen)
            {
                string message = serialPort.ReadLine();
                MessageReceived?.Invoke(this, new MessageReceivedEventArgs(message));
            }
        }

        public void Stop()
        {
            serialPort.Close();
        }
    }
}