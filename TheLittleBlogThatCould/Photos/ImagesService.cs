using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace LittleBlog.Photos
{
    public interface IImagesService
    {
        Stream ResizeByWidth(Stream stream, int width);
    }

    public class ImagesService : IImagesService
    {
        public Stream ResizeByWidth(Stream stream, int width)
        {
            var image = Image.FromStream(stream);

            var bitmap = new Bitmap(width, (int)(image.Height / (image.Width / (float)width)));
            using (var g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(image, 0, 0, bitmap.Width, bitmap.Height);
            }

            var outputStream = new MemoryStream();
            bitmap.Save(outputStream, ImageFormat.Png);
            outputStream.Seek(0, SeekOrigin.Begin);

            return outputStream;
        }
    }
}