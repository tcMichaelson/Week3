using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoAlbumApp.Models {
    public class AddPhotoViewModel {
        public Photo Photo { get; set; }
        public string AlbumName { get; set; }
    }
}