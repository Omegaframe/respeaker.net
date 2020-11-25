using System;

namespace Respeaker.Net.Exceptions
{
    public class RespeakerArgumentOutOfRangeException : ArgumentOutOfRangeException
    {
        public RespeakerArgumentOutOfRangeException(string message) : base(message) { }
    }
}
