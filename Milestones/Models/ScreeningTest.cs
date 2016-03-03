using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Milestones.Models
{
    public class ScreeningTest
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string username { get; set; }
        public string Question { get; set; }
        //public string answer { get; set; }
        public decimal weight { get; set; }
        public DateTime DateCreated { get; set; }
    }
}