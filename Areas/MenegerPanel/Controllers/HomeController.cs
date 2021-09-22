using EXC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EXC.Areas.MenegerPanel.Controllers
{




    [Area("MenegerPanel")]
    public class HomeController : Controller
    {
        SinavContext _context;
        public HomeController(SinavContext sinavContext)
        {
            _context = sinavContext;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Admin a)
        {
            var adminUserInfo = _context.Admins.FirstOrDefault(x => x.UserName == a.UserName && x.Password == a.Password);

            if (adminUserInfo != null)
            {
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name, a.UserName)
                };

                var kulkim = new ClaimsIdentity(claims, "Login");

                ClaimsPrincipal cp = new ClaimsPrincipal(kulkim);

                await HttpContext.SignInAsync(cp);


                return RedirectToAction("AdminPanel", "Home");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [Authorize]
        public IActionResult AdminPanel()
        {

            return View();
        }

        //----------------------- Soru Ekle ----------------------------------

        [Authorize]
        public IActionResult SoruEkle()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult SoruEkle(Exam Es)
        {
            _context.Exams.Add(Es);
            _context.SaveChanges();

            DonusCevap dc = new DonusCevap("Ekleme Başarılı");
            

            return View("AddSuccess",dc);
        }

        //----------------------Soru Sil--------------------------------------------

        [Authorize]
        public IActionResult SoruSil()
        {

            List<Exam> soruListesi = new List<Exam>();
            soruListesi = _context.Exams.ToList();

            ViewBag.SoruListesi = soruListesi;

            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult SoruSil(int Id)
        {
            DonusCevap dc;

            Exam tmpObj = _context.Exams.Find(Id);
            if (tmpObj != null)
            {
                _context.Exams.Remove(tmpObj);
                _context.SaveChanges();
                dc = new DonusCevap("Başarılı");
            }
            else
            {
                dc = new DonusCevap("Başarısız");
            }

            return View("AddSuccess", dc);
        }


        //----------------------Soru Güncelle--------------------------------------------

        [Authorize]
       public IActionResult SoruGuncelle()
        {
            List<Exam> questList = new List<Exam>();
            questList = _context.Exams.ToList();

            ViewBag.SoruListesi = questList;

            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult SoruGuncelle(int Id)
        {
            Exam tmpObj = _context.Exams.Find(Id);

            return RedirectToAction("Update", tmpObj);
        }


        [Authorize]
        public IActionResult Update(Exam ex)
        {

            return View("UniqUp",ex);
        }

        [HttpPost]
        [Authorize]
        public IActionResult finish(Exam ex)
        {


            DonusCevap dc;

            if (ex != null)
            {
                _context.Exams.Update(ex);
                _context.SaveChanges();
                dc = new DonusCevap("Güncelleme Başarılı");
            }
            else
            {
                dc = new DonusCevap("Güncelleme Başarısız");
            }

            return View("AddSuccess", dc);
        }

    }
}
