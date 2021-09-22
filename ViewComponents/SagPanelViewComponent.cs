using EXC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EXC.ViewComponents
{
    public class SagPanelViewComponent : ViewComponent
    {
        public SinavContext _sinavContext;
        public SagPanelViewComponent(SinavContext sinavContext)
        {
            _sinavContext = sinavContext;
        }
       
        public IViewComponentResult Invoke()
        {

            var veri = _sinavContext.Zamans.ToList();

            return View(veri);
        }
    }
}
