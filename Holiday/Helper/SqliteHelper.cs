using Holiday.Model;
using SQLite;

namespace Holiday.Helper
{
    public class SqliteHelper
    {
        public static List<HolidayDBConfig> GetConfig()
        {
            // 创建数据库
            var db = new SQLiteConnection("./Holiday.db");
            var configs = db.Query<HolidayDBConfig>("select * from holidayconfig").ToList();
            return configs;
        }
    }
}
