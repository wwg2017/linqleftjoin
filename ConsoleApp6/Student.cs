using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int StandardId { get; set; }//水平
        public int State { get; set; }
        public int Source { get; set; }
    }
    public class Standard
    {
        public int StandardId { get; set; }
        public string StandardName { get; set; }//
    }
}
