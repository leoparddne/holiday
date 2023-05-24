using Holiday.Model;
using SQLite;

namespace Holiday.Helper
{
    public class SqliteHelper
    {
        public static List<HolidayDBConfig> GetConfig()
        {
            var db = new SQLiteConnection("./Holiday.db");
            var configs = db.Query<HolidayDBConfig>("select * from holidayconfig").ToList();
            return configs;
        }
    }
}
