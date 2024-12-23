using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnOOP2.Ex1
{
	public class Teacher : Person
	{
		public int TeacherID { get; set; }
		public List<Course> TeachingCourses { get; set; }

		public Teacher(string firstName, string lastName, int age, int teacherID)
			: base(firstName, lastName, age)
		{
			TeacherID = teacherID;
			TeachingCourses = new List<Course>();
		}

		public void AddCourse(Course course)
		{
			TeachingCourses.Add(course);
		}

		public void DisplayTeacherInfo()
		{
			DisplayInfo();
			Console.WriteLine($"Teacher ID: {TeacherID}");
			var courseNames = TeachingCourses.Select(s => s.CourseName).ToList();
			Console.WriteLine("Teaching Courses: " + string.Join(", ", courseNames));
		}
	}


}
