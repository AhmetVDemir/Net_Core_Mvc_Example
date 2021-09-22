using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EXC.ViewComponents
{
    public class SolPanelViewComponent:ViewComponent
    {

        public IViewComponentResult Invoke()
        {

           

            return View();
        }
    }
}
