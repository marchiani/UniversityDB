namespace MemLand.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updates1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mems", "PostMem", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mems", "PostMem");
        }
    }
}
