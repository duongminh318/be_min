using Lession11.Concrete;
using Lession11.Interface;

namespace Lession11.Factory
{
    // Factory
    public class RoomFactory
    {
        public static IRoom CreateRoom(string roomType)
        {
            return roomType switch
            {
                "Standard" => new StandardRoom(),
                "Deluxe" => new DeluxeRoom(),
                "Suite" => new SuiteRoom(),
                _ => throw new ArgumentException("Invalid room type")
            };
        }
    }
}
