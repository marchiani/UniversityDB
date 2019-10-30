namespace MemLand.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeinerKey : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Users", name: "Role_Id", newName: "RoleId");
            RenameIndex(table: "dbo.Users", name: "IX_Role_Id", newName: "IX_RoleId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Users", name: "IX_RoleId", newName: "IX_Role_Id");
            RenameColumn(table: "dbo.Users", name: "RoleId", newName: "Role_Id");
        }
    }
}
