using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
