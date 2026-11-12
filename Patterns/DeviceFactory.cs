/****************/
//Mã sinh viên  : 202419021 
//Họ tên  : Phạm Đình Vũ
/****************/

using lab_w10_pattern.Interface;
using lab_w10_pattern.Devices;

namespace lab_w10_pattern.Patterns
{
    public static class DeviceFactory
    {
        public static IDevice Create(string type, string name)
         {
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException("Device type must not be empty.", nameof(type));
            }
            return type.Trim().ToLowerInvariant() switch
            {
                "light" => new SmartLight(name),
                "fan" => new SmartFan(name),
                "door" => new SmartDoor(name),
                _ => throw new ArgumentException($"Unsupported device type: {type}", nameof(type)),
            };
        }
    }
}
