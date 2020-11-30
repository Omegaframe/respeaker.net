using Alsa.Net;
using LibUsbDotNet;
namespace Respeaker.Net.Devices
{
    class UsbMicArrayV2 : IRespeakerDevice
    {
        public ILedRing LedRing { get; internal set; }
        public IAudioOutput AudioOutput { get; internal set; }
        public IAudioInput AudioInput { get; internal set; }
        public IOnBoardConfiguration Configuration { get; internal set; }
        public DeviceDescription Description { get; internal set; }

        readonly IUsbDevice _usbDevice;
        readonly ISoundDevice _soundDevice;

        internal UsbMicArrayV2(IUsbDevice usbDevice, ISoundDevice soundDevice)
        {
            _usbDevice = usbDevice;
            _soundDevice = soundDevice;
        }

        public void Dispose()
        {
            _soundDevice?.Dispose();

            if (_usbDevice?.IsOpen == true)
                _usbDevice.Close();
        }

        public override string ToString() => Description.ToString();
    }
}
