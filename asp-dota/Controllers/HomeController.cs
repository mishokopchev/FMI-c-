using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using asp_dota.Models;
using aspdota.Serializer;
using aspdota.XmlDto;
using System.IO;
using aspdota.Commons;

namespace asp_dota.Controllers
{
    public class HomeController : Controller
    {
        private IReader<Dota> _reader;

        public HomeController(IReader<Dota> reader)
        {
            this._reader = reader;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Misho()
        {
            return ValidateContent();
        }

        public IActionResult ValidateContent()
        {
            string fs = "/Users/mihailkopchev/Projects/asp-dota/asp-dota/XML";
            string[] files = Directory.GetFiles(fs);

            var xmls = new List<Pair<string, bool>>();
            foreach (string file in files)
            {
                if (file.EndsWith(".xml"))
                {
                    bool valid = _reader.ValidateInput(file);
                    var pair = new Pair<string, bool>(file,valid);
                    xmls.Add(pair);
                }

                ViewBag.list = xmls;
            }
            return View();
        }

        public void InsertFiles(){
            
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
