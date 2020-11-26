using Alsa.Net;
using Device.Net;
using Device.Net.LibUsb;
using Respeaker.Net.Hardware;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Respeaker.Net
{
    public static class RespeakerDeviceDetector
    {
        static RespeakerDeviceDetector()
        {
            LibUsbUsbDeviceFactory.Register(new DebugLogger(), new DebugTracer());
        }

        public static async Task<UsbMicArrayV2> GetUsbMicArrayV2()
        {
            const string alsaDeviceName = "ArrayUAC10";

            var deviceDefinitions = new List<FilterDeviceDefinition>()
            {
               PixelRing.UsbDefinition
            };

            var devices = await DeviceManager.Current.GetDevicesAsync(deviceDefinitions);

            var ringUsbDevice = devices.FirstOrDefault() as LibUsbDevice;
            await ringUsbDevice.InitializeAsync();

            var alsaSettings = new SoundConnectionSettings
            {
                RecordingDeviceName = alsaDeviceName,
                PlaybackDeviceName = alsaDeviceName,
                RecordingBitsPerSample = 16,
                RecordingSampleRate = 441000
            };
            var alsaDevice = AlsaDeviceBuilder.Create(alsaSettings);

            return new UsbMicArrayV2
            {
                LedRing = new PixelRing(ringUsbDevice),
                AudioInput = new AlsaAudioInput(alsaDevice),
                AudioOutput = new AlsaAudioOutput(alsaDevice),
                Configuration = new OnBoardConfiguration()
            };
        }
    }
}
