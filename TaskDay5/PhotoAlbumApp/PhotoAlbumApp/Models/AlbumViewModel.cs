using PhotoAlbumApp.Presentation.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoAlbumApp.Models {
    public class AlbumViewModel {
        public AlbumDTO Album { get; set; }
        public List<PhotoDTO> Photos { get; set; }
    }
}