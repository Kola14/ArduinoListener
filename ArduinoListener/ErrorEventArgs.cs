using System;

namespace ArduinoListener
{
    public class ErrorEventArgs: EventArgs
    {
        public string Message { get; }

        public ErrorEventArgs(string message)
        {
            Message = message;
        }
    }
}
