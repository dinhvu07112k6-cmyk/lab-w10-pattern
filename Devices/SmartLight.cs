/****************/
//Mã sinh viên  : 202419021 
//Họ tên  : Phạm Đình Vũ
/****************/

using lab_w10_pattern.Interface;

namespace lab_w10_pattern.Devices
{
    public class SmartLight : IDevice
    {
        public string Name { get; }
        
        public SmartLight(string name)
        {
            Name = name;
        }

        public void TurnOn()
        {
            Console.WriteLine($"{Name} : ON");
        }

        public void TurnOff()
        {
            Console.WriteLine($"{Name} : OFF");
        }

}
}
