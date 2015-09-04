using PhotoAlbumApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoAlbumApp.Presentation.Web {
    public class PhotoDTO {
        public string Path { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Stars Rating { get; set; }
    }
}