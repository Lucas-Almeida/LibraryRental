namespace LibraryRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBookToAuthorAndRemovedPublisherAndAuthorFromBook : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.Books", "PublisherId", "dbo.Publishers");
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropIndex("dbo.Books", new[] { "PublisherId" });
            AddColumn("dbo.Authors", "BookId", c => c.Int(nullable: false));
            CreateIndex("dbo.Authors", "BookId");
            AddForeignKey("dbo.Authors", "BookId", "dbo.Books", "Id", cascadeDelete: true);
            DropColumn("dbo.Books", "AuthorId");
            DropColumn("dbo.Books", "PublisherId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "PublisherId", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "AuthorId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Authors", "BookId", "dbo.Books");
            DropIndex("dbo.Authors", new[] { "BookId" });
            DropColumn("dbo.Authors", "BookId");
            CreateIndex("dbo.Books", "PublisherId");
            CreateIndex("dbo.Books", "AuthorId");
            AddForeignKey("dbo.Books", "PublisherId", "dbo.Publishers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Books", "AuthorId", "dbo.Authors", "Id", cascadeDelete: true);
        }
    }
}
