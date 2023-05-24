using Holiday.Model;
using Holiday.Service;

namespace Holiday.Test
{
    [TestClass]
    public class SearchSearchTest
    {
        SearchService service = new SearchService();
        [TestMethod]
        public void Now()
        {
            var result = service.IsHoliday(null, DateTime.Now);
            Console.WriteLine(result);
        }


        [TestMethod]
        public void Weekend()
        {
            var result = service.IsHoliday(null, new DateTime(2023, 5, 27));
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Sunday()
        {
            var result = service.IsHoliday(null, new DateTime(2023, 5, 28));
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void Monday()
        {
            var result = service.IsHoliday(null, new DateTime(2023, 5, 29));
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void Holiday()
        {
            var result = service.IsHoliday(MockConfig(), new DateTime(2023, 5, 1));
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void HolidayTest()
        {
            var result = service.IsHoliday(MockConfig(), new DateTime(2023, 5, 2));
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Workday()
        {
            var result = service.IsHoliday(MockConfig(), new DateTime(2023, 5, 6));
            Assert.IsTrue(result == false);
        }

        private List<HolidayConfig> MockConfig()
        {
            return new List<HolidayConfig>
            {
                new HolidayConfig
                {
                     Day=new DateTime(2023,5,1),
                     Type= Consts.ConfigTypeEnum.Holiday
                },
                new HolidayConfig
                {
                     Day=new DateTime(2023,5,2),
                     Type= Consts.ConfigTypeEnum.Holiday
                },
                new HolidayConfig
                {
                     Day=new DateTime(2023,5,3),
                     Type= Consts.ConfigTypeEnum.Holiday
                },
                new HolidayConfig
                {
                     Day=new DateTime(2023,5,6),
                     Type= Consts.ConfigTypeEnum.Workday
                }
            };
        }
    }
}