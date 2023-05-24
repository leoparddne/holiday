using Holiday.Model;
using SQLite;

namespace Holiday.Helper
{
    public class SqliteHelper
    {
        public static List<HolidayDBConfig> GetConfig(DateTime? startDate, DateTime? endDate)
        {
            string where = "";
            if (startDate != null)
            {
                var str = startDate.Value.ToString("yyyy-MM-dd");

                AddWhere(where, $"day>={str}");
            }
            if (endDate != null)
            {
                var str = endDate.Value.ToString("yyyy-MM-dd");

                AddWhere(where, $"day<={str}");
            }


            var db = new SQLiteConnection("./Holiday.db");
            var configs = db.Query<HolidayDBConfig>("select * from holidayconfig").ToList();
            return configs;
        }

        public static string AddWhere(string where, string newWhere)
        {
            if (string.IsNullOrEmpty(where))
            {
                where += newWhere;
            }
            else
            {
                where += " and " + newWhere;
            }

            return where;
        }
    }
}
