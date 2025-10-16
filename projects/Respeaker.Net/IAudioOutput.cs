namespace Respeaker.Net;

/// <summary>interface for easy audio playback</summary>
public interface IAudioOutput
{
    /// <summary>
    /// play the given audio (wav) file until the end or the cancellation token is cancelled
    /// </summary>
    /// <param name="file">path to the file that should be played</param>
    /// <param name="cancellationToken">cancellation token that stops the playback once cancelled</param>
    /// <returns>task that ends when the file was played or the cancellation token was cancelled</returns>
    Task Play(string file, CancellationToken cancellationToken);

    /// <summary>
    /// play the given audio stream (wav) until the end or the cancellation token is cancelled
    /// </summary>
    /// <param name="stream">stream containing the wav data that should be played on the device</param>
    /// <param name="cancellationToken">cancellation token that stops the playback once cancelled</param>
    /// <returns>task that ends when the stream completed or the cancellation token was cancelled</returns>
    Task Play(Stream stream, CancellationToken cancellationToken);

    /// <summary>
    /// set the playback volume of the device.
    /// </summary>
    /// <remarks>this is not supported by respeaker out of the box - use AudioOutputOverrideDevice with a virtual ALSA device to simulate volume control</remarks>
    /// <param name="volume">volume in the range from 0 to 100 (%)</param>
    void SetVolume(ushort volume);
}