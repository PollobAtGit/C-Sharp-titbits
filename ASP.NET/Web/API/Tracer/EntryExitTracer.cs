using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Tracing;
using API.Diagnostics;

namespace API.Tracer
{
    public class EntryExitTracer : ITraceWriter
    {
        public void Trace(HttpRequestMessage request, string category, TraceLevel level, Action<TraceRecord> traceAction)
        {
            if (level == TraceLevel.Off) return;

            var rec = new TraceRecord(request, category, level);

            traceAction(rec);

            // TODO: What is RingBuffer?
            RingBufferLog.Instance.Enqueue(rec);
        }
    }
}