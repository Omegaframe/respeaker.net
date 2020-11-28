using Alsa.Net;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Respeaker.Net.Hardware
{
    public class AlsaAudioOutput : IDisposable
    {
        readonly ISoundDevice _soundDevice;

        public AlsaAudioOutput(ISoundDevice soundDevice)
        {
            _soundDevice = soundDevice;
        }

        public void Play(string file)
        {
            _soundDevice.Play(file);
        }

        public Task Play(Stream stream, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() => _soundDevice.Play(stream), cancellationToken);
        }

        public void Dispose()
        {
            _soundDevice.Dispose();
        }
    }
}
