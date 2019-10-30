namespace MemLand.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UdateMem : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Mems", "UrlSlug");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Mems", "UrlSlug", c => c.String());
        }
    }
}
