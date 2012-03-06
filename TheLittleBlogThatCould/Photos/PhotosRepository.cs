using System;
using System.Collections.Generic;
using System.Linq;

namespace LittleBlog.Photos
{
    public interface IPhotosRepository
    {
        void Save(Photo photo);
        IQueryable<Photo> GetAll();
        Photo Get(Guid id);
        void Delete(Guid id);
    }

    class PhotosRepository : IPhotosRepository
    {
        private readonly IList<Photo> photos = new List<Photo>();

        public void Save(Photo photo)
        {
            photos.Add(photo);
        }

        public IQueryable<Photo> GetAll()
        {
            return photos.AsQueryable();
        }

        public Photo Get(Guid id)
        {
            return photos.SingleOrDefault(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            photos.Remove(photos.Single(photo => photo.Id == id));
        }
    }
}