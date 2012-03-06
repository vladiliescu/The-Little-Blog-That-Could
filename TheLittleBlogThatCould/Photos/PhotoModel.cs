using System;

namespace LittleBlog.Photos
{
    public class PhotoModel
    {
        public PhotoModel()
        {
        }

        public PhotoModel(Photo photo)
        {
            Id = photo.Id;
            FileName = photo.FileName;
            Caption = photo.Caption;
        }

        public string FileName { get; set; }
        public string Caption { get; set; }
        public Guid Id { get; set; }
    }
}