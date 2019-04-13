using System;
using System.IO.Ports;

namespace ArduinoListener
{
    static class Program
    {
        static void Main(string[] args)
        {
            //sqllite
            foreach (string s in SerialPort.GetPortNames())
            {
                Console.WriteLine("   {0}", s);
            }

            var listener = new SerialPortListener("com3", 9600);
            listener.MessageReceived += ListenerMessageReceived;

            listener.Start();

            Console.ReadLine();

            listener.Stop();
        }

        private static void ListenerMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
