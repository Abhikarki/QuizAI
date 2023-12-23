using Microsoft.AspNetCore.Mvc;


namespace Temp.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public class HomeController : Controller
    {
        [HttpGet]
        [Route("text")]
        public IActionResult Text()
        {
            return Json(new { text = "user entered." });
        }

        [HttpGet]
        [Route("Details")]
        public IActionResult Details()
        {
            return Json(new { text = "user details entered." });
        }


    }
}
