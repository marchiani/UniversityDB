namespace MemLand.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updates : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Mems", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Mems", "User_Id", "dbo.Users");
            DropIndex("dbo.Mems", new[] { "CategoryId" });
            DropIndex("dbo.Mems", new[] { "User_Id" });
            DropColumn("dbo.Mems", "UserId");
            RenameColumn(table: "dbo.Mems", name: "CategoryId", newName: "Category_Id");
            RenameColumn(table: "dbo.Mems", name: "User_Id", newName: "UserId");
            AddColumn("dbo.Mems", "CategoryName", c => c.String());
            AlterColumn("dbo.Mems", "Category_Id", c => c.Int());
            AlterColumn("dbo.Mems", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Mems", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Mems", "UserId");
            CreateIndex("dbo.Mems", "Category_Id");
            AddForeignKey("dbo.Mems", "Category_Id", "dbo.Categories", "Id");
            AddForeignKey("dbo.Mems", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mems", "UserId", "dbo.Users");
            DropForeignKey("dbo.Mems", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Mems", new[] { "Category_Id" });
            DropIndex("dbo.Mems", new[] { "UserId" });
            AlterColumn("dbo.Mems", "UserId", c => c.Int());
            AlterColumn("dbo.Mems", "UserId", c => c.String());
            AlterColumn("dbo.Mems", "Category_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Mems", "CategoryName");
            RenameColumn(table: "dbo.Mems", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Mems", name: "Category_Id", newName: "CategoryId");
            AddColumn("dbo.Mems", "UserId", c => c.String());
            CreateIndex("dbo.Mems", "User_Id");
            CreateIndex("dbo.Mems", "CategoryId");
            AddForeignKey("dbo.Mems", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Mems", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
