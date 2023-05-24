using Holiday.Helper;
using Holiday.Model;
using Holiday.Service;
using Newtonsoft.Json;

namespace Holiday.Test
{
    [TestClass]
    public class SqliteTest
    {
        [TestMethod]
        public void Get()
        {
            var result = SqliteHelper.GetConfig();
            Console.WriteLine(JsonConvert.SerializeObject(result));
        }

    }
}