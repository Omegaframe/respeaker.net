using System;
using Respeaker.Net.Devices;

namespace Respeaker.Net
{
    public interface IRespeakerDevice : IDisposable
    {
        ILedRing LedRing { get; }
        IAudioOutput AudioOutput { get; }
        IAudioInput AudioInput { get; }
        IOnBoardConfiguration Configuration { get; }
        DeviceDescription Description { get; }
    }
}
