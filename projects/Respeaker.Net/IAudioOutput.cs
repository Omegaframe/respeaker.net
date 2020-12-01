using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Respeaker.Net
{
    public interface IAudioOutput
    {
        Task Play(string file, CancellationToken cancellationToken);
        Task Play(Stream stream, CancellationToken cancellationToken);

        void SetVolume(ushort volume);
    }
}
