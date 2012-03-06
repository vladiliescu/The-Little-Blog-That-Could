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
            Caption = photo.Caption;
        }

        public string Caption { get; set; }
        public Guid Id { get; set; }
    }
}