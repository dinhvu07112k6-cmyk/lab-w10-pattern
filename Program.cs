using lab_w10_pattern.Interface;
using lab_w10_pattern.Devices;

IDevice light = new SmartLight("đèn phòng khách");

light.TurnOn();
light.TurnOff();