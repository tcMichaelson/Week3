using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoAlbumApp.Models {
    public class Album {
        [Key]
        public string Name { get; set; }
        public List<Photo> Photos { get; set; }
    }
}