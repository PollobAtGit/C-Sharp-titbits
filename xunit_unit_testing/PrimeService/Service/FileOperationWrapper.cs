using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PrimeService.Attribute;

namespace PrimeService.Service
{
    public class FileOperationWrapper
    {
        public virtual bool FileExists(string filePath) => File.Exists(filePath);

        [DoingNothing]
        [SleepForFiveMinutes]
        public async Task WriteToFile(string filePath, string[] contentStrings)
        {
            if (FileExists(filePath))
                await Task.Run(() => File.WriteAllLines(filePath, contentStrings));
        }

        [DoingNothing]
        [SleepForFiveMinutes]
        public List<string> ReadFromFile(string filePath) => File.ReadAllLines(filePath).ToList();
    }
}
