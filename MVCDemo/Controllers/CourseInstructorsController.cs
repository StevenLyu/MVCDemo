using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class CourseInstructorsController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: CourseInstructors
        public ActionResult Index()
        {
            var courseInstructors = db.CourseInstructors.Include(c => c.course).Include(c => c.instructor);
            return View(courseInstructors.ToList());
        }

        // GET: CourseInstructors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(404, "Bad request");
            }
            CourseInstructor courseInstructor = db.CourseInstructors.Find(id);
            if (courseInstructor == null)
            {
                return HttpNotFound();
            }
            return View(courseInstructor);
        }

        // GET: CourseInstructors/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            ViewBag.PersonId = new SelectList(db.Instructors, "PersonId", "LastName");
            return View();
        }

        // POST: CourseInstructors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CourseId,PersonId")] CourseInstructor courseInstructor)
        {
            if (ModelState.IsValid)
            {
                db.CourseInstructors.Add(courseInstructor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", courseInstructor.CourseId);
            ViewBag.PersonId = new SelectList(db.Instructors, "PersonId", "LastName", courseInstructor.PersonId);
            return View(courseInstructor);
        }

        // GET: CourseInstructors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseInstructor courseInstructor = db.CourseInstructors.Find(id);
            if (courseInstructor == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", courseInstructor.CourseId);
            ViewBag.PersonId = new SelectList(db.Instructors, "PersonId", "LastName", courseInstructor.PersonId);
            return View(courseInstructor);
        }

        // POST: CourseInstructors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CourseId,PersonId")] CourseInstructor courseInstructor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseInstructor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", courseInstructor.CourseId);
            ViewBag.PersonId = new SelectList(db.Instructors, "PersonId", "LastName", courseInstructor.PersonId);
            return View(courseInstructor);
        }

        // GET: CourseInstructors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseInstructor courseInstructor = db.CourseInstructors.Find(id);
            if (courseInstructor == null)
            {
                return HttpNotFound();
            }
            return View(courseInstructor);
        }

        // POST: CourseInstructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseInstructor courseInstructor = db.CourseInstructors.Find(id);
            db.CourseInstructors.Remove(courseInstructor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
