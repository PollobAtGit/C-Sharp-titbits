namespace Ch_11.MessageHandlers
{
    internal interface IFileWriter
    {
        string FileName { get; }

        void AppendAllLines(string[] linesToWrite);
    }
}