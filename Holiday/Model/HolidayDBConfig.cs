using SQLite;

namespace Holiday.Model
{
    public class HolidayDBConfig
    {
        [PrimaryKey, AutoIncrement]
        public string day { get; set; }
        public int type { get; set; }
    }
}
