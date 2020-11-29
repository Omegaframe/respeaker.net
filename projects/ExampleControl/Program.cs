using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Respeaker.Net;

namespace ExampleControl
{
    class Program
    {
        static async Task Main()
        {
            var respeakerDevice = RespeakerDeviceDetector.GetUsbMicArrayV2();

            Console.WriteLine("------------------------------------");
            Console.WriteLine("Detecting current Parameters:");
            Console.WriteLine(respeakerDevice.Configuration.ToString()); // print list of currently configured device params
            Console.WriteLine("------------------------------------");

            Console.WriteLine("Setting LED Ring for 5s to red...");
            respeakerDevice.LedRing.Mono(0xFF0000);
            await Task.Delay(5000);
            respeakerDevice.LedRing.Off();

            Console.WriteLine("------------------------------------");

            Console.Write("Recording 15s of Audio...");
            using var tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(15));
            using var wavStream = new MemoryStream();

            await respeakerDevice.AudioInput.Record(wavStream, tokenSource.Token);
            wavStream.Seek(0, SeekOrigin.Begin);
            Console.Write("done.\n");

            Console.Write("Playing formerly recorded Audio back to device...");
            await respeakerDevice.AudioOutput.Play(wavStream, CancellationToken.None);
            Console.Write("done.\n");

            Console.WriteLine("------------------------------------");
           
            Console.WriteLine("Done");

            respeakerDevice.Dispose();
        }
    }
}
