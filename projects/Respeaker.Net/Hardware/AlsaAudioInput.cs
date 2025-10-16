using Alsa.Net;
using Respeaker.Net.Extensions;

namespace Respeaker.Net.Hardware;

class AlsaAudioInput : IAudioInput
{
    readonly ISoundDevice _soundDevice;

    internal AlsaAudioInput(ISoundDevice soundDevice)
    {
        _soundDevice = soundDevice;
    }

    public Task Record(Stream outputStream, CancellationToken cancellationToken)
    {
        return Task.Factory.StartNew(() => _soundDevice.Record(outputStream, cancellationToken), cancellationToken).AllowCancellation();
    }

    public Task Record(Action<byte[]> onDataAvailable, CancellationToken cancellationToken)
    {
        return Task.Factory.StartNew(() => _soundDevice.Record(onDataAvailable, cancellationToken), cancellationToken).AllowCancellation();
    }
}