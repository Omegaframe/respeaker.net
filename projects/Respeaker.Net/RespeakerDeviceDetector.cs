using Alsa.Net;
using LibUsbDotNet;
using LibUsbDotNet.Main;
using Respeaker.Net.Exceptions;
using Respeaker.Net.Hardware;

namespace Respeaker.Net
{
    public static class RespeakerDeviceDetector
    {
        public static UsbMicArrayV2 GetUsbMicArrayV2()
        {
            const string alsaDeviceName = "ArrayUAC10";
            const int usbVendorId = 0x2886;
            const int usbProductId = 0x0018;

            var usbDeviceFinder = new UsbDeviceFinder(usbVendorId, usbProductId);

            if (!(UsbDevice.OpenUsbDevice(usbDeviceFinder) is IUsbDevice usbMicArrayV2Device))
                throw new UsbDeviceNotFoundException(nameof(UsbMicArrayV2));

            if (!usbMicArrayV2Device.IsOpen)
                usbMicArrayV2Device.Open();

            var alsaSettings = new SoundDeviceSettings
            {
                RecordingDeviceName = alsaDeviceName,
                PlaybackDeviceName = alsaDeviceName,
                RecordingBitsPerSample = 16,
                RecordingSampleRate = 441000
            };
            var alsaDevice = AlsaDeviceBuilder.Create(alsaSettings);

            return new UsbMicArrayV2
            {
                LedRing = new PixelRing(usbMicArrayV2Device),
                AudioInput = new AlsaAudioInput(alsaDevice),
                AudioOutput = new AlsaAudioOutput(alsaDevice),
                Configuration = new OnBoardConfiguration(usbMicArrayV2Device)
            };
        }
    }
}
