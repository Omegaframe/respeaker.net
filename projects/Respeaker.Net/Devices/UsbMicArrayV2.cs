using Alsa.Net;
using LibUsbDotNet;

namespace Respeaker.Net.Devices;

class UsbMicArrayV2 : IRespeakerDevice
{
    public ILedRing LedRing { get; }
    public IAudioOutput AudioOutput { get; }
    public IAudioInput AudioInput { get; }
    public IOnBoardConfiguration Configuration { get; }
    public DeviceDescription Description { get; }

    readonly IUsbDevice _usbDevice;
    readonly ISoundDevice _soundDevice;

    internal UsbMicArrayV2(IUsbDevice usbDevice, ISoundDevice soundDevice, ILedRing ledRing, IAudioOutput audioOutput, IAudioInput audioInput, IOnBoardConfiguration configuration, DeviceDescription deviceDescription)
    {
        _usbDevice = usbDevice;
        _soundDevice = soundDevice;
        LedRing = ledRing;
        AudioOutput = audioOutput;
        AudioInput = audioInput;
        Configuration = configuration;
        Description = deviceDescription;
    }

    public void Dispose()
    {
        _soundDevice.Dispose();

        if (_usbDevice.IsOpen)
            _usbDevice.Close();
    }

    public override string ToString() => Description.ToString();
}