using Holiday.Service;

namespace Holiday.Test
{
    [TestClass]
    public class SearchSearchTest
    {
        SearchService service = new SearchService();
        [TestMethod]
        public void TestMethod1()
        {
            var result = service.IsHoliday(null, DateTime.Now);
            Console.WriteLine(result);
        }
    }
}