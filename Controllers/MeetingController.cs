using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers
{
   
    public class MeetingController : Controller
    {       
        //[HttpGet] = default olarak gelir, yazılması zorunlu değil
        public IActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Apply(UserInfo model)
        {    
            if(ModelState.IsValid)
            {
                Repository.CreateUser(model);
                ViewBag.UserCount = Repository.Users.Where(info=>info.WillAttend == true).Count();
                return View("Thanks", model);
            }
            else
            {
                return View(model);
            }
           
        }
        
        
        public IActionResult List()
        {          
            return View(Repository.Users);
        }

        // meeting/details/...
        public IActionResult Details(int id)
        {
            return View(Repository.GetById(id));
        }
    }
}