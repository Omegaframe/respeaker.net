using Alsa.Net;
using LibUsbDotNet;
using LibUsbDotNet.Main;
using Respeaker.Net.Devices;
using Respeaker.Net.Exceptions;
using Respeaker.Net.Hardware;

namespace Respeaker.Net;

/// <summary>use the detector to auto-detect your respeaker device(s) and obtain a handle to control it.</summary>
public static class RespeakerDeviceDetector
{
    /// <summary>
    /// since there is no volume control per default, someone might want to create a virtual device capabale of this and use that one.
    /// set this property to the name of the virutal device to override the default one and gain control over it.
    /// </summary>
    public static string? AudioOutputOverrideDevice { get; set; }

    /// <summary>
    /// auto-detect all connected respeaker devices and return a list of handles to control them.
    /// </summary>
    /// <returns>list of respeaker devices currently available on the system</returns>
    /// <exception cref="UnknownDeviceException">thrown if an unknown device is detected</exception>
    public static IEnumerable<IRespeakerDevice> Detect()
    {
        var knownDevices = DeviceDescription.Known;

        foreach (UsbRegistry usbDevice in UsbDevice.AllDevices)
        {
            var respeakerUsb = knownDevices.FirstOrDefault(k => k.VendorId == usbDevice.Vid && k.ProductId == usbDevice.Pid);
            if (respeakerUsb == null)
                continue;

            yield return respeakerUsb.DeviceType switch
            {
                DeviceType.UsbMicArrayV2 => GetUsbMicArrayV2(respeakerUsb),
                _ => throw new UnknownDeviceException(respeakerUsb.DeviceType.ToString())
            };
        }
    }

    static IRespeakerDevice GetUsbMicArrayV2(DeviceDescription deviceDescription)
    {
        const int bitPerSample = 16;
        const int sampleRate = 16000;
        const int channels = 1;

        var usbDeviceFinder = new UsbDeviceFinder(deviceDescription.VendorId, deviceDescription.ProductId);

        if (UsbDevice.OpenUsbDevice(usbDeviceFinder) is not IUsbDevice usbMicArrayV2Device)
            throw new UsbDeviceNotFoundException(nameof(UsbMicArrayV2));

        if (!usbMicArrayV2Device.IsOpen)
            usbMicArrayV2Device.Open();

        var alsaSettings = new SoundDeviceSettings
        {
            RecordingDeviceName = deviceDescription.AlsaDeviceName,
            PlaybackDeviceName = string.IsNullOrWhiteSpace(AudioOutputOverrideDevice) ? deviceDescription.AlsaDeviceName : AudioOutputOverrideDevice,
            RecordingBitsPerSample = bitPerSample,
            RecordingSampleRate = sampleRate,
            RecordingChannels = channels
        };
        var alsaDevice = AlsaDeviceBuilder.Create(alsaSettings);

        var ledRing = new PixelRing(usbMicArrayV2Device);
        var audioInput = new AlsaAudioInput(alsaDevice);
        var audioOutput = new AlsaAudioOutput(alsaDevice);
        var configuration = new OnBoardConfiguration(usbMicArrayV2Device);

        return new UsbMicArrayV2(usbMicArrayV2Device, alsaDevice, ledRing, audioOutput, audioInput, configuration, deviceDescription);
    }
}