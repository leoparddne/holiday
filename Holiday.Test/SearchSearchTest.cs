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
    }
}