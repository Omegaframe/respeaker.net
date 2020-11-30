using Alsa.Net;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Respeaker.Net.Hardware
{
    public class AlsaAudioInput : IAudioInput
    {
        readonly ISoundDevice _soundDevice;

        internal AlsaAudioInput(ISoundDevice soundDevice)
        {
            _soundDevice = soundDevice;
        }

        public Task Record(Stream outputStream, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() => _soundDevice.Record(outputStream, cancellationToken), cancellationToken);
        }
    }
}
