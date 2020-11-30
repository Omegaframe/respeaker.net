using System;

namespace Respeaker.Net
{
    public interface IRespeakerDevice : IDisposable
    {
        ILedRing LedRing { get; }
        IAudioOutput AudioOutput { get; }
        IAudioInput AudioInput { get; }
        IOnBoardConfiguration Configuration { get; }
    }
}
