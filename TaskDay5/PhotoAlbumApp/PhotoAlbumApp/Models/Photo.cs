using System;
using PhotoAlbumApp.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoAlbumApp.Models {
    public class Photo {
        [Key]
        public string Path { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Stars Rating { get; set; }
    }
}