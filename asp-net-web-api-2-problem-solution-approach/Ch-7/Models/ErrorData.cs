using System;

namespace Ch_7.Models
{
    public class ErrorData
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public string Uri { get; set; }
    }
}