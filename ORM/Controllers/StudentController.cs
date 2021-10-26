using ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ORM.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            var db = new StrigEntities();
            var data = db.Students.ToList();

            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create (Student s)
        {
            var db = new StrigEntities();
            db.Students.Add(s);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Edit (int Id)
        {
            var db = new StrigEntities();
            var student = (from s in db.Students
                           where s.Id == Id
                           select s).FirstOrDefault();

            return View(student);
        }

        [HttpPost]
        public ActionResult Edit (Student st)
        {
            var db = new StrigEntities();
            var student = (from s in db.Students
                           where s.Id == st.Id
                           select s).FirstOrDefault();

            /*student.Name = st.Name;
            student.Gender = st.Gender;
            student.Cgpa = st.Cgpa;
            student.Dob = st.Dob;
            db.SaveChanges();*/

            db.Entry(student).CurrentValues.SetValues(st);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        
        public ActionResult Delete (int Id)
        {
            var db = new StrigEntities();
            var student = (from s in db.Students
                           where s.Id == Id
                           select s).FirstOrDefault();

            db.Students.Remove(student);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}