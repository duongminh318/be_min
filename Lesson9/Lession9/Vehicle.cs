using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession9
{
    // Lớp trừu tượng
    public abstract class Vehicle
    {
        public string Name { get; set; }
        // phương thức trừu tượng
        public abstract void Move();

        // Phương thức thông thường
        public void ShowInfo()
        {
            Console.WriteLine($"Đây là {Name}");
        }
    }

    public class Car : Vehicle
    {
        public Car()
        {
            Name = "Car1";
        }
        public override void Move()
        {
            Console.WriteLine($"Xe máy di chuyển 60km/h");
        }
    }

    // Máy bay
    public class Plane : Vehicle
    {
        public Plane()
        {
            Name = "Plane1";
        }
        public override void Move()
        {
            Console.WriteLine($"Máy bay di chuyển 1000km/h");
        }
    }

    public sealed class Boat
    {
        public string Name { get; set; }
    }

    public partial class BoatExten
    {
        public string Name { get; set; }
    }
}
