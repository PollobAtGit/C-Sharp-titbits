using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Tracing;
using System.Xml;

namespace API.Tracer
{
    public class WebApiTracer : ITraceWriter
    {
        public void Trace(HttpRequestMessage request, string category, System.Web.Http.Tracing.TraceLevel level, Action<TraceRecord> traceAction)
        {
            if (level == System.Web.Http.Tracing.TraceLevel.Off) return;

            var rec = new TraceRecord(request, category, level);

            // POI: Caller provided the operation to be performed & that can be performed by invoking traceAction<TraceRecord>
            // POI: After this line trace record contains data that caller has set
            traceAction(rec);

            WriteToXML(rec);
        }

        void WriteToXML(TraceRecord rec)
        {
            if (!string.IsNullOrWhiteSpace(rec.Message))
            {
                var filePath = @"C:\Users\pollob\Documents\log.xml";

                using (var stream = new FileStream(filePath, FileMode.Append))
                {
                    using (var xmlWriter = new XmlTextWriter(stream, Encoding.UTF8))
                    {
                        xmlWriter.Formatting = Formatting.Indented;

                        xmlWriter.WriteStartElement("Trace");
                        xmlWriter.WriteElementString("Timestamp", rec.Timestamp.ToString());
                        xmlWriter.WriteElementString("Operation", rec.Operation);
                        xmlWriter.WriteElementString("Operator", rec.Operator);

                        xmlWriter.WriteStartElement("Message", rec.Message);
                        xmlWriter.WriteCData(rec.Message);
                        xmlWriter.WriteEndElement();

                        xmlWriter.WriteStartElement("Category", rec.Category);
                        xmlWriter.WriteEndElement();

                        xmlWriter.WriteEndElement();

                        xmlWriter.Flush();
                        xmlWriter.WriteString(Environment.NewLine);
                    }
                }
            }
        }
    }
}
