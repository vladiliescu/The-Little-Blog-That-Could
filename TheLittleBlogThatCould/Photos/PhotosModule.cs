using System;
using System.IO;
using Nancy;
using System.Linq;
using Nancy.ModelBinding;

namespace LittleBlog.Photos
{
    public class PhotosModule : NancyModule
    {
        public PhotosModule(IPhotosRepository photosRepository, IImagesService imagesService) 
        {
            Get["/"] = r => 
            {
                var photos = photosRepository.GetAll().OrderByDescending(x => x.Timestamp);
                return View[new PhotosModel(photos)];
            };

            Get["/search"] = r =>
            {
                var query = ((string)Request.Query["q"]).ToUpper();
                var photos = photosRepository.GetAll().Where(x => x.Caption.ToUpper().Contains(query));
                return View[new PhotosModel(photos)];
            };

            Get["/photo/{id}"] = r =>
            {
                var photo = photosRepository.Get((Guid)r.id);
                return View[new PhotoModel(photo)];
            };

            Get["/photo/{id}/render"] = r =>
            {
                var photo = photosRepository.Get((Guid)r.id);
                return Response.FromStream(new MemoryStream(photo.Content), photo.ContentType);
            };

            Get["/photo/{id}/render/{width}"] = r =>
            {
                var photo = photosRepository.Get((Guid)r.id);
                var resizedPhoto = imagesService.ResizeByWidth(new MemoryStream(photo.Content), (int)r.width);
                return Response.FromStream(resizedPhoto, photo.ContentType);
            };

            Get["/photo/{id}/edit"] = r =>
            {
                var photo = photosRepository.Get((Guid)r.id);
                return View["PhotoEdit", new PhotoModel(photo)];
            };

            Post["/photo/{id}/edit"] = r =>
            {
                var model = this.Bind<PhotoModel>();
                var photo = photosRepository.Get(model.Id);
                photo.ChangeInfo(model.Caption);

                return Response.AsRedirect("/photo/" + photo.Id);
            };

            Delete["/photo/{id}"] = r =>
            {
                photosRepository.Delete((Guid)r.id);
                return HttpStatusCode.OK;
            };

            Get["/add"] = r => 
                View["PhotoAdd"];

            Post["/add"] = r => 
            {
                var caption = Request.Form["caption"];
                var file = Request.Files.First(f => f.Key == "photo");

                var photo = new Photo(file.Name, file.Value, file.ContentType, caption);
                photosRepository.Save(photo);

                return Response.AsRedirect("/");
            };
        }
    }
}