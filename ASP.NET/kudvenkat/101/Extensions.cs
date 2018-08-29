using System.Web;

namespace _101
{
    internal static class Extensions
    {
        internal static void WriteHtmlLine(this HttpResponse response, string message) 
            => response.Write($"<div>{message}</div>");
    }
}