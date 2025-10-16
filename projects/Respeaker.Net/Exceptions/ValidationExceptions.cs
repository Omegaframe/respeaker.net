namespace Respeaker.Net.Exceptions;

/// <summary>thrown if a respeaker parameter is out of the allowed range</summary>
public class RespeakerArgumentOutOfRangeException : ArgumentOutOfRangeException
{
    /// <inheritdoc cref="RespeakerArgumentOutOfRangeException"/>
    public RespeakerArgumentOutOfRangeException(string message) : base(message) { }
}