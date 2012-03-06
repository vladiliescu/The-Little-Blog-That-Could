using System;
using System.IO;

namespace LittleBlog.Photos
{
    public class Photo
    {
        public Guid Id { get; private set; }
        public string Caption { get; set; }
        public byte[] Content { get; private set; }
        public string ContentType { get; private set; }
        public DateTime Timestamp { get; private set; }

        public Photo(string fileName, Stream content, string contentType, string caption)
        {
            Id = Guid.NewGuid();
            Timestamp = DateTime.Now;

            Caption = string.IsNullOrEmpty(caption.Trim()) ? fileName : caption.Trim();
            ContentType = contentType;
            Content = new byte[content.Length];
            content.Read(Content, 0, (int)content.Length);
        }
    }
}