using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy2.DataAccessLibrary.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }
        public DateOnly Date { get; set; }
        public string Status { get; set; }
        public int EmpId { get; set; }
    }
}
