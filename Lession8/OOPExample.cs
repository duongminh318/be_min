using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession8
{
    public class Student
    {
        #region Attribute

        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime BirthDay { get; set; }

        #endregion

        #region Ctor  -- dùng để khởi tạo các giá trị cho các thuộc tính cho 1 instance

        public Student(int studentId, string Name, int age, DateTime birthDay)
        {
            StudentId = studentId;
            this.Name = Name;
            Age = age;
            BirthDay = birthDay;
            // có thể thực hiện các phương thức của đối tượng
        }

        public Student(int studentId, string Name)
        {
            StudentId = studentId;
            this.Name = Name;
        }

        #endregion

        #region Method

        public void DisplayStudent()
        {
            Console.WriteLine(this.StudentId);
        }

        #endregion





    }
}
