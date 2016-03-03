using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Milestones.Models
{
    public class MilestoneDb: DbContext
    {
          public MilestoneDb()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<ScreeningTest> ScreeningTests { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<LatestActivities> LatestActivities { get; set; }
        public DbSet<CompletedQuestionnaire> CompletedQuetionnaires { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<AnsweredQuestion> AnsweredQuestions { get; set; }
        public DbSet<ViewedAssessments> ViewedAssessments { get; set; }
    }
  
}