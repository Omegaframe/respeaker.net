using Device.Net;
using Device.Net.LibUsb;
using Respeaker.Net.Exceptions;
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
            UsbControl.WriteControlTransfer(0, new byte[] { 0 }, _usbDevice);
        }

        /// <summary>
        /// mono mode, set all RGB LED to a single color.
        /// for example Red(0xFF0000), Green(0x00FF00) Blue(0x0000FF)
        /// </summary>
        /// <param name="color">Color as 6 Part Hexadecimal Value</param>
        public void Mono(int color)
        {
            const int minColor = 0x000000;
            const int maxColor = 0xFFFFFF;

            if (color < minColor || color > maxColor)
                throw new RespeakerArgumentOutOfRangeException($"The given color value is out of bounds: {color} Allowed Range: {minColor:X} - {maxColor:X}");

            UsbControl.WriteControlTransfer(0, HexColorToByteArray(color), _usbDevice);
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
            UsbControl.WriteControlTransfer(2, new byte[] { 0 }, _usbDevice);
        }

        /// <summary>
        /// speak mode
        /// </summary>
        public void Speak()
        {
            UsbControl.WriteControlTransfer(3, new byte[] { 0 }, _usbDevice);
        }

        /// <summary>
        /// wait mode
        /// </summary>
        public void Think()
        {
            UsbControl.WriteControlTransfer(4, new byte[] { 0 }, _usbDevice);
        }

        /// <summary>
        /// spin mode
        /// </summary>
        public void Spin()
        {
            UsbControl.WriteControlTransfer(5, new byte[] { 0 }, _usbDevice);
        }

        /// <summary>
        /// custom mode, set each LED to its own color
        /// </summary>
        /// <param name="colors">array of colors to set each in 6 part hexadecimal format. must be exactly 12 (one per led)</param>
        public void Custom(int[] colors)
        {
            const int expectedColors = 12;
            const int minColor = 0x000000;
            const int maxColor = 0xFFFFFF;

            if (colors.Length != expectedColors)
                throw new RespeakerArgumentOutOfRangeException($"provided {colors.Length} custom colors. Expected exactly {expectedColors}");

            if (colors.Any(color => color < minColor || color > maxColor))
                throw new RespeakerArgumentOutOfRangeException($"One of the color values is out of bounds. Allowed Range: {minColor:X} - {maxColor:X}");

            var colorData = colors.SelectMany(color => HexColorToByteArray(color)).ToArray();
            UsbControl.WriteControlTransfer(6, colorData, _usbDevice);
        }

        /// <summary>
        /// set brightness
        /// </summary>
        /// <param name="brightness">brightness with range: 0x00 - 0x1F</param>
        public void SetBrightness(int brightness)
        {
            const int minBrightness = 0;
            const int maxBrightness = 0x1F;

            if (brightness < 0 || brightness > 0x1F)
                throw new RespeakerArgumentOutOfRangeException($"The given brightness value is out of bounds: {brightness} Allowed Range: {minBrightness:X} - {maxBrightness:X}");

            UsbControl.WriteControlTransfer(0x20, new byte[] { (byte)brightness }, _usbDevice);
        }

        /// <summary>
        /// set color palette to use together with e.g. Think()
        /// </summary>
        /// <param name="a">start color in 6 part hexadecimal format (0xFF0000)</param>
        /// <param name="b">end color in 6 part heyadecimal format(0x00FF00)</param>
        public void SetColorPalette(int a, int b)
        {
            const int minColor = 0x000000;
            const int maxColor = 0xFFFFFF;

            if (a < minColor || a > maxColor)
                throw new RespeakerArgumentOutOfRangeException($"The given color value for palette a is out of bounds: {a} Allowed Range: {minColor:X} - {maxColor:X}");

            if (b < minColor || b > maxColor)
                throw new RespeakerArgumentOutOfRangeException($"The given color value for plaette b is out of bounds: {b} Allowed Range: {minColor:X} - {maxColor:X}");

            UsbControl.WriteControlTransfer(0x21, HexColorToByteArray(a).Concat(HexColorToByteArray(b)).ToArray(), _usbDevice);
        }

        /// <summary>
        /// set center led state
        /// </summary>
        /// <param name="state">on, off or depend on VAD</param>
        public void SetVadLed(VadLedState state)
        {
            UsbControl.WriteControlTransfer(0x22, new byte[] { (byte)state }, _usbDevice);
        }

        /// <summary>
        /// volume mode, range: 0 - 12
        /// </summary>
        /// <param name="volume">volume in range 0 - 12</param>
        public void Volume(int volume)
        {
            const int minVolume = 0;
            const int maxVolume = 0x1F;

            if (volume < minVolume || volume > maxVolume)
                throw new RespeakerArgumentOutOfRangeException($"The given volume value is out of bounds: {volume} Allowed Range: {minVolume} - {maxVolume}");

            UsbControl.WriteControlTransfer(0x23, new byte[] { (byte)volume }, _usbDevice);
        }

        public void Dispose()
        {
            _usbDevice?.Dispose();
        }

        static byte[] HexColorToByteArray(int color)
        {
            return new byte[] 
            { 
                (byte)((color >> 16) & 0xFF), 
                (byte)((color >> 8) & 0xFF), 
                (byte)(color & 0xFF), 
                0
            };
        }

        internal static FilterDeviceDefinition UsbDefinition => new FilterDeviceDefinition
        {
            DeviceType = DeviceType.Usb,
            Label = "Pixel Ring",
            VendorId = 0x2886,
            ProductId = 0x0018
        };       
    }

    public enum VadLedState
    {
        Off = 0,
        On = 1,
        DependOnVad = 2
    }
}
