/****************/
//Mã sinh viên  : 202419021 
//Họ tên  : Phạm Đình Vũ
/****************/


namespace lab_w10_pattern.Patterns
{
    public sealed class HomeConfiguration
    {
        private static readonly Lazy<HomeConfiguration> lazy =
            new Lazy<HomeConfiguration>(() => new HomeConfiguration());

        public static HomeConfiguration Instance => lazy.Value;

        public string HomeName { get; set; } = "My Home";
        public int NightLightLevel { get; set; } = 30;

        private HomeConfiguration()
        {
        }
    }
}