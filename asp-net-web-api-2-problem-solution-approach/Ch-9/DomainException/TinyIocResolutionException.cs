using System;
using System.Runtime.Serialization;

namespace Ch_9.DomainException
{
    [Serializable]
    internal class TinyIocResolutionException : Exception
    {
        public TinyIocResolutionException()
        {
        }

        public TinyIocResolutionException(string message) : base(message)
        {
        }

        public TinyIocResolutionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TinyIocResolutionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}