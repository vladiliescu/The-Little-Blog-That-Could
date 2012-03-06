using System.Collections.Generic;
using System.Linq;

namespace LittleBlog.Photos
{
    public class PhotosModel
    {
        public PhotoModel[] Photos { get; private set; }

        public PhotosModel(IEnumerable<Photo> photos)
        {
            Photos = photos.Select(photo => new PhotoModel(photo)).ToArray();
        }
    }
}