using EXC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EXC.Controllers
{
    public class SorularController : Controller
    {

        SinavContext _sinavContext;
        public SorularController(SinavContext sinavContext)
        {
            _sinavContext = sinavContext;
        }

        [HttpGet]
        public IActionResult GetSorular()
        {
            var GelenSorular = _sinavContext;

            List<Exam> gosterilecekSoru = new List<Exam>();
            gosterilecekSoru = GelenSorular.Exams.ToList();
            List<Exam> tempQuestions = new List<Exam>();

            Random r = new Random();
            int sayac = 0;
            bool isExist = false;

            for (int j = 0; j < gosterilecekSoru.Count; j++)
            {
                sayac = r.Next(0, gosterilecekSoru.Count);
                for (int i = 0; i < tempQuestions.Count; i++)
                {
                    if (tempQuestions[i].Id == gosterilecekSoru[sayac].Id)
                    {
                        isExist = true;
                    }
                }
                if (!isExist)
                {
                    tempQuestions.Add(gosterilecekSoru[sayac]);
                }
                isExist = false;
                if (tempQuestions.Count == 5)
                {
                    break;
                }
            }

            ViewBag.TempQuestion = tempQuestions;
            
            return View();
        }

        public static List<Sonuc> tmpSonuc;
        
        [HttpPost]
        public IActionResult GetSorular(List<Sonuc> answers)
        {
            var gelenSorular = _sinavContext;

            int dogruSayisi = 0;

            List<Exam> tmpSoruListesi;
            tmpSoruListesi = gelenSorular.Exams.ToList();

            for(int i = 0; i < tmpSoruListesi.Count; i++)
            {

                for(int j = 0; j < answers.Count; j++)
                {
                    if (tmpSoruListesi[i].Id == answers[j].Id)
                    {
                        if(tmpSoruListesi[i].Answer == answers[j].Answer)
                        {
                            dogruSayisi++;
                        }
                        
                    }
                   
                }

            }

            SinavSonucu tmpSonuc = new SinavSonucu() { DogruSayisi = dogruSayisi, SoruSayisi = answers.Count };

            return View("SorularSonuc", tmpSonuc);
        }

       
    }
}
