using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;
using System.Data.Entity.Infrastructure;

namespace MVCDemo.Controllers
{
    public class CoursesController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Courses
        public ActionResult Index()
        {
            var courses = db.Courses.Include(c => c.Department);
            return View(courses.ToList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(404, "Page not found");
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                throw new Exception("No matched course found");
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentId", "Name");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,CourseName,TotalCredits,DepartmentID,stamp")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentId", "Name", course.DepartmentID);
            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentId", "Name", course.DepartmentID);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,CourseName,TotalCredits,DepartmentID,stamp")] Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(course).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entry = ex.Entries.Single();
                var clientValues = (Course)entry.Entity;
                var databaseEntry = entry.GetDatabaseValues();

                if(databaseEntry == null)
                {
                    ModelState.AddModelError(string.Empty, "Unable to save the change. The course you are editing is deleted by another user.");
                }
                else
                {
                    var databaseValues = (Course)databaseEntry.ToObject();

                    if (databaseValues.CourseName != clientValues.CourseName)
                        ModelState.AddModelError("CourseName", "Current Value: "+ databaseValues.CourseName);
                    if (databaseValues.TotalCredits != clientValues.TotalCredits)
                        ModelState.AddModelError("TotalCredits", "Current Value: " + databaseValues.TotalCredits);
                    if (databaseValues.DepartmentID != clientValues.DepartmentID)
                        ModelState.AddModelError("DepartmentId", "Current Value: " + databaseValues.DepartmentID);

                    ModelState.AddModelError(string.Empty, "The record you attempted to edit was modified by another"
                        + " after you gotthe original value. The edit operation was canceled"
                        + " and the current values in the database have been displayed. if you "
                        + "still want to edit the record, click the save button again");

                    course.stamp = databaseValues.stamp;
                }

            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentId", "Name", course.DepartmentID);
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
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
