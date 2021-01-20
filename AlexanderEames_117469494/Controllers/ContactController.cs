using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AlexanderEames_117469494.Controllers
{
    public class ContactController : Controller
    {
        [Route("Contact")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}
