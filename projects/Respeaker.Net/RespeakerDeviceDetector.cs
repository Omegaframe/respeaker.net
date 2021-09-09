using Alsa.Net;
using LibUsbDotNet;
using LibUsbDotNet.Main;
using Respeaker.Net.Devices;
using Respeaker.Net.Exceptions;
using Respeaker.Net.Hardware;
using System.Collections.Generic;
using System.Linq;

namespace Respeaker.Net
{
    public static class RespeakerDeviceDetector
    {
        // since there is no volume control per default, someone might want to create a virtual device capabale of this and use that one (i do!)
        public static string AudioOutputOverrideDevice { get; set; }

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
            var usbDeviceFinder = new UsbDeviceFinder(deviceDescription.VendorId, deviceDescription.ProductId);

            if (!(UsbDevice.OpenUsbDevice(usbDeviceFinder) is IUsbDevice usbMicArrayV2Device))
                throw new UsbDeviceNotFoundException(nameof(UsbMicArrayV2));

            if (!usbMicArrayV2Device.IsOpen)
                usbMicArrayV2Device.Open();

            var alsaSettings = new SoundDeviceSettings
            {
                RecordingDeviceName = deviceDescription.AlsaDeviceName,
                PlaybackDeviceName = string.IsNullOrWhiteSpace(AudioOutputOverrideDevice) ? deviceDescription.AlsaDeviceName : AudioOutputOverrideDevice,
                RecordingBitsPerSample = 16,
                RecordingSampleRate = 16000,
                RecordingChannels = 1,
                FlushBuffers = true
            };
            var alsaDevice = AlsaDeviceBuilder.Create(alsaSettings);

            return new UsbMicArrayV2(usbMicArrayV2Device, alsaDevice)
            {
                Description = deviceDescription,
                LedRing = new PixelRing(usbMicArrayV2Device),
                AudioInput = new AlsaAudioInput(alsaDevice),
                AudioOutput = new AlsaAudioOutput(alsaDevice),
                Configuration = new OnBoardConfiguration(usbMicArrayV2Device)
            };
        }
    }
}
