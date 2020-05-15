using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Common
{
    public static class ImageProcessor
    {
        public static Image MakeImageControl(byte[] bytes)
        {
            var imageControl = new Image();
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = new MemoryStream(bytes);
            bitmapImage.EndInit();
            imageControl.Source = bitmapImage;
            imageControl.Width = 16;
            imageControl.Height = 16;
            return imageControl;
        }
    }
}
