using Device.Net;
using Device.Net.LibUsb;
using Respeaker.Net.Hardware;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Respeaker.Net
{
    public static class DeviceDetector
    {
        static DeviceDetector()
        {
            LibUsbUsbDeviceFactory.Register(new DebugLogger(), new DebugTracer());
        }

        public static async Task<UsbMicArrayV2> GetUsbMicArrayV2()
        {
            var deviceDefinitions = new List<FilterDeviceDefinition>()
            {
               PixelRing.UsbDefinition
            };

            var devices = await DeviceManager.Current.GetDevicesAsync(deviceDefinitions);

            var ringUsbDevice = devices.FirstOrDefault() as LibUsbDevice;
            await ringUsbDevice.InitializeAsync();

            return new UsbMicArrayV2
            {
                PixelRing = new PixelRing(ringUsbDevice)
            };
        }
    }
}
