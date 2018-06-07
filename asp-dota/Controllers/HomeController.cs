using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using asp_dota.Models;
using aspdota.Serializer;
using aspdota.XmlDto;
using System.IO;
using aspdota.Commons;
using aspdota.Repository;
using aspdota.Adapter;
using aspdota.Models;

namespace asp_dota.Controllers
{
    public class HomeController : Controller
    {
        private IReader<Dota> _reader;
        private IAdapter<DotaEntity,Dota> _adapter;
        private IDotaRepository _dotaRepository;


        public HomeController(IReader<Dota> Reader,IAdapter<DotaEntity,Dota> Adapter,IDotaRepository DotaRepository)
        {
            this._reader = Reader;
            this._adapter = Adapter;
            this._dotaRepository = DotaRepository;
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
        public IActionResult ImportContent(){

            var pairs = new List<Pair<string, string>>();
            string objfile = "";
            try
            {
                string fs = "/Users/mihailkopchev/Projects/asp-dota/asp-dota/XML";
                string pattern = ".xml";
                string[] files = Directory.GetFiles(fs);
                foreach(string file in files){
                    if(file.EndsWith(pattern)){
						objfile = file;
						Dota dota1 = _reader.Deserialize(file);
						DotaEntity entity = _adapter.Adapt(dota1);
						_dotaRepository.Persist(entity);
						var pair = new Pair<string, string>(file, "Imported");
						pairs.Add(pair);
                    }
                }
            }
            catch (Exception e)
            {
                var pair = new Pair<string, string>(objfile, "Not Imported");
                pairs.Add(pair);
                Console.WriteLine(e);

            }
            ViewBag.list = pairs;
            return View();
        }

        public IActionResult ValidateContent()
        {
            string fs = "/Users/mihailkopchev/Projects/asp-dota/asp-dota/XML";
            string pattern = ".xml";
            string[] files = Directory.GetFiles(fs);

            var xmls = new List<Pair<string, bool>>();
            foreach (string file in files)
            {
                if(file.EndsWith(pattern)){
                    
                    bool valid = _reader.ValidateInput(file);
                    var pair = new Pair<string, bool>(file, valid);
                    xmls.Add(pair);
                }
            }
            ViewBag.list = xmls;
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
