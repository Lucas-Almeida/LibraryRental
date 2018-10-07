namespace LibraryRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuthorBookManyToManyRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Authors", "BookId", "dbo.Books");
            DropIndex("dbo.Authors", new[] { "BookId" });
            CreateTable(
                "dbo.BookAuthors",
                c => new
                    {
                        Book_Id = c.Int(nullable: false),
                        Author_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_Id, t.Author_Id })
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .ForeignKey("dbo.Authors", t => t.Author_Id, cascadeDelete: true)
                .Index(t => t.Book_Id)
                .Index(t => t.Author_Id);
            
            DropColumn("dbo.Authors", "BookId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Authors", "BookId", c => c.Int(nullable: false));
            DropForeignKey("dbo.BookAuthors", "Author_Id", "dbo.Authors");
            DropForeignKey("dbo.BookAuthors", "Book_Id", "dbo.Books");
            DropIndex("dbo.BookAuthors", new[] { "Author_Id" });
            DropIndex("dbo.BookAuthors", new[] { "Book_Id" });
            DropTable("dbo.BookAuthors");
            CreateIndex("dbo.Authors", "BookId");
            AddForeignKey("dbo.Authors", "BookId", "dbo.Books", "Id", cascadeDelete: true);
        }
    }
}
