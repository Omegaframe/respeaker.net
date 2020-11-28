using System;
using Respeaker.Net.Hardware;

namespace Respeaker.Net
{
    public class UsbMicArrayV2 : IDisposable
    {
        public PixelRing LedRing { get; internal set; }
        public AlsaAudioOutput AudioOutput { get; internal set; }
        public AlsaAudioInput AudioInput { get; internal set; }
        public OnBoardConfiguration Configuration { get; internal set; }

        internal UsbMicArrayV2() { }

        public void Dispose()
        {
            LedRing?.Dispose();
            AudioOutput?.Dispose();
            AudioInput?.Dispose();
            Configuration?.Dispose();
        }
    }
}
