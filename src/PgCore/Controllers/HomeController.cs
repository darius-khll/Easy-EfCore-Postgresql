using Microsoft.AspNetCore.Mvc;

namespace PgCore.Controllers
{
    public class HomeController : Controller
    {
        private IDataAccessProvider _db;
        public HomeController(IDataAccessProvider db)
        {
            _db = db;
        }

        public string Index()
        {
            var data1 = _db.GetDataEventRecords();
            var data3 = _db.GetSourceInfos(true);
            return "wow...";
        }
    }
}
