using AutoMapper;
using PhotoAlbumApp.Models;
using PhotoAlbumApp.Presentation.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoAlbumApp.Services {
    public class AutoMapperConfig {
        public static void RegisterMaps() {
            Mapper.CreateMap<Album, AlbumDTO>();
            Mapper.CreateMap<AlbumDTO, Album>();
            Mapper.CreateMap<Photo, PhotoDTO>();
            Mapper.CreateMap< PhotoDTO, Photo>();
            Mapper.CreateMap<List<PhotoDTO>, List<Photo>>();
            Mapper.CreateMap<List<Photo>, List<PhotoDTO>>();
        }
    }
}