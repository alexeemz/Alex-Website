using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AlexanderEames_117469494.Controllers
{
    public class AboutController : Controller
    {
       [Route("About")]
       [Route("AboutMe")] //Users can access page from this url too -> ~/AboutMe
        public IActionResult About()
        {
            return View();
        }
    }
}
