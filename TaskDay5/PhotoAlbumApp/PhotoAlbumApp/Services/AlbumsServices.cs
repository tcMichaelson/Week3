using PhotoAlbumApp.Infrastructure;
using PhotoAlbumApp.Models;
using PhotoAlbumApp.Presentation.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoAlbumApp.Services {

    public class AlbumsServices {

        private IRepository _repo;

        public AlbumsServices(IRepository repo) {
            _repo = repo;
        }

        public void CreateAlbum(AlbumDTO album) {
            Album newAlbum = new Album {
                Name = album.Name,
                Photos = new List<Photo>()
            };
            _repo.Add<Album>(newAlbum);
            _repo.SaveChanges();
        }

        public Album GetAlbumById(int id) {
            return _repo.Find<Album>(id);
        }

        public Album GetAlbumByName(string name) {
            var allAlbums = ListAlbums();
            return allAlbums.Where(m => m.Name == name).FirstOrDefault();            
        }

        public List<Photo> GetPhotosByAlbum(AlbumDTO album) {
            return _repo.Find<Album>(album).Photos;
        }

        public IList<Album> ListAlbums() {
            return _repo.Query<Album>().Include(m => m.Photos).ToList();
        }
    }
}