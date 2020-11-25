using Iot.Device.Media;
using System;
using System.IO;

namespace Respeaker.Net.Hardware
{
    public class AlsaAudioOutput : IDisposable
    {
        readonly SoundDevice _soundDevice;

        public AlsaAudioOutput(SoundDevice soundDevice)
        {
            _soundDevice = soundDevice;
        }        

        public void Play(string file)
        {
            _soundDevice.Play(file);
        }

        public void Play(Stream stream)
        {
            _soundDevice.Play(stream);
        }

        public void Dispose()
        {
            _soundDevice.Dispose();
        }
    }
}
