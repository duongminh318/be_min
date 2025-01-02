using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnOOP2.Ex1
{
	public static class Ex1Manager
	{
		public static void Init()
		{
			var tearcherA = new Teacher("tc", "A", 30, 1);
			var tearcherB = new Teacher("tc", "B", 30, 2);

			var studentA = new Student("std", "A", 10, 1);
			var studentB = new Student("std", "B", 11, 2);

			var engCourse = new Course("english");

			engCourse.AddTeacher(tearcherA);
			engCourse.EnrollStudent(studentA);
			engCourse.EnrollStudent(studentB);

            Console.WriteLine("Teachers:...");
			tearcherA.DisplayTeacherInfo();
            Console.WriteLine("Course: ....");
            engCourse.DisplayCourseInfo();

        }
	}
}
