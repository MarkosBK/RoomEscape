using ASP_ComplexEx.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_ComplexEx.Controllers
{
    public class AdminController : Controller
    {
        IRepository<Room> repository;
        public AdminController(IRepository<Room> repository)
        {
            this.repository = repository;
        }
        public ActionResult Index()
        {
            return View(model: repository.GetList());
        }    
        
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (repository.GetList().Select(r => r.Id).Contains(id))
            {
                return View(model: repository.GetList().First(r => r.Id == id));
            }
            return HttpNotFound("This room not found");
        }   
        
        [HttpPost]
        public ActionResult Edit(Room room, HttpPostedFileBase Logo, HttpPostedFileBase[] NewImages)
        {
            NewImages = NewImages.Where(img => img != null).ToArray();   

            if (NewImages.Length > 0)
            {
                room.Images = repository.getById(room.Id).Images.Where(p => !p.IsLogo).ToList();
                for (int i = 0; i < NewImages.Length; i++)
                {
                    ImageForRoom img = new ImageForRoom() { Path = Path.Combine("/Images/", NewImages[i].FileName), Title = NewImages[i].FileName, Room = room, RoomId = room.Id, IsLogo = false };
                    
                    if (!room.Images.Select(p => p.Path).Contains(img.Path))
                    {
                        NewImages[i].SaveAs(Server.MapPath(img.Path));
                        room.Images.Add(img);
                    }
                }
            }
            if (Logo != null)
            {
                ImageForRoom img = new ImageForRoom() { Path = Path.Combine("/Images/", Logo.FileName), Title = Logo.FileName, Room = room, RoomId = room.Id, IsLogo = true };
                Logo.SaveAs(Server.MapPath(img.Path));
                room.Images.Add(img);
            }
            repository.Edit(room);
            return View("Index", model: repository.GetList());
        }
        
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Room room, HttpPostedFileBase[] images, HttpPostedFileBase Logo)
        {
            room.Images = room.Images.Where(r => r != null).ToList();

            if (Logo != null)
            {
                ImageForRoom img = new ImageForRoom() { Path = Path.Combine("/Images/", Logo.FileName), Title = Logo.FileName, Room = room, RoomId = room.Id, IsLogo = true };
                Logo.SaveAs(Server.MapPath(img.Path));
                room.Images.Add(img);
            }
            else
            {
                ImageForRoom img = new ImageForRoom() { Path = Path.Combine("/Images/", Logo.FileName), Title = Logo.FileName, Room = room, RoomId = room.Id, IsLogo = true };
            }
            repository.Edit(room);
            return View("Index", model: repository.GetList());
        }   
        
        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return View("Index", model: repository.GetList()) ;
        }
    }
}