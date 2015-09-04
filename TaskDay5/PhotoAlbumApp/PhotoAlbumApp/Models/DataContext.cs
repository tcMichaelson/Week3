using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhotoAlbumApp.Models {
    public class DataContext : DbContext {
        public IDbSet<Photo> Photos { get; set; }
        public IDbSet<Album> Albums { get; set; }
    }
}