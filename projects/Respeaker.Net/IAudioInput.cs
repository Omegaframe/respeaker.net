using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Respeaker.Net
{
    public interface IAudioInput
    {
        Task Record(Stream outputStream, CancellationToken cancellationToken);
    }
}
