using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchWorld.Models;
using WatchWorld.Service;

namespace WatchWorld.Controllers
{
    public class UserController : Controller
    {
        UserDAL userDetails = new UserDAL();
        // GET: User
        public ActionResult List()
        {
            var data = userDetails.GetUsers();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserModel user)
        {
            if(userDetails.InsertUser(user))
            {
                TempData["InsertMsg"] = "<script>alert('User saved sucessfully.....')</script>";
                return RedirectToAction("List");
            }
            else
            {
                TempData["InsertErrorMsg"] = "<script>alert('Error')</script>";

            }
            return View();
        }

        public ActionResult Details(int id)
        {
            var data = userDetails.GetUsers().Find(a => a.Id == id);
            return View(data);
        }


        public ActionResult Edit(int id)
        {
            var data = userDetails.GetUsers().Find(a => a.Id == id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(UserModel user)
        {
            if (userDetails.UpdateUser(user))
            {
                TempData["UpdateMsg"] = "<script>alert('User updatedsucessfully.....')</script>";
                return RedirectToAction("List");
            }
            else
            {
                TempData["UpdateErrorMsg"] = "<script>alert('Error')</script>";

            }
            return View();
        }

        
        public ActionResult Delete(int id)
        {
            int r = userDetails.DeleteUser(id);
            if (r>0)
            {
                TempData["DeleteMsg"] = "<script>alert('User Deleted sucessfully.....')</script>";
                return RedirectToAction("List");
            }
            else
            {
                TempData["DeleteErrorMsg"] = "<script>alert('Error Deleting')</script>";

            }
            return View();
        }

        
    }
}