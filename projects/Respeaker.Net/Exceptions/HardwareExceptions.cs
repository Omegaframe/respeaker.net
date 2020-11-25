using System;

namespace Respeaker.Net.Exceptions
{
    public class UsbControlTransferFailedException : Exception
    {
        readonly string _message;
        public override string Message => _message;

        public UsbControlTransferFailedException(byte request, int command, byte[] data, Exception originalException)
        {
            _message = ExceptionMessages.HardwareExceptionMessages.ControlTransferFailed
                 .Replace("{REQUEST}", request.ToString("X"))
                 .Replace("{COMMAND}", command.ToString("X"))
                 .Replace("{PAYLOAD}", Convert.ToBase64String(data))
                 .Replace("{MESSAGE}", originalException.Message);
        }
    }    
}
