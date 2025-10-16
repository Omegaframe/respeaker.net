namespace Respeaker.Net;

/// <summary>interface for easy audio recording</summary>
public interface IAudioInput
{
    /// <summary>
    /// record audio in wav format and write it to the given stream until the cancellation token is cancelled
    /// </summary>
    /// <param name="outputStream">target stream to write the audio to</param>
    /// <param name="cancellationToken">cancellation token that stops the recording once its cancelled</param>
    /// <returns>task that ends when the cancellation token is cancelled</returns>
    Task Record(Stream outputStream, CancellationToken cancellationToken);

    /// <summary>
    /// record audio in wav format and write it to the given callback method until the cancellation token is cancelled
    /// </summary>
    /// <remarks>the output data will also include the wav header</remarks>
    /// <param name="onDataAvailable">action is called when new audio data is available</param>
    /// <param name="cancellationToken">cancellation token that stops the recording once its cancelled</param>
    /// <returns>task that ends when the cancellation token is cancelled</returns>
    Task Record(Action<byte[]> onDataAvailable, CancellationToken cancellationToken);
}