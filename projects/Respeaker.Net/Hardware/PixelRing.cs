using Device.Net;
using Device.Net.LibUsb;
using LibUsbDotNet.Main;
using System;
using System.Linq;

namespace Respeaker.Net.Hardware
{
    public class PixelRing : IDisposable
    {
        readonly LibUsbDevice _usbDevice;

        internal PixelRing(LibUsbDevice usbDevice)
        {
            _usbDevice = usbDevice;
        }

        /// <summary>
        /// trace mode, LEDs changing depends on VAD and DOA
        /// </summary>
        public void Trace()
        {
            Write(0, new byte[] { 0 });
        }

        /// <summary>
        /// mono mode, set all RGB LED to a single color.
        /// for example Red(0xFF0000), Green(0x00FF00) Blue(0x0000FF)
        /// </summary>
        /// <param name="color">Color as 6 Part Hexadecimal Value</param>
        public void Mono(int color)
        {
            if (color < 0 || color > 0xFFFFFF)
                throw new ArgumentOutOfRangeException($"The given color value is out of bounds: {color} Allowed Range: 0x000000 - 0xFFFFFF");

            Write(0, new byte[] { (byte)((color >> 16) & 0xFF), (byte)((color >> 8) & 0xFF), (byte)(color & 0xFF), 0 });
        }

        /// <summary>
        /// turn off all leds
        /// </summary>
        public void Off()
        {
            Mono(0);
        }

        /// <summary>
        /// listen mode, similar with trace mode, but not turn LEDs off
        /// </summary>
        public void Listen()
        {
            Write(2, new byte[] { 0 });
        }

        /// <summary>
        /// speak mode
        /// </summary>
        public void Speak()
        {
            Write(3, new byte[] { 0 });
        }

        /// <summary>
        /// wait mode
        /// </summary>
        public void Think()
        {
            Write(4, new byte[] { 0 });
        }

        /// <summary>
        /// spin mode
        /// </summary>
        public void Spin()
        {
            Write(5, new byte[] { 0 });
        }

        /// <summary>
        /// custom mode, set each LED to its own color
        /// </summary>
        /// <param name="colors">array of colors to set each in 6 part hexadecimal format. must be exactly 12 (one per led)</param>
        public void Custom(int[] colors)
        {
            if (colors.Length != 12)
                throw new ArgumentOutOfRangeException($"provided {colors.Length} custom colors. Expected exactly 12");

            if (colors.Any(color => color < 0 || color > 0xFFFFFF))
                throw new ArgumentOutOfRangeException($"One of the color values is out of bounds. Allowed Range: 0x000000 - 0xFFFFFF");

            var colorData = colors.SelectMany(color => new byte[] { (byte)((color >> 16) & 0xFF), (byte)((color >> 8) & 0xFF), (byte)(color & 0xFF), 0 }).ToArray();
            Write(6, colorData);
        }

        /// <summary>
        /// set brightness
        /// </summary>
        /// <param name="brightness">brightness with range: 0x00 - 0x1F</param>
        public void SetBrightness(int brightness)
        {
            if (brightness < 0 || brightness > 0x1F)
                throw new ArgumentOutOfRangeException($"The given brightness value is out of bounds: {brightness} Allowed Range: 0 - 0x1F");

            Write(0x20, new byte[] { (byte)brightness });
        }

        /// <summary>
        /// set color palette to use together with e.g. Think()
        /// </summary>
        /// <param name="a">start color in 6 part hexadecimal format (0xFF0000)</param>
        /// <param name="b">end color in 6 part heyadecimal format(0x00FF00)</param>
        public void SetColorPalette(int a, int b)
        {
            if (a < 0 || a > 0xFFFFFF)
                throw new ArgumentOutOfRangeException($"The given color value for palette a is out of bounds: {a} Allowed Range: 0x000000 - 0xFFFFFF");

            if (b < 0 || b > 0xFFFFFF)
                throw new ArgumentOutOfRangeException($"The given color value for plaette b is out of bounds: {b} Allowed Range: 0x000000 - 0xFFFFFF");

            Write(0x21, new byte[] { (byte)((a >> 16) & 0xFF), (byte)((a >> 8) & 0xFF), (byte)(a & 0xFF), 0, (byte)((b >> 16) & 0xFF), (byte)((b >> 8) & 0xFF), (byte)(b & 0xFF), 0 });
        }

        /// <summary>
        /// set center led state
        /// </summary>
        /// <param name="state">on, off or depend on VAD</param>
        public void SetVadLed(VadLedState state)
        {
            Write(0x22, new byte[] { (byte)state });
        }

        /// <summary>
        /// volume mode, range: 0 - 12
        /// </summary>
        /// <param name="volume">volume in range 0 - 12</param>
        public void Volume(int volume)
        {
            if (volume < 0 || volume > 0x1F)
                throw new ArgumentOutOfRangeException($"The given volume value is out of bounds: {volume} Allowed Range: 0 - 12");

            Write(0x23, new byte[] { (byte)volume });
        }

        public void Dispose()
        {
            _usbDevice?.Dispose();
        }

        void Write(int command, byte[] data)
        {
            var setupPacket = new UsbSetupPacket(
                CTRL_OUT | CTRL_TYPE_VENDOR | CTRL_RECIPIENT_DEVICE,
                0,
                command,
                0x1C,
                data.Length);

            _usbDevice.UsbDevice.ControlTransfer(ref setupPacket, data, data.Length, out _);
        }

        internal static FilterDeviceDefinition UsbDefinition => new FilterDeviceDefinition
        {
            DeviceType = DeviceType.Usb,
            Label = "Pixel Ring",
            VendorId = 0x2886,
            ProductId = 0x0018
        };

        const byte CTRL_OUT = 0x00;
        const byte CTRL_TYPE_VENDOR = 2 << 5;
        const byte CTRL_RECIPIENT_DEVICE = 0;
    }

    public enum VadLedState
    {
        Off = 0,
        On = 1,
        DependOnVad = 2
    }
}
