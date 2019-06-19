namespace Veresiye.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransactionDate = c.DateTime(nullable: false),
                        ActivityType = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        CreateBy = c.String(),
                        UpdateAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(nullable: false, maxLength: 100),
                        City = c.String(maxLength: 100),
                        Region = c.String(maxLength: 100),
                        CreateAt = c.DateTime(nullable: false),
                        CreateBy = c.String(),
                        UpdateAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                        CompanyName = c.String(maxLength: 100),
                        Phone = c.String(maxLength: 100),
                        City = c.String(maxLength: 100),
                        Region = c.String(),
                        CreateAt = c.DateTime(nullable: false),
                        CreateBy = c.String(),
                        UpdateAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Activities", new[] { "CompanyId" });
            DropTable("dbo.Users");
            DropTable("dbo.Companies");
            DropTable("dbo.Activities");
        }
    }
}
