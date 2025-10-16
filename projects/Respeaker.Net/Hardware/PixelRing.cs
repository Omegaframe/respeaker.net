using LibUsbDotNet;
using Respeaker.Net.Exceptions;

namespace Respeaker.Net.Hardware;

class PixelRing : ILedRing
{
    readonly IUsbDevice _usbDevice;

    internal PixelRing(IUsbDevice usbDevice)
    {
        _usbDevice = usbDevice;
    }

    public void Trace()
    {
        UsbControl.WriteControlTransfer(0, [0], _usbDevice);
    }

    public void Mono(int color)
    {
        const int minColor = 0x000000;
        const int maxColor = 0xFFFFFF;

        if (color is < minColor or > maxColor)
            throw new RespeakerArgumentOutOfRangeException($"The given color value is out of bounds: {color} Allowed Range: {minColor:X} - {maxColor:X}");

        UsbControl.WriteControlTransfer(1, HexColorToByteArray(color), _usbDevice);
    }

    public void Off()
    {
        Mono(0);
    }

    public void Listen()
    {
        UsbControl.WriteControlTransfer(2, [0], _usbDevice);
    }

    
    public void Speak()
    {
        UsbControl.WriteControlTransfer(3, [0], _usbDevice);
    }

    
    public void Think()
    {
        UsbControl.WriteControlTransfer(4, [0], _usbDevice);
    }

    
    public void Spin()
    {
        UsbControl.WriteControlTransfer(5, [0], _usbDevice);
    }

    public void Custom(int[] colors)
    {
        const int expectedColors = 12;
        const int minColor = 0x000000;
        const int maxColor = 0xFFFFFF;

        if (colors.Length != expectedColors)
            throw new RespeakerArgumentOutOfRangeException($"provided {colors.Length} custom colors. Expected exactly {expectedColors}");

        if (colors.Any(color => color < minColor || color > maxColor))
            throw new RespeakerArgumentOutOfRangeException($"One of the color values is out of bounds. Allowed Range: {minColor:X} - {maxColor:X}");

        var colorData = colors.SelectMany(HexColorToByteArray).ToArray();
        UsbControl.WriteControlTransfer(6, colorData, _usbDevice);
    }
    
    public void SetBrightness(int brightness)
    {
        const int minBrightness = 0;
        const int maxBrightness = 0x1F;

        if (brightness is < 0 or > 0x1F)
            throw new RespeakerArgumentOutOfRangeException($"The given brightness value is out of bounds: {brightness} Allowed Range: {minBrightness:X} - {maxBrightness:X}");

        UsbControl.WriteControlTransfer(0x20, [(byte)brightness], _usbDevice);
    }
    
    public void SetColorPalette(int a, int b)
    {
        const int minColor = 0x000000;
        const int maxColor = 0xFFFFFF;

        if (a is < minColor or > maxColor)
            throw new RespeakerArgumentOutOfRangeException($"The given color value for palette a is out of bounds: {a} Allowed Range: {minColor:X} - {maxColor:X}");

        if (b is < minColor or > maxColor)
            throw new RespeakerArgumentOutOfRangeException($"The given color value for plaette b is out of bounds: {b} Allowed Range: {minColor:X} - {maxColor:X}");

        UsbControl.WriteControlTransfer(0x21, HexColorToByteArray(a).Concat(HexColorToByteArray(b)).ToArray(), _usbDevice);
    }
    
    public void SetVadLed(LedState state)
    {
        UsbControl.WriteControlTransfer(0x22, [(byte)state], _usbDevice);
    }
    
    public void Volume(int volume)
    {
        const int minVolume = 0;
        const int maxVolume = 0x1F;

        if (volume is < minVolume or > maxVolume)
            throw new RespeakerArgumentOutOfRangeException($"The given volume value is out of bounds: {volume} Allowed Range: {minVolume} - {maxVolume}");

        UsbControl.WriteControlTransfer(0x23, [(byte)volume], _usbDevice);
    }

    static byte[] HexColorToByteArray(int color)
    {
        return
        [
            (byte)((color >> 16) & 0xFF),
            (byte)((color >> 8) & 0xFF),
            (byte)(color & 0xFF),
            0
        ];
    }
}