using System;
using Alsa.Net;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Respeaker.Net.Hardware
{
    public class AlsaAudioInput : IDisposable
    {
        readonly ISoundDevice _soundDevice;

        public AlsaAudioInput(ISoundDevice soundDevice)
        {
            _soundDevice = soundDevice;
        }

        public Task Record(Stream outputStream, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() => _soundDevice.Record(outputStream, cancellationToken), cancellationToken);
        }

        public void Dispose()
        {
            _soundDevice.Dispose();
        }
    }
}
