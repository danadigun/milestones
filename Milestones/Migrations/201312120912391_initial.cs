namespace Milestones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        DateOfBirth = c.String(),
                        MaritalStatus = c.String(),
                        Occupation = c.String(),
                        PlaceOfOrigin = c.String(),
                        email = c.String(),
                        phone = c.String(),
                        Address = c.String(),
                        UserName = c.String(),
                        Password = c.String(maxLength: 100),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.ScreeningTests",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        Question = c.String(),
                        weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Questionnaires",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        WeightYes = c.Int(nullable: false),
                        WeightNo = c.Int(nullable: false),
                        question = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.LatestActivities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        LeadingContent = c.String(),
                        content = c.String(),
                        DateCreated = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.CompletedQuestionnaires",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        useremail = c.String(),
                        WeightYes = c.Int(nullable: false),
                        WeightNo = c.Int(nullable: false),
                        question = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.FeedBacks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        Message = c.String(),
                        CommunicationMethod = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AnsweredQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        QuestionId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ViewedAssessments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        DateViewed = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ViewedAssessments");
            DropTable("dbo.AnsweredQuestions");
            DropTable("dbo.FeedBacks");
            DropTable("dbo.CompletedQuestionnaires");
            DropTable("dbo.LatestActivities");
            DropTable("dbo.Questionnaires");
            DropTable("dbo.ScreeningTests");
            DropTable("dbo.UserProfile");
        }
    }
}
