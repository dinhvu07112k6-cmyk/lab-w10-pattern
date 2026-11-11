/****************/
//Mã sinh viên  : 202419021 
//Họ tên  : Phạm Đình Vũ
/****************/


using lab_w10_pattern.Interface;

namespace lab_w10_pattern.Devices
{
    public  class SmartDoor : IDevice, ILockable
    {
        public string Name { get; }
        public SmartDoor(string name)
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
        public void Lock()
        {
            Console.WriteLine($"{Name} : LOCKED");
        }
        public void Unlock()
        {
            Console.WriteLine($"{Name} : UNLOCKED");
        }
   
    }
}
