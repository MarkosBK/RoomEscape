using ASP_ComplexEx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Web;
using System.Web.Mvc;

namespace ASP_ComplexEx.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Room> repository;
        public HomeController(IRepository<Room> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Fear = "All";
            ViewBag.Difficulty = "All";
            ViewBag.MinPlayers = 1;
            ViewBag.MaxPlayers = 99;
            return View(model: repository.GetList());
        }

        [HttpPost]
        public ActionResult Index(string Fear, string Difficulty, int MinPlayers, int MaxPlayers)
        {
            ViewBag.Fear = Fear;
            ViewBag.Difficulty = Difficulty;
            ViewBag.MinPlayers = MinPlayers;
            ViewBag.MaxPlayers = MaxPlayers;
            List<Room> filterList = new List<Room>();
            if (Fear == "All"&&Difficulty=="All")
            {
                filterList = repository.GetList().Where(r => r.MinPlayers>=MinPlayers).Where(r => r.MaxPlayers<=MaxPlayers).ToList();
            }
            
            else if (Difficulty=="All")
            {
                filterList = repository.GetList().Where(r => r.MinPlayers>=MinPlayers).Where(r => r.MaxPlayers<=MaxPlayers).Where(r=>r.FearLevel.ToString()==Fear).ToList();
            }
            
            else if (Fear=="All")
            {
               filterList = repository.GetList().Where(r => r.MinPlayers>=MinPlayers).Where(r => r.MaxPlayers<=MaxPlayers).Where(r=>r.DifficultyLevel.ToString()==Difficulty).ToList();
            }

            return View(model: filterList);
        }

        public ActionResult SelectedRoom(int id)
        {
            if (!repository.GetList().Select(a => a.Id).Contains(id))
            {
                return new HttpNotFoundResult("This room not found");
            }
            return View(model: repository.GetList().First(a => a.Id == id));
        }


    }
}