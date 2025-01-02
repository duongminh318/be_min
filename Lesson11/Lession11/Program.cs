using Lession11.Factory;
using Lession11.Interface;
using Lession11;

// Áp dụng Factory Pattern: đóng gói quá trình khởi tạo đội tượng
// 1 - tạo ra các đối tượng mà ko cần show ra logic khởi tạo cụ thể của đối tượng đấy
// 2 - dễ dàng mở rộng khi có thêm loại đối tượng mới

IRoom room = RoomFactory.CreateRoom("Deluxe");

// Strategy 
// Cach tinh gia mac dinh
IPricingStrategy pricingStrategy1 = new DefaultPricingStrategy();

// cach tinh moi
IPricingStrategy pricingStrategy2 = new DiscountPricingStrategy();

Booking booking = new Booking(room, pricingStrategy1, includesBreakfast: true, includesWiFi: true);
booking.PrintBookingDetails();