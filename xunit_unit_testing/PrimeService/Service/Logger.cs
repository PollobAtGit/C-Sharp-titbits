using System.Collections.Generic;
using System.IO;

namespace PrimeService.Service
{
    public class Logger
    {
        private readonly FileOperationWrapper _fileOperationWrapper = new FileOperationWrapper();

        public void Log(string message)
        {
            var path = "dummy path";

            if (_fileOperationWrapper.FileExists(path))
                File.WriteAllLines(path, new List<string>());
        }
    }
}
