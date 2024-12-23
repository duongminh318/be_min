using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnOOP2.Ex1
{
    public class Student : Person
    {
        public int StudentID { get; set; }
        public List<Course> Courses { get; set; }

        public Student(string firstName, string lastName, int age, int studentID)
            : base(firstName, lastName, age)
        {
            StudentID = studentID;
            Courses = new List<Course>();
        }

        public void EnrollCourse(Course course)
        {
            Courses.Add(course);
        }

        public void DisplayStudentInfo()
        {
            DisplayInfo();
            Console.WriteLine($"Student ID: {StudentID}");
			var courseNames = Courses.Select(s => s.CourseName).ToList();
			Console.WriteLine("Enrolled Courses: " + string.Join(", ", courseNames));
        }
    }

}
