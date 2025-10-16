using System.Buffers;
using LibUsbDotNet;
using LibUsbDotNet.Main;
using Respeaker.Net.Exceptions;

namespace Respeaker.Net.Hardware;

static class UsbControl
{
    public static void WriteControlTransfer(int command, byte[] data, IUsbDevice usbDevice)
    {
        const byte request = (byte)(UsbCtrlFlags.Direction_Out | UsbCtrlFlags.RequestType_Vendor | UsbCtrlFlags.Recipient_Device);

        var setupPacket = new UsbSetupPacket(
            request,
            0,
            command,
            0x1C,
            data.Length);

        try
        {
            if (!usbDevice.ControlTransfer(ref setupPacket, data, data.Length, out _))
                throw new InvalidOperationException(ExceptionMessages.UnableToWriteConfigParameter);
        }
        catch (Exception ex)
        {
            throw new UsbControlTransferFailedException(request, command, data, ex);
        }
    }

    public static byte[] ReadControlTransfer(int command, int index, int length, IUsbDevice usbDevice)
    {
        const byte request = (byte)(UsbCtrlFlags.Direction_In | UsbCtrlFlags.RequestType_Vendor | UsbCtrlFlags.Recipient_Device);

        var setupPacket = new UsbSetupPacket(
            request,
            0,
            command,
            index,
            length);

        var buffer = ArrayPool<byte>.Shared.Rent(length);

        try
        {
            if (!usbDevice.ControlTransfer(ref setupPacket, buffer, buffer.Length, out var readed))
                throw new InvalidOperationException(ExceptionMessages.UnableToReadConfigParameter);

            return buffer[..readed];
        }
        catch (Exception ex)
        {
            throw new UsbControlTransferFailedException(command, index, ex);
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }
}