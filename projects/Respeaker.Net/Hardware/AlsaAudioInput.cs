using Alsa.Net;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Respeaker.Net.Hardware
{
    public class AlsaAudioInput
    {
        readonly ISoundDevice _soundDevice;

        public AlsaAudioInput(ISoundDevice soundDevice)
        {
            _soundDevice = soundDevice;
        }

        public Task Record(string file, CancellationToken cancellationToken)
        {
            return _soundDevice.Record(file, cancellationToken);
        }

        public Task Record(Stream outputStream, CancellationToken cancellationToken)
        {
            return _soundDevice.Record(outputStream, cancellationToken);
        }

        public void Dispose()
        {
            _soundDevice.Dispose();
        }
    }
}
