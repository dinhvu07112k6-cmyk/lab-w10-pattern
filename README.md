# Lab 10 – Smart Home Mini

Ứng dụng điều khiển đèn, quạt và cửa thông minh.

## Các pattern

- Factory nằm trong DeviceFactory.Create(). Tạo thiết bị theo loại
  người dùng chọn và trả về IDevice, giúp tập trung logic khởi tạo.
- Singleton nằm trong HomeConfiguration.Instance. Các nơi trong
  ứng dụng dùng chung một đối tượng cấu hình.



## Hạn chế

Singleton giữ cấu hình dùng chung có thể thay đổi, nên các bài kiểm thử
cần khôi phục cấu hình để tránh ảnh hưởng lẫn nhau.
