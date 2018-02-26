using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Tracing;

namespace API.Tracer
{
    public class TextTracer : ITraceWriter
    {
        public void Trace(HttpRequestMessage request, string category, TraceLevel level, Action<TraceRecord> traceAction)
        {
            if (level == TraceLevel.Off) return;

            var rec = new TraceRecord(request, category, level);

            traceAction(rec);

            WriteToText(rec);
        }

        void WriteToText(TraceRecord rec)
        {
            var filePath = @"C:\Users\pollob\Documents\tracer-log.txt";

            using (var stream = new FileStream(filePath, FileMode.Append))
            {
                using (var textWriter = new StreamWriter(stream))
                {
                    textWriter.WriteLine(rec.Message);
                }
            }
        }
    }
}