using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sampleapi.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public string DOB { get; set; }
        public string ContactNumber { get; set; }
    }
}