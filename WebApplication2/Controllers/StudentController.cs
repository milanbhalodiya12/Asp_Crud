using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index(Student s)
        {
            MyDbEntities1 db = new MyDbEntities1();
            List<Student> std = db.Students.ToList();
            return View(std);
        } 
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(Student s)
        {
            MyDbEntities1 db = new MyDbEntities1();
            db.Students.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit()
        {
            return RedirectToAction("Registration");
        }
        public ActionResult Edit(int ID)
        {
            if (ID != null)
            {   

            }
        }
        public ActionResult Delete(int ID)
        {
            MyDbEntities1 db = new MyDbEntities1();
            Student std = db.Students.Find(ID);
            db.Students.Remove(std);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}