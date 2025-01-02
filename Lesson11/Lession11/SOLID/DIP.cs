using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession11.SOLID
{

    public class SqlDatabase
    {
        public void Connect() => Console.WriteLine("Connect to SQL database");
    }

    public class DataProcessor
    {
        private readonly SqlDatabase _database;

        public DataProcessor(SqlDatabase database)
        {
            _database = database;
        }

        public void Process()
        {
            _database.Connect();
            Console.WriteLine("Processing data");
        }
    }

    // I
    public interface IDatabase
    {
        void Connect();
    }

    // A
    public class SqlDatabase1 : IDatabase 
    {
        public void Connect() => Console.WriteLine("Connect to SQL database");
    }

    // B
    public class MongoDBDatabase : IDatabase
    {
        public void Connect() => Console.WriteLine("Connect to Mongo database");
    }

    // C
    // Thằng C muốn sử dung sql (A) hay muốn sử dụng mongo(B) thì Injection (chọn thằng A hoặc B để gán vào I)
    public class DataProcessor1
    {
        private readonly IDatabase _database;
        public DataProcessor1(IDatabase database)
        {
            _database = database;
        }

        public void Process()
        {
            _database.Connect();
            Console.WriteLine("Processing data");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            // Khi mà sử dụng Sql database
            IDatabase database = new SqlDatabase1();  // Injection qua hàm tạo
            var dataProcessor1 = new DataProcessor1(database);
            dataProcessor1.Process();  // sử dụng sql database

            // Khi mà sử dụng mông database
            IDatabase database1 = new MongoDBDatabase();
            var dataProcessor2 = new DataProcessor1(database1);
            dataProcessor2.Process();  // sử dụng mongo database
        }
    }

}
