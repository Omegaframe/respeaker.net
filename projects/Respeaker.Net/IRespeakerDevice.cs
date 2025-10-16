using Respeaker.Net.Devices;

namespace Respeaker.Net;

/// <summary>interface to access and abstract all features of a respeaker device</summary>
public interface IRespeakerDevice : IDisposable
{
    /// <summary>LED ring control</summary>
    ILedRing LedRing { get; }

    /// <summary>audio output (playback) control</summary>
    IAudioOutput AudioOutput { get; }

    /// <summary>audio input (recording) control</summary>
    IAudioInput AudioInput { get; }

    /// <summary>access to the onboard configuration</summary>
    IOnBoardConfiguration Configuration { get; }

    /// <summary>description of the connected device</summary>
    DeviceDescription Description { get; }
}