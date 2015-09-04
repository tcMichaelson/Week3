namespace PhotoAlbumApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removed_album_from_photo : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Photos", name: "InAlbum_Name", newName: "Album_Name");
            RenameIndex(table: "dbo.Photos", name: "IX_InAlbum_Name", newName: "IX_Album_Name");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Photos", name: "IX_Album_Name", newName: "IX_InAlbum_Name");
            RenameColumn(table: "dbo.Photos", name: "Album_Name", newName: "InAlbum_Name");
        }
    }
}
