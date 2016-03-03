using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Milestones.Models
{
    public class CompletedQuestionnaire
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string useremail { get; set; }
        public int WeightYes { get; set; }
        public int WeightNo { get; set; }
        public string question { get; set; }
    }
}