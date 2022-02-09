namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNoteOwnerID : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Note", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Note", "OwnerId", c => c.Int(nullable: false));
        }
    }
}
