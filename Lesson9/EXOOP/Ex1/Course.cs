namespace LearnOOP2.Ex1
{
	public class Course
	{
		public string CourseName { get; set; }
		public Teacher CourseTeacher { get; set; }
		public List<Student> EnrolledStudents { get; set; }

		public Course(string courseName)
		{
			CourseName = courseName;
			EnrolledStudents = new List<Student>();
		}

		public void EnrollStudent(Student student)
		{
			EnrolledStudents.Add(student);
			student.EnrollCourse(this);
		}

		public void AddTeacher(Teacher teacher)
		{
			CourseTeacher = teacher;
			teacher.AddCourse(this);
		}
		public void DisplayCourseInfo()
		{
			Console.WriteLine($"Course: {CourseName}");
			Console.WriteLine("Teacher: ");
			CourseTeacher.DisplayTeacherInfo();
			Console.WriteLine("Enrolled Students: ");
			foreach (var student in EnrolledStudents)
			{
				student.DisplayStudentInfo();
			}
		}
	}

}
