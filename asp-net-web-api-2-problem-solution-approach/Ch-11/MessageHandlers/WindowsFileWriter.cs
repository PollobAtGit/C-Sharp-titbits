using System;
using System.IO;

namespace Ch_11.MessageHandlers
{
    internal class WindowsFileWriter : IFileWriter
    {
        public string FileName { get; }

        public WindowsFileWriter(string ipDumperFileName)
        {
            FileName = ipDumperFileName;
        }

        public void AppendAllLines(string[] linesToWrite)
        {
            File.AppendAllLines(FileName, linesToWrite);
        }
    }
}