using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Respeaker.Net
{
    public interface IAudioInput
    {
        Task Record(Stream outputStream, CancellationToken cancellationToken);
        Task Record(Action<byte[]> onDataAvailable, CancellationToken cancellationToken);
    }
}
