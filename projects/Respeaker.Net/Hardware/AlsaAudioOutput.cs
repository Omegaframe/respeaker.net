using Alsa.Net;
using Respeaker.Net.Extensions;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Respeaker.Net.Hardware
{
    class AlsaAudioOutput : IAudioOutput
    {
        readonly ISoundDevice _soundDevice;

        internal AlsaAudioOutput(ISoundDevice soundDevice)
        {
            _soundDevice = soundDevice;
        }

        public Task Play(string file, CancellationToken cancellationToken)
        {            
            return Task.Factory.StartNew(() =>_soundDevice.Play(file, cancellationToken), cancellationToken).AllowCancellation();
        }

        public Task Play(Stream stream, CancellationToken cancellationToken)
        {            
            return Task.Factory.StartNew(() => _soundDevice.Play(stream, cancellationToken), cancellationToken).AllowCancellation();
        }

        public void SetVolume(ushort volume)
        {
            _soundDevice.PlaybackVolume = volume;
        }
    }
}
