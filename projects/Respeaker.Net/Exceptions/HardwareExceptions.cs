namespace Respeaker.Net.Exceptions;

/// <summary>thrown if there was a device detected that is not (currently) supported or completly unknown</summary>
public class UnknownDeviceException : Exception
{
    /// <inheritdoc cref="UnknownDeviceException"/>>
    public UnknownDeviceException(string deviceType) : base(ExceptionMessages.UnknownDevice.Replace("{NAME}", deviceType)) { }
}

/// <summary>thrown if the usb device was not found</summary>
public class UsbDeviceNotFoundException : Exception
{
    /// <inheritdoc cref="UsbDeviceNotFoundException"/>>
    public UsbDeviceNotFoundException(string deviceName) : base(ExceptionMessages.DeviceNotFound.Replace("{NAME}", deviceName)) { }
}

/// <summary>thrown if something went wrong while communication with the usb device</summary>
public class UsbControlTransferFailedException : Exception
{
    readonly string _message;

    /// <inheritdoc cref="Message"/>
    public override string Message => _message;

    /// <inheritdoc cref="UsbControlTransferFailedException"/>
    public UsbControlTransferFailedException(byte request, int command, byte[] data, Exception originalException)
    {
        _message = ExceptionMessages.ControlTransferFailed
            .Replace("{REQUEST}", request.ToString("X"))
            .Replace("{COMMAND}", command.ToString("X"))
            .Replace("{PAYLOAD}", Convert.ToBase64String(data))
            .Replace("{MESSAGE}", originalException.Message);
    }

    /// <inheritdoc cref="UsbControlTransferFailedException"/>
    public UsbControlTransferFailedException(int command, int index, Exception originalException)
    {
        _message = ExceptionMessages.ControlTransferFailed
            .Replace("{REQUEST}", "READ")
            .Replace("{COMMAND}", command.ToString())
            .Replace("{PAYLOAD}", index.ToString())
            .Replace("{MESSAGE}", originalException.Message);
    }
}