using lab_w10_pattern.Devices;
using lab_w10_pattern.Interface;
using lab_w10_pattern.Patterns;
using System.IO;

int passed = 0;
int failed = 0;

void Check(string name, bool condition)
{
    Console.WriteLine($"{(condition ? "PASS" : "FAIL")} | {name}");

    if (condition)
        passed++;
    else
        failed++;
}

// T1: Factory trả đúng loại, chấp nhận chữ hoa và khoảng trắng
IDevice light = DeviceFactory.Create(" LIGHT ", "Living room light");
IDevice fan = DeviceFactory.Create("fan", "Living room fan");
IDevice door = DeviceFactory.Create("door", "Main door");

Check("T1 - Factory creates correct device types",
    light is SmartLight &&
    fan is SmartFan &&
    door is SmartDoor);

// T2: Loại chưa hỗ trợ phải ném ArgumentException
bool rejected = false;

try
{
    DeviceFactory.Create("camera", "Camera");
}
catch (ArgumentException)
{
    rejected = true;
}

Check("T2 - Factory rejects unsupported types", rejected);

// T3: Hai lần lấy cấu hình phải nhận cùng một đối tượng
HomeConfiguration config1 = HomeConfiguration.Instance;
HomeConfiguration config2 = HomeConfiguration.Instance;

Check("T3 - Configuration uses one instance",
    ReferenceEquals(config1, config2));

// SmartDoor thực thi ILockable nên phép ép kiểu này hợp lệ
SmartHomeFacade facade =
    new SmartHomeFacade(light, fan, (ILockable)door);

// T4: Kiểm tra chính xác các thao tác và thứ tự
string workOutput = CaptureOutput(facade.GoToWork);

string expectedWork = string.Join(Environment.NewLine,
    "Living room light : OFF",
    "Living room fan : OFF",
    "Main door : LOCKED") + Environment.NewLine;

Check("T4 - Work mode performs correct operations",
    workOutput == expectedWork);

// T5: Chế độ ngủ phải đọc mức sáng đã cấu hình
int oldLevel = config1.NightLightLevel;
config1.NightLightLevel = 20;

string sleepOutput;
try
{
    sleepOutput = CaptureOutput(facade.GoToSleep);
}
finally
{
    config1.NightLightLevel = oldLevel;
}

string expectedSleep = string.Join(Environment.NewLine,
    "Living room fan : OFF",
    "Main door : LOCKED",
    "Living room light : ON",
    "Night light level : 20%") + Environment.NewLine;

Check("T5 - Sleep mode uses configured light level",
    sleepOutput == expectedSleep);

Console.WriteLine($"Result: {passed} PASS, {failed} FAIL");

// Thu nội dung Console.WriteLine để kiểm tra
static string CaptureOutput(Action action)
{
    TextWriter originalOutput = Console.Out;
    using StringWriter buffer = new StringWriter();

    try
    {
        Console.SetOut(buffer);
        action();
        return buffer.ToString();
    }
    finally
    {
        Console.SetOut(originalOutput);
    }
}