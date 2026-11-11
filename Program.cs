using System;
using System.Collections.Generic;
using System.Text;
using lab_w10_pattern.Interface;
using lab_w10_pattern.Devices;
Console.OutputEncoding = Encoding.UTF8; // dùng bảng mã UTF-8 để hiển thị tiếng Việt


IDevice light = new SmartLight("đèn phòng khách");

light.TurnOn();
light.TurnOff();

IDevice fan = new SmartFan("Living room fan");
fan.TurnOn();
fan.TurnOff();

SmartDoor door = new SmartDoor("Main door");
door.TurnOn();
door.TurnOff();
door.Lock();
door.Unlock();