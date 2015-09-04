using PhotoAlbumApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoAlbumApp.Presentation.Web {
    public class AlbumDTO {
        public string Name { get; set; }
        public List<PhotoDTO> Photos { get; set; }
    }
}