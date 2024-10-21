using Microsoft.AspNetCore.Mvc;

namespace EquityCalculatorAPI.Controllers
{
    public class EquityCalculatorViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
