using Holiday.Model;
using System.Linq.Expressions;

namespace Holiday.Service
{
    public class SearchService : ISearchService
    {
        /// <summary>
        /// 查询所有法定假期
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<DateTime> Search(DateTime? startDate, DateTime? endDate)
        {
            //获取配置
            var config = SearchConfig(null, startDate, endDate);


            //获取所有休假的周末

            //法定假期
            //var config = SearchConfig( , startDate, endDate);


            return new List<DateTime> { };
        }

        /// <summary>
        /// 获取配置情况
        /// </summary>
        /// <param name="type">1:假期,2:需要上班的日期</param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<HolidayConfig> SearchConfig(int? type, DateTime? startDate, DateTime? endDate)
        {
            return new List<HolidayConfig> { };
        }


        /// <summary>
        /// 获取默认的周末
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<DateTime> GetWeekend(DateTime? startDate, DateTime? endDate)
        {
            //固定的周末中移除需要上班的日期
            var weekend = GetWeekend(startDate, endDate);


            return new List<DateTime> { };
        }

        /// <summary>
        /// 获取默认的周末
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<DateTime> GetDefaultWeekend(DateTime? startDate, DateTime? endDate)
        {
            return new List<DateTime> { };
        }

        /// <summary>
        /// 判断是否为假期 - 判断单日
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public bool IsHoliday(List<HolidayConfig> config, DateTime day)
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
                }
            }

            //如果不是假期判断是否为周末
            if (day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday)
            {
                return true;
            }

            return false;
        }

        public List<HolidayConfig> IsHoliday(DateTime start, DateTime end)
        {
            var tempDay = start;
            var result = new List<HolidayConfig>();
            //获取所有配置
            var config = SearchConfig(null, start, end);

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