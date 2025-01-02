using Lession11.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession11
{
    // Base Class chịu trách nhiệm lưu thông tin của phòng
    public abstract class Room : IRoom
    {
        public string Name { get; protected set; }
        public decimal BasePrice { get; protected set; }
    }
}
