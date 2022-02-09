using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy2.DataAccessLibrary.Models
{
    public class TaskList
    {
        [Key]
        public int TaskId { get; set; }
        public string Task { get; set; }
        public DateOnly Date { get; set; }
        public int EmpId { get; set; }
        public int Rating { get; set; }
        public string Remark { get; set; }
        public bool Extension { get; set; }
    }
}
