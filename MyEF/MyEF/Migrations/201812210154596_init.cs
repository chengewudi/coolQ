namespace MyEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GId = c.Int(nullable: false),
                        GName = c.String(),
                        LastTicketTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.GId);
            
            CreateTable(
                "dbo.Idols",
                c => new
                    {
                        SId = c.Int(nullable: false),
                        Name = c.String(),
                        BirthDay = c.String(),
                        BirthPlace = c.String(),
                        Height = c.Double(nullable: false),
                        Hobby = c.String(),
                        Speciality = c.String(),
                        Catch_phrase = c.String(),
                        Join_day = c.String(),
                        NickName = c.String(),
                        status = c.Int(nullable: false),
                        BloodType = c.String(),
                        Weibo_uid = c.Long(nullable: false),
                        Weibo_verifier = c.String(),
                        GId = c.Int(nullable: false),
                        TId = c.Int(nullable: false),
                        PId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SId)
                .ForeignKey("dbo.Groups", t => t.GId, cascadeDelete: true)
                .ForeignKey("dbo.Periods", t => t.PId, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.TId, cascadeDelete: true)
                .Index(t => t.GId)
                .Index(t => t.TId)
                .Index(t => t.PId);
            
            CreateTable(
                "dbo.Periods",
                c => new
                    {
                        PId = c.Int(nullable: false),
                        PName = c.String(),
                    })
                .PrimaryKey(t => t.PId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TId = c.Int(nullable: false),
                        TName = c.String(),
                    })
                .PrimaryKey(t => t.TId);
            
            CreateTable(
                "dbo.QQGroupHistoryMsgs",
                c => new
                    {
                        SpeekTime = c.DateTime(nullable: false),
                        SpeakerId = c.Long(nullable: false),
                        GroupName = c.String(),
                        Speaker = c.String(),
                        msg = c.String(),
                    })
                .PrimaryKey(t => new { t.SpeekTime, t.SpeakerId });
            
            CreateTable(
                "dbo.QQGroups",
                c => new
                    {
                        GroupId = c.Long(nullable: false),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Idols", "TId", "dbo.Teams");
            DropForeignKey("dbo.Idols", "PId", "dbo.Periods");
            DropForeignKey("dbo.Idols", "GId", "dbo.Groups");
            DropIndex("dbo.Idols", new[] { "PId" });
            DropIndex("dbo.Idols", new[] { "TId" });
            DropIndex("dbo.Idols", new[] { "GId" });
            DropTable("dbo.QQGroups");
            DropTable("dbo.QQGroupHistoryMsgs");
            DropTable("dbo.Teams");
            DropTable("dbo.Periods");
            DropTable("dbo.Idols");
            DropTable("dbo.Groups");
        }
    }
}
