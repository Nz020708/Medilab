using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medilab.Areas.AdminPanel.Controllers
{
    public class DashBoardController : Controller
    {
        [Area("AdminPanel")]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
