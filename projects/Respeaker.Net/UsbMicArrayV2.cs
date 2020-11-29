using System;
using Alsa.Net;
using LibUsbDotNet;
using Respeaker.Net.Hardware;

namespace Respeaker.Net
{
    public class UsbMicArrayV2 : IDisposable
    {
        public PixelRing LedRing { get; internal set; }
        public AlsaAudioOutput AudioOutput { get; internal set; }
        public AlsaAudioInput AudioInput { get; internal set; }
        public OnBoardConfiguration Configuration { get; internal set; }

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
    }
}
