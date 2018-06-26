using System;

namespace Ch_7.DomainExceptions
{
    public class ResourceDeletedException : Exception
    {
        public ResourceDeletedException(string message, InvalidOperationException expException) : base(message, expException) { }
    }
}