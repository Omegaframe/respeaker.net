using System;

namespace Respeaker.Net.Exceptions
{
    public class UsbDeviceNotFoundException : Exception
    {
        readonly string _message;
        public override string Message => _message;

        public UsbDeviceNotFoundException(string deviceName)
        {
            _message = ExceptionMessages.DeviceNotFound
                 .Replace("{NAME}", deviceName);
        }
    }

    public class UsbControlTransferFailedException : Exception
    {
        readonly string _message;
        public override string Message => _message;

        public UsbControlTransferFailedException(byte request, int command, byte[] data, Exception originalException)
        {
            _message = ExceptionMessages.ControlTransferFailed
                 .Replace("{REQUEST}", request.ToString("X"))
                 .Replace("{COMMAND}", command.ToString("X"))
                 .Replace("{PAYLOAD}", Convert.ToBase64String(data))
                 .Replace("{MESSAGE}", originalException.Message);
        }

        public UsbControlTransferFailedException(int command, int index, Exception originalException)
        {
            _message = ExceptionMessages.ControlTransferFailed
                 .Replace("{REQUEST}", "READ")
                 .Replace("{COMMAND}", command.ToString())
                 .Replace("{PAYLOAD}", index.ToString())
                 .Replace("{MESSAGE}", originalException.Message);
        }
    }
}
