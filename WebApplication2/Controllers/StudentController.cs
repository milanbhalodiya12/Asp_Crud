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
        MyDbEntities1 db = new MyDbEntities1();
        // GET: Student
        public ActionResult Index(Student s)
        {
           
            List<Student> std = db.Students.ToList();
            return View(std);
        } 
        public ActionResult Registration(int ? Id)
        {
            Student std = db.Students.Find(Id);
            return View(std);
        }
        [HttpPost]
        public ActionResult Registration(Student s)
        {
            if (s.Id !=0)
            {
                Student std = db.Students.Find(s.Id);
                std.fname = s.fname;
                std.lname = s.lname;
                std.city = s.city;
            }
            else
            {
                db.Students.Add(s);

            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int ID)
        {
            Student std = db.Students.Find(ID);
            db.Students.Remove(std);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}