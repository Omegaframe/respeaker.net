using Device.Net.LibUsb;
using LibUsbDotNet.Main;
using Respeaker.Net.Exceptions;
using System;

namespace Respeaker.Net.Hardware
{
    static class UsbControl
    {
        const byte CTRL_OUT = 0x00;
        const byte CTRL_TYPE_VENDOR = 2 << 5;
        const byte CTRL_RECIPIENT_DEVICE = 0;

        public static void WriteControlTransfer(int command, byte[] data, LibUsbDevice usbDevice)
        {
            var request = (byte)(CTRL_OUT | CTRL_TYPE_VENDOR | CTRL_RECIPIENT_DEVICE);

            var setupPacket = new UsbSetupPacket(
                 request,
                 0,
                 command,
                 0x1C,
                 data.Length);

            try
            {
                usbDevice.UsbDevice.ControlTransfer(ref setupPacket, data, data.Length, out _);
            }
            catch (Exception ex)
            {
                throw new UsbControlTransferFailedException(request, command, data, ex);
            }
        }
    }
}
