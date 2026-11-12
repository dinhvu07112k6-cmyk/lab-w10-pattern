using lab_10.Patterns;
using lab_w10_pattern.Devices;
using lab_w10_pattern.Interface;
using lab_w10_pattern.Patterns;
using System;
using System.Collections.Generic;
using System.Text;
Console.OutputEncoding = Encoding.UTF8; // dùng bảng mã UTF-8 để hiển thị tiếng Việt

//1
//IDevice light = new SmartLight("đèn phòng khách");

//light.TurnOn();
//light.TurnOff();

//IDevice fan = new SmartFan("Living room fan");
//fan.TurnOn();
//fan.TurnOff();

//SmartDoor door = new SmartDoor("Main door");
//door.TurnOn();
//door.TurnOff();
//door.Lock();
//door.Unlock();

// Phần 2: Sử dụng DeviceFactory để tạo các thiết bị
IDevice light = DeviceFactory.Create(" LIGHT ", "Living room light");
IDevice fan = DeviceFactory.Create("fan", "Living room fan");
IDevice door = DeviceFactory.Create("door", "Main door");

Console.WriteLine(light.GetType().Name);
Console.WriteLine(fan.GetType().Name);
Console.WriteLine(door.GetType().Name);

light.TurnOn();
fan.TurnOff();

if (door is ILockable lockableDoor)
{
    lockableDoor.Lock();
}

try
{
    DeviceFactory.Create("camera", "Camera");
}
catch (ArgumentException e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine("--- Singleton ---");

HomeConfiguration config1 = HomeConfiguration.Instance;
HomeConfiguration config2 = HomeConfiguration.Instance;

bool sameInstance = ReferenceEquals(config1, config2);
Console.WriteLine($"Same instance: {sameInstance}");

if (!sameInstance)
{
    throw new Exception("Singleton implementation is incorrect.");
}

config1.HomeName = "Vu Home";
config1.NightLightLevel = 20;

Console.WriteLine(config2.HomeName);
Console.WriteLine(config2.NightLightLevel);