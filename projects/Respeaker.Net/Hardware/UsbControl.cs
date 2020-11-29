using LibUsbDotNet;
using LibUsbDotNet.Main;
using Respeaker.Net.Exceptions;
using System;
using System.Linq;

namespace Respeaker.Net.Hardware
{
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
                usbDevice.ControlTransfer(ref setupPacket, data, data.Length, out _);
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

            try
            {
                var buffer = new byte[length];

                if (!usbDevice.ControlTransfer(ref setupPacket, buffer, buffer.Length, out var readed))
                    throw new InvalidOperationException(ExceptionMessages.UnableToReadConfigParameter);

                return buffer.Take(readed).ToArray();
            }
            catch (Exception ex)
            {
                throw new UsbControlTransferFailedException(command, index, ex);
            }
        }
    }
}
