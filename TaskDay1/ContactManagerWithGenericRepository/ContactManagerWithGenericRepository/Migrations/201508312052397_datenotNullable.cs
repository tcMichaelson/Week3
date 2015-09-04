namespace ContactManagerWithGenericRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datenotNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "Birthday", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "Birthday", c => c.DateTime());
        }
    }
}
