using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Tracing;

namespace Ch_3.TraceWriter
{
    public class TextTraceWriter : ITraceWriter
    {
        public void Trace(HttpRequestMessage request, string category, TraceLevel level, Action<TraceRecord> traceAction)
        {
            var tr = new TraceRecord(request, category, level);

            traceAction(tr);

            WriteToText(tr);
        }

        private void WriteToText(TraceRecord tr)
        {
            if (string.IsNullOrWhiteSpace(tr.Message)) return;

            using (var stream = new FileStream("trace-log.txt", FileMode.Append))
            using (var writer = new StreamWriter(stream))
                writer.WriteLine(tr.Message);
        }
    }
}