# Lab 10 – Smart Home Mini

Ứng dụng console điều khiển đèn, quạt và cửa thông minh bằng C#.

## Các pattern sử dụng

- **Factory:** DeviceFactory.Create(type, name) chọn và tạo
  SmartLight, SmartFan hoặc SmartDoor, rồi trả về IDevice.
  Client không cần tự chọn constructor của từng lớp.

- **Singleton:** HomeConfiguration.Instance cung cấp một đối tượng
  cấu hình dùng chung, gồm HomeName và NightLightLevel.
  Constructor private ngăn việc tạo thêm cấu hình từ bên ngoài.

- **Facade:** SmartHomeFacade cung cấp GoToWork() và GoToSleep().
  Client gọi một phương thức để thực hiện nhiều thao tác trên thiết bị.

## Lợi ích

Logic tạo thiết bị được tập trung tại Factory. Cấu hình được dùng
chung qua Singleton. Facade giúp phần gọi chương trình ngắn hơn
và giảm việc lặp lại các thao tác điều khiển.

## Hạn chế

Cấu hình Singleton có thể bị thay đổi từ nhiều nơi. Khi kiểm thử,
cần khôi phục cấu hình để tránh ảnh hưởng giữa các lần chạy.

## Trả lời câu hỏi

1. **Factory che giấu quyết định nào?**
   Quyết định chọn lớp thiết bị cụ thể và gọi constructor tương ứng
   dựa trên loại được yêu cầu.

2. **Singleton bảo đảm điều gì và có rủi ro nào?**
   Cung cấp một thể hiện cấu hình dùng chung. Rủi ro là trạng thái
   dùng chung làm các phần chương trình phụ thuộc nhau và khó kiểm thử.

3. **Facade khác Factory thế nào?**
   Factory tạo đối tượng. Facade phối hợp các đối tượng để cung cấp
   thao tác ở mức cao hơn.

4. **Nếu bỏ Facade thì client cần biết thêm gì?**
   Client phải tự gọi từng thiết bị và biết thứ tự thao tác.
   Ví dụ, chế độ đi làm cần tắt đèn, tắt quạt và khóa cửa.
