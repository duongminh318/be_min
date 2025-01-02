namespace Lession11.SOLID;

// bad
public class PaymentProcessor
{
    public void ProcessPayment(string type)
    {
        if (type == "CreditCard")
        {
            // handle logic
            Console.WriteLine("ProcessPayment is CreditCard");
        }
        if (type == "COD")
        {
            // handle logic
            Console.WriteLine("ProcessPayment is COD");
        }
        if (type == "Paypal")
        {
            // handle logic
            Console.WriteLine("ProcessPayment is COD");
        }
        if (type == "COD")
        {
            // handle logic
            Console.WriteLine("ProcessPayment is COD");
        }
        if (type == "COD")
        {
            // handle logic
            Console.WriteLine("ProcessPayment is COD");
        }
    }

    // good
    // 1. định nghĩa ra 1 interface về nghiệp đấy (cụ thể là xử lý nghiệp vụ thanh toán)
    // 2. Chuyển đổi các paymentType thành từng class riêng rẽ và kế thừa interface => implementation hàm xử lý của interface
    // 3. Mỗi khi nghiệp vụ mở rộng tạo thêm các class và kế thừa interface

    public interface IPayment
    {
        void Payment();
    }

    public class CreditCard : IPayment
    {
        public void Payment()
        {
            // handle logic
            Console.WriteLine("ProcessPayment is CreditCard");
        }
    }

    public class COD : IPayment
    {
        public void Payment()
        {
            // handle logic
            Console.WriteLine("ProcessPayment is COD");
        }
    }

}
