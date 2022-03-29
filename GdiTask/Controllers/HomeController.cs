using GdiTask.Data;
using GdiTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GdiTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;


        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //ReadFile();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        
        
        }

        public  void ReadFile()
        {

            foreach (string line in System.IO.File.ReadLines("extractZip/DURS_zavezanci_PO.txt"))
            {

                var data = new Model()
                {

                    ObsegIdentifikacije = ObsegId(line.Substring(0, 1)),
                    OmejenObsegIdentifikacije = line.Substring(2, 1) == "*",
                    DavcnaStevilka = Convert.ToInt64(line.Substring(4, 8)),
                    MaticnaStevilka = line.Substring(13, 10),
                    DatumPO = DatPo(line.Substring(24, 10)),
                    Skd = line.Substring(35, 6),
                    ImePodjetja = line.Substring(42, 100),
                    NaslovPodjetja = line.Substring(143, 113),
                    ObcinskaEnota = Convert.ToInt16(line.Substring(257, 2)),

                };
                //omogoči, da se podatki ne podvajajo v bazi
                if (_context.ZavezanciPO.Any(o => o.DavcnaStevilka == data.DavcnaStevilka))
                    continue;
                _context.Attach(data);
         
            }

            _context.SaveChanges();
        }

        public static DateTime? DatPo(string dateAline)
        {
            if (dateAline.Contains(" "))
            {

                return null;
            }
            else return DateTime.Parse(dateAline);

        }




        public static bool? ObsegId(string pAlioAlinull)
        {
            if (pAlioAlinull.Equals("O"))
            {
                return true;
            }
            if (pAlioAlinull.Equals("P"))
            {
                return false;
            }
            return null;

        }
    }
}
