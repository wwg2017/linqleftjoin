using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {           
            IList<Student> studentList = new List<Student>()
            {
                new Student() {StudentId = 1, StudentName = "John", StandardId = 1,State=1,Source=12},
                new Student() {StudentId = 2, StudentName = "Moin", StandardId = 1,State=1,Source=6},
                new Student() {StudentId = 3, StudentName = "Bill", StandardId = 2,State=1,Source=9},
                new Student() {StudentId = 4, StudentName = "Ram", StandardId = 3,State=1,Source=2},
                new Student() {StudentId = 5, StudentName = "Ron",StandardId = 4,State=0,Source=4},
                new Student() {StudentId = 1, StudentName = "Ron",StandardId = 2,State=0,Source=9}
            };
            IList<Standard> standardList = new List<Standard>()
            {
                new Standard() {StandardId = 1, StandardName = "优秀"},
                new Standard() {StandardId = 2, StandardName = "中等"},
                new Standard() {StandardId = 3, StandardName = "差生"}
            };

            var temp = from stu in studentList
                       join
    stan in standardList on stu.StandardId equals stan.StandardId into temps

                       from tt in temps.DefaultIfEmpty()
                       select new
                       {
                           standardId = stu.StandardId,
                           sname = stu.StudentName,
                           bname = tt == null ? "" : tt.StandardName,//这里主要第二个集合有可能为空。需要判断
                           source= Ca(stu.Source,stu.State)
                       };
            var slist = temp.GroupBy(p => new { p.standardId }).Select(j => new Student
            {
                StandardId = j.Key.standardId,
                Source = j.Sum(x => x.source)
            }).ToList();
        }
        public static int Ca(int s,int type)
        {
            var ksource = 0;
            switch (type)
            {
                case 1:
                    ksource = s*2;
                    break;
                
            }
            return ksource;
        }
    }
}
