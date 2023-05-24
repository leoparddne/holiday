using Holiday.Helper;
using Holiday.Model;

namespace Holiday.Service
{
    public class SearchService : ISearchService
    {
        /// <summary>
        /// 获取配置情况
        /// </summary>
        /// <param name="type">1:假期,2:需要上班的日期</param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<HolidayConfig>? SearchConfig(DateTime? startDate, DateTime? endDate)
        {
            var data = SqliteHelper.GetConfig();

            if (data == null)
            {
                return null;
            }

            var result = new List<HolidayConfig>();
            foreach (var item in data)
            {
                DateTime day;
                if (!DateTime.TryParse(item.day, out day))
                {
                    throw new Exception($"异常配置项{item.day}");
                }
                Convert.ToDateTime(item.day);
                result.Add(new HolidayConfig
                {
                    Day = day,
                    Type = (Consts.ConfigTypeEnum)item.type
                });
            }

            return result;
        }

        /// <summary>
        /// 判断是否为假期 - 判断单日
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public bool IsHoliday(List<HolidayConfig>? config, DateTime day)
        {
            //获取到配置为假期
            if (config != null && config!.Count != 0)
            {
                var configDay = config.FirstOrDefault(f => f.Day == day.Date);
                if (configDay != null)
                {
                    if (configDay.Type == Consts.ConfigTypeEnum.Holiday)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            //如果不是假期判断是否为周末
            if (day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// 范围判断
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<HolidayConfig> IsHoliday(DateTime start, DateTime end)
        {
            var tempDay = start;
            var result = new List<HolidayConfig>();
            //获取所有配置
            var config = SearchConfig(start, end);

            while (tempDay < end)
            {
                var isHoliday = IsHoliday(config, tempDay);
                result.Add(new HolidayConfig
                {
                    Day = tempDay,
                    Type = isHoliday ? Consts.ConfigTypeEnum.Holiday : Consts.ConfigTypeEnum.Workday
                });
                tempDay = tempDay.AddDays(1);
            }

            return result;
        }
    }
}