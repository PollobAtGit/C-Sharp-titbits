using System.Windows.Controls;

namespace Common
{
    public interface IFaviconGetter
    {
        Image GetFavicon(string url);
    }
}