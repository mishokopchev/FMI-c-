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
using System.Configuration;

namespace asp_dota.Controllers
{
    public class HomeController : Controller
    {
        private ISerealizer<Dota> _serializer;
        private IAdapter<DotaEntity,Dota> _adapter;
        private IDotaRepository _dotaRepository;

        //TODO get the configuration Manager for reading files, prekaleno mnogo za edno property
        [ConfigurationProperty("FileSystem", IsRequired = true)]
        private string _fs { get; set; }


        public HomeController(ISerealizer<Dota> ser,IAdapter<DotaEntity,Dota> Adapter,IDotaRepository DotaRepository)
        {
            this._serializer = ser;
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
            var pairs = new List<Pair<string, bool>>();
            string fs = "./XML";
            string pattern = ".xml";
            string currentFile = "";

            string[] files = Directory.GetFiles(fs);

                foreach(string file in files){
                   if(file.EndsWith(pattern)){
                    try
                    {
                        currentFile = file;
                        Dota dota1 = _serializer.Deserialize(file);
                        DotaEntity entity = _adapter.Adapt(dota1);
                        _dotaRepository.Persist(entity);
                        var pair = new Pair<string, bool>(file, true);
                        pairs.Add(pair);
                    }
                    catch (Exception e)
                    {
                        var pair = new Pair<string, bool>(currentFile, false);
                        pairs.Add(pair);
                        continue;
                    }
						
                    }
                }

            ViewBag.list = pairs;
            return View();
        }

        public IActionResult ValidateContent()
        {
            string fs = "./XML";
            string pattern = ".xml";
            string[] files = Directory.GetFiles(fs);
            var xmls = new List<Pair<string, bool>>();
            foreach (string file in files)
            {
                if (file.EndsWith(pattern, StringComparison.Ordinal))
                {
                    bool valid = false;
                    try
                    {
                        valid = _serializer.Validate(file);
                        var pair = new Pair<string, bool>(file, valid);
                        xmls.Add(pair);
                    }
                    catch (Exception e)
                    {
                        var pair = new Pair<string, bool>(file, valid);
                        xmls.Add(pair);
                        continue;
                    }
                }

            }

            ViewBag.list = xmls;
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
