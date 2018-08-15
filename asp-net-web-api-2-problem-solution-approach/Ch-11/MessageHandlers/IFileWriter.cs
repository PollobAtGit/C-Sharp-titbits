namespace Ch_11.MessageHandlers
{
    public interface IFileWriter
    {
        string FileName { get; }

        void AppendAllLines(string[] linesToWrite);
    }
}