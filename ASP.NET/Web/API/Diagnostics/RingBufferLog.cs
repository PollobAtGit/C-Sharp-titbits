using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Tracing;

namespace API.Diagnostics
{
    public class RingBufferLog
    {
        const int BUFFER_SIZE = 1000;
        readonly TraceRecord[] buffer;

        int pointer;

        readonly object _lock = new object();
        readonly static RingBufferLog _instance = new RingBufferLog();

        RingBufferLog()
        {
            buffer = new TraceRecord[BUFFER_SIZE];
            ResetPointer();
        }

        public IList<TraceRecord> DequeueAll()
        {
            lock (_lock)
            {
                ResetPointer();
                var bufferCopy = new List<TraceRecord>(buffer.Where(t => t != null));
                for (int index = 0; index < BUFFER_SIZE; index++)
                {
                    buffer[index] = null;
                }
                return bufferCopy;
            }
        }

        public IList<TraceRecord> PeekAll()
        {
            lock (_lock)
            {
                var bufferCopy = new List<TraceRecord>(buffer.Where(t => t != null));
                return bufferCopy;
            }
        }

        void ResetPointer()
        {
            pointer = BUFFER_SIZE - 1;
        }

        void MovePointer()
        {
            pointer = (pointer + 1) % BUFFER_SIZE;
        }

        public void Enqueue(TraceRecord item)
        {
            lock (_lock)
            {
                MovePointer();
                buffer[pointer] = item;
            }
        }

        public static RingBufferLog Instance => _instance;
    }
}