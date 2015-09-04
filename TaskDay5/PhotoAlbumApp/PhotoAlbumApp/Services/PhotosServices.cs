using PhotoAlbumApp.Infrastructure;
using PhotoAlbumApp.Models;
using PhotoAlbumApp.Presentation.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PhotoAlbumApp.Services {

    public class PhotosServices {

        private IRepository _repo;

        public PhotosServices(IRepository repo) {
            _repo = repo;
        }

        public void AddPhoto(string albumName, PhotoDTO photo, string fileName) {
            Photo newPhoto = new Photo {
                Description = photo.Description,
                Path = fileName,
                Rating = photo.Rating,
                Title = photo.Title,
                //InAlbum = _service.GetAlbumByName(albumName)
            };
            Album album = GetAlbumByName(albumName);
            List<Photo> photoList = album.Photos;
            if(photoList != null) {
                photoList.Add(newPhoto);
            } else {
                photoList = new List<Photo> {
                    newPhoto
                };
            }
            album.Photos = photoList;
            _repo.Add<Photo>(newPhoto);
            _repo.SaveChanges();
        }

        public Photo GetPhotoByPath(string pathName) {
            return _repo.Find<Photo>(pathName);
        }

        public void UpdatePhoto(string pathName) {
            var photo = GetPhotoByPath(pathName);
            Photo newPhoto = new Photo {
                Description = photo.Description,
                Rating = photo.Rating,
                Title = photo.Title
            };
            _repo.SaveChanges();
        }

        public Album GetAlbumByName(string name) {
            return _repo.Find<Album>(name);
        }


    }
}