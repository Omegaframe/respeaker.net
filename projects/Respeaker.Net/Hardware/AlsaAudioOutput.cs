using Alsa.Net;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Respeaker.Net.Hardware
{
    public class AlsaAudioOutput : IAudioOutput
    {
        readonly ISoundDevice _soundDevice;

        internal AlsaAudioOutput(ISoundDevice soundDevice)
        {
            _soundDevice = soundDevice;
        }

        public Task Play(string file, CancellationToken cancellationToken)
        {
            // todo: token mitgeben
            return Task.Factory.StartNew(() =>_soundDevice.Play(file), cancellationToken);
        }

        public Task Play(Stream stream, CancellationToken cancellationToken)
        {
            // todo: token mitgeben
            return Task.Factory.StartNew(() => _soundDevice.Play(stream), cancellationToken);
        }
    }
}
